using PcapNet;
using System.Net;
using System.Net.NetworkInformation;

namespace NetForMe
{
	public delegate void delegateOnNewPC(PC? pc);

	public delegate void DelUpdateName(PC? pc, string? str);

	public partial class Spoof : Form
	{
		public int timerStatCount;
		public Driver driver;
		public PcList pcs;
		public CArp cArp;
		public SelectAdapter cAdapter;
		public byte[] routerIP;
		public object[] resolvState;
		public NetworkInterface nicNet;
		public static Spoof Instance;

		private System.Windows.Forms.Timer timer = new() { Interval = 5000 };

		public Spoof()
		{
			InitializeComponent();
			Instance = this;
			timerStatCount = 0;
			driver = new Driver();
		}

		//private void Timer2Tick(object sender, EventArgs e)
		//{
		//	int index1 = 0;
		//	if (0 < this.treeGridView1.Nodes[0].Nodes.Count)
		//	{
		//		do
		//		{
		//			PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index1].Cells[1].Value.ToString()).GetAddressBytes());
		//			if (pcFromIp != null && !pcFromIp.isGateway && !pcFromIp.isLocalPc && DateTime.Now.Ticks - ((DateTime)pcFromIp.timeSinceLastRarp).Ticks > 3500000000L)
		//			{
		//				this.pcs.removePcFromList(pcFromIp);
		//				index1 = 0;
		//			}
		//			++index1;
		//		}
		//		while (index1 < this.treeGridView1.Nodes[0].Nodes.Count);
		//	}
		//	int index2 = 0;
		//	if (0 >= this.treeGridView1.Nodes[0].Nodes.Count)
		//		return;
		//	do
		//	{
		//		PC pcFromIp = this.pcs.getPCFromIP(tools.getIpAddress(this.treeGridView1.Nodes[0].Nodes[index2].Cells[1].Value.ToString()).GetAddressBytes());
		//		if (pcFromIp != null && DateTime.Now.Ticks - ((DateTime)pcFromIp.timeSinceLastRarp).Ticks > 200000000L)
		//			this.cArp.findMac(pcFromIp.ip.ToString());
		//		++index2;
		//	}
		//	while (index2 < this.treeGridView1.Nodes[0].Nodes.Count);
		//}

		public void LicenseAccepted()
		{
			if (!driver.create())
			{
				_ = (int)MessageBox.Show("problem installing the drivers, do you have administrator privileges?");
				if (this == null)
					return;
				Dispose();
			}
			else
			{
				SelectAdapter cadapter = new();
				cAdapter = cadapter;
				cadapter.Show(this);
			}
		}

		public void NicIsSelected(NetworkInterface nic)
		{
			pcs = new PcList();
			//pcs.SetCallBackOnNewPC(new delegateOnNewPC(callbackOnNewPC));
			//pcs.SetCallBackOnPCRemove(new delegateOnNewPC(callbackOnPCRemove));
			nicNet = nic;
			CArp carp = new CArp(nic, pcs);
			cArp = carp;
			carp.StartArpListener();
			cArp.FindMacRouter();
			PC pc = new()
			{
				ip = new IPAddress(cArp.localIP),
				mac = new PhysicalAddress(cArp.localMAC),
				CapDown = 0,
				CapUp = 0,
				isLocalPc = true,
				name = string.Empty,
				nbPacketReceivedSinceLastReset = 0,
				nbPacketSentSinceLastReset = 0,
				Redirect = false
			};
			DateTime now = DateTime.Now;
			pc.timeSinceLastRarp = (ValueType)now;
			pc.totalPacketReceived = 0;
			pc.totalPacketSent = 0;
			pc.isGateway = false;
			//pcs.addPcToList(pc);
			//timer2.Start();
			//treeGridView1.Nodes[0].Expand();
		}

		//[Obsolete]
		//private void callbackOnNewPC(PC pc)
		//{
		//	object[] objArray = new object[1] { pc };
		//	Spoof arpForm = this;
		//	_ = arpForm.Invoke(new delegateOnNewPC(arpForm.AddPc), objArray);
		//	_ = Dns.BeginResolve(pc.ip.ToString(), new AsyncCallback(EndResolvCallBack), pc);
		//}

