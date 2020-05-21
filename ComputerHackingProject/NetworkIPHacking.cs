using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
namespace ComputerHackingProject
{
    public partial class NetworkIPHacking : Form
    {
        public NetworkIPHacking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach(UnicastIPAddressInformation Getip in networkInterface.GetIPProperties().UnicastAddresses)
                {
                   
                            listBox1.Items.Add(Getip.Address.ToString());
                    
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation Getip in networkInterface.GetIPProperties().UnicastAddresses)
                {
                    if (!Getip.IsDnsEligible)
                    {
                        if (Getip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            listBox2.Items.Add(Getip.Address.ToString());
                        }
                    }
                    

                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
