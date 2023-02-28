using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetForMe
{
	public partial class SelectAdapter : Form
	{
		private readonly NetworkInterface[] networkInterfaces;
		private IEnumerator NIEnumerator;
		private NetworkInterface selectedNetworkInterface;
		public bool packetsHaveToBeRedirected;

		public SelectAdapter()
		{
			InitializeComponent();
			networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			packetsHaveToBeRedirected = false;
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(NIEnumerator = networkInterfaces.GetEnumerator()).MoveNext())
			{
				return;
			}
			NetworkInterface networkInterface;
			while (true)
			{
				networkInterface = (NetworkInterface)NIEnumerator.Current;
				if (networkInterface.Description.CompareTo(comboBox1.SelectedItem.ToString()) == 0)
				{
					break;
				}
				if (!NIEnumerator.MoveNext())
				{
					return;
				}
			}
			//labelTypeText.Text = ((NetworkInterfaceType)(object)networkInterface.NetworkInterfaceType).ToString();
			int num = 0;
			if (0 < networkInterface.GetIPProperties().UnicastAddresses.Count)
			{
				do
				{
					if ((bool)(Convert.ToString(networkInterface.GetIPProperties().UnicastAddresses[num].Address.AddressFamily)?.EndsWith("V6")))
					{
						num++;
						continue;
					}
					//labelIpText.Text = networkInterface.GetIPProperties().UnicastAddresses[num].Address.ToString();
					break;
				}
				while (num < networkInterface.GetIPProperties().UnicastAddresses.Count);
			}
			if (networkInterface.GetIPProperties().GatewayAddresses.Count > 0 && networkInterface.GetIPProperties().GatewayAddresses[0].Address.ToString().CompareTo("0.0.0.0") != 0)
			{
				//labelGWText.Text = networkInterface.GetIPProperties().GatewayAddresses[0].Address.ToString();
				//buttonOK.Enabled = true;
				selectedNetworkInterface = networkInterface;
			}
			else
			{
				//labelGWText.Text = "No Gateway !";
				//buttonOK.Enabled = false;
			}
		}

		private void SelectAdapter_Shown(object sender, EventArgs e)
		{
			//ArpForm.instance.Enabled = false;
			(NIEnumerator = networkInterfaces.GetEnumerator()).MoveNext();
			if (((NetworkInterface)NIEnumerator.Current).GetIPProperties().GetIPv4Properties().IsForwardingEnabled)
			{
				//labelRedirectInfo.Text = "Windows does redirect packet,\n internal redirection will be turned off";
				packetsHaveToBeRedirected = false;
			}
			else
			{
				//labelRedirectInfo.Text = "Windows does not redirect packet,\n internal redirection will be turned on";
				packetsHaveToBeRedirected = true;
			}
			NIEnumerator.Reset();
			if (NIEnumerator.MoveNext())
			{
				do
				{
					NetworkInterface networkInterface = (NetworkInterface)NIEnumerator.Current;
					if (networkInterface.GetIPProperties().GatewayAddresses.Count > 0 && networkInterface.OperationalStatus == OperationalStatus.Up)
					{
						comboBox1.Items.Add(((NetworkInterface)NIEnumerator.Current).Description);
					}
				}
				while (NIEnumerator.MoveNext());
			}
			if (comboBox1.Items.Count > 1)
			{
				int num = 0;
				NIEnumerator.Reset();
				if (NIEnumerator.MoveNext())
				{
					do
					{
						NetworkInterface networkInterface2 = (NetworkInterface)NIEnumerator.Current;
						if (networkInterface2.GetIPProperties().GatewayAddresses.Count <= 0 || networkInterface2.GetIPProperties().GatewayAddresses[0].Address.ToString().CompareTo("0.0.0.0") == 0)
						{
							num++;
							continue;
						}
						comboBox1.SelectedIndex = num;
						return;
					}
					while (NIEnumerator.MoveNext());
				}
			}
			if (comboBox1.Items.Count == 1)
			{
				comboBox1.SelectedIndex = 0;
				return;
			}
			MessageBox.Show("No network card with a gateway has been found!");
			//((IDisposable)ArpForm.instance)?.Dispose();
		}
	}
}