		//[Obsolete]
		//private void EndResolvCallBack(IAsyncResult re)
		//{
		//	string? str = null;
		//	PC? asyncState = re.AsyncState as PC;
		//	try
		//	{
		//		str = Dns.EndResolve(re).HostName;
		//		if (str == null as string)
		//			str = "noname";
		//		object[] objArray = new object[2];
		//		resolvState = objArray;
		//		objArray[0] = asyncState as object;
		//		resolvState[1] = (object)str;
		//		Invoke(new DelUpdateName(updateTreeViewNameCallBack), resolvState);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.Message);
		//	}
		//}

		//private void updateTreeViewNameCallBack(PC pc, string str)
		//{
		//	if (pc.isGateway)
		//	{
		//		//treeGridView1.Nodes[0].Cells[0].Value = (object)str;
		//		//treeGridView1.Nodes[0].ImageIndex = 1;
		//	}
		//	else
		//	{
		//		//int index = 1;
		//		//if (1 >= treeGridView1.Nodes[0].Nodes.Count)
		//			//return;
		//		//while (treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString().CompareTo(pc.ip.ToString()) != 0)
		//		//{
		//		//	++index;
		//		//	if (index >= treeGridView1.Nodes[0].Nodes.Count)
		//		//		return;
		//		//}
		//		//treeGridView1.Nodes[0].Nodes[index].Cells[0].Value = (object)str;
		//	}
		//}

		private void callbackOnPCRemove(PC pc)
		{
			//int index = 1;
			//if (1 >= treeGridView1.Nodes[0].Nodes.Count)
			//	return;
			//while (treeGridView1.Nodes[0].Nodes[index].Cells[1].Value.ToString().CompareTo(pc.ip.ToString()) != 0)
			//{
			//	++index;
			//	if (index >= treeGridView1.Nodes[0].Nodes.Count)
			//		return;
			//}
			//treeGridView1.Nodes[0].Nodes.RemoveAt(index);
		}

		//private void AddPc(PC pc)
		//{
		//	if (pc.isGateway)
		//	{
		//		treeGridView1.Nodes[0].Cells[1].Value = (object)pc.ip.ToString();
		//		treeGridView1.Nodes[0].Cells[2].Value = (object)pc.mac.ToString();
		//		treeGridView1.Nodes[0].Cells[5].ReadOnly = true;
		//		treeGridView1.Nodes[0].Cells[6].ReadOnly = true;
		//		treeGridView1.Nodes[0].Cells[7].ReadOnly = true;
		//		treeGridView1.Nodes[0].Cells[8].ReadOnly = true;
		//		treeGridView1.Nodes[0].Cells[5].Value = (object)0;
		//		treeGridView1.Nodes[0].Cells[6].Value = (object)0;
		//		treeGridView1.Nodes[0].Cells[7].ReadOnly = true;
		//		treeGridView1.Nodes[0].Cells[8].ReadOnly = true;
		//	}
		//	else if (pc.isLocalPc)
		//	{
		//		TreeGridNode treeGridNode = treeGridView1.Nodes[0].Nodes.Add((object)"Your PC", (object)pc.ip, (object)pc.mac.ToString());
		//		treeGridNode.ImageIndex = 0;
		//		treeGridNode.Cells[5].Value = (object)0;
		//		treeGridNode.Cells[6].Value = (object)0;
		//		treeGridNode.Cells[5].ReadOnly = true;
		//		treeGridNode.Cells[6].ReadOnly = true;
		//		treeGridNode.Cells[7].Value = (object)false;
		//		treeGridNode.Cells[8].Value = (object)false;
		//		treeGridNode.Cells[7].ReadOnly = true;
		//		treeGridNode.Cells[8].ReadOnly = true;
		//	}
		//	else
		//	{
		//		TreeGridNode treeGridNode = treeGridView1.Nodes[0].Nodes.Add((object)string.Empty, (object)pc.ip, (object)pc.mac.ToString(), (object)string.Empty, (object)string.Empty, (object)0, (object)0, (object)false, (object)true);
		//		treeGridNode.ImageIndex = 0;
		//		treeGridNode.Cells[5].ReadOnly = false;
		//		treeGridNode.Cells[6].ReadOnly = false;
		//	}
		//}
	}
}
