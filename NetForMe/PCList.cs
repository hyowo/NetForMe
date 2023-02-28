using System.Collections;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.InteropServices;

namespace NetForMe
{
	public class PC

	{
		public IPAddress? ip;

		public PhysicalAddress? mac;

		public string? name;

		public bool isGateway;

		public bool isLocalPc;

		private int capDown;

		private int capUp;

		private bool redirect;

		public int totalPacketSent;

		public int totalPacketReceived;

		public int nbPacketSentSinceLastReset;

		public int nbPacketReceivedSinceLastReset;

		public ValueType? timeSinceLastRarp;

		public int CapDown { get => capDown; set => capDown = value; }
		public int CapUp { get => capUp; set => capUp = value; }
		public bool Redirect { get => redirect; set => redirect = value; }
	}

	public class PcList : IDisposable

	{
		private delegateOnNewPC? delOnNewPC;

		private delegateOnNewPC? delOnPCRemove;

		public ArrayList pclist;

		public PcList() => pclist = new ArrayList();

		[return: MarshalAs(UnmanagedType.U1)]
		public bool AddPcToList(PC pc)
		{
			Monitor.Enter(pclist.SyncRoot);
			foreach (PC item in pclist)
			{
				if (item?.ip?.ToString().CompareTo(pc?.ip?.ToString()) == 0)
				{
					DateTime now = DateTime.Now;
					item.timeSinceLastRarp = now;
					Monitor.Exit(pclist.SyncRoot);
					return false;
				}
			}
			ArrayList.Synchronized(pclist).Add(pc);
			delOnNewPC?.Invoke(pc);
			Monitor.Exit(pclist.SyncRoot);
			return true;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool RemovePcFromList(PC pc)
		{
			Monitor.Enter(pclist.SyncRoot);
			foreach (PC item in pclist)
			{
				if (item?.ip?.ToString().CompareTo(pc?.ip?.ToString()) == 0)
				{
					delOnPCRemove?.Invoke(pc);
					pclist.Remove(pc);
					Monitor.Exit(pclist.SyncRoot);
					return true;
				}
			}
			Monitor.Exit(pclist.SyncRoot);
			return false;
		}

		public PC? GetRouter()
		{
			Monitor.Enter(pclist.SyncRoot);
			IEnumerator enumerator = pclist.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					if (((PC)enumerator.Current).isGateway)
					{
						Monitor.Exit(pclist.SyncRoot);
						return enumerator.Current as PC;
					}
				}
				while (enumerator.MoveNext());
			}
			Monitor.Exit(pclist.SyncRoot);
			return null;
		}

		public PC? GetLocalPC()
		{
			Monitor.Enter(pclist.SyncRoot);
			IEnumerator enumerator = pclist.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					if (((PC)enumerator.Current).isLocalPc)
					{
						Monitor.Exit(pclist.SyncRoot);
						return (PC)enumerator.Current;
					}
				}
				while (enumerator.MoveNext());
			}
			Monitor.Exit(pclist.SyncRoot);
			return null;
		}

		public PC? GetPCFromIP(byte[] ip)
		{
			Monitor.Enter(pclist.SyncRoot);
			IEnumerator enumerator = pclist.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					if (Tools.areValuesEqual((enumerator.Current as PC).ip.GetAddressBytes(), ip))
					{
						Monitor.Exit(pclist.SyncRoot);
						return enumerator.Current as PC;
					}
				}
				while (enumerator.MoveNext());
			}
			Monitor.Exit(pclist.SyncRoot);
			return null;
		}

		public PC? getPCFromMac(byte[] Mac)
		{
			Monitor.Enter(pclist.SyncRoot);
			IEnumerator enumerator = pclist.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					if (Tools.areValuesEqual(((PC)enumerator.Current).mac.GetAddressBytes(), Mac))
					{
						Monitor.Exit(pclist.SyncRoot);
						return (PC)enumerator.Current;
					}
				}
				while (enumerator.MoveNext());
			}
			Monitor.Exit(pclist.SyncRoot);
			return null;
		}

		public void ResetAllPacketsCount()
		{
			Monitor.Enter(pclist.SyncRoot);
			IEnumerator enumerator = pclist.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					((PC)enumerator.Current).nbPacketReceivedSinceLastReset = 0;
					((PC)enumerator.Current).nbPacketSentSinceLastReset = 0;
				}
				while (enumerator.MoveNext());
			}
			Monitor.Exit(pclist.SyncRoot);
		}

		public void SetCallBackOnNewPC(delegateOnNewPC callback)
		{
			delOnNewPC = callback;
		}

		public void SetCallBackOnPCRemove(delegateOnNewPC callback)
		{
			delOnPCRemove = callback;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
