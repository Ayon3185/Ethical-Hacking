using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrlHistoryLibrary;

namespace ComputerHackingProject
{
    public partial class ComputerHacking_TrackUserAction : Form
    {
        public ComputerHacking_TrackUserAction()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrlHistoryWrapperClass urlHistoryWrapper = new UrlHistoryWrapperClass();

            UrlHistoryWrapperClass.STATURLEnumerator enumerator
                                = urlHistoryWrapper.GetEnumerator();

            DataTable hackingtable = new DataTable();

            DataColumn DC1 = new DataColumn("Folders Being Used");
            //DataColumn DC2 = new DataColumn("Browsing Site Title");

            hackingtable.Columns.Add(DC1);
            //hackingtable.Columns.Add(DC2);

            while (enumerator.MoveNext())
            {
                string url = enumerator.Current.URL;
                string title = "";

                try
                {
                    title = string.IsNullOrEmpty(enumerator.Current.Title)
                        ? enumerator.Current.LastVisited.ToLongDateString() : "";

                }
                catch (Exception ex)
                {


                }
                int val = url.IndexOf("www");
                int val1 = url.IndexOf("ttp");
                int val2 = url.IndexOf("ttps");
                if (val > 0 || val1 > 0 || val2 > 0)
                {
                  
                }
                else
                {
                    DataRow dr = hackingtable.NewRow();
                    dr[0] = url;
                    //dr[1] = title;
                    hackingtable.Rows.Add(dr);
                }
            
        }
            dataGridView1.DataSource = hackingtable;
        }
    }
}
