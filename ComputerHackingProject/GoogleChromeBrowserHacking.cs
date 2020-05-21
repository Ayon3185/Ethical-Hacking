using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WikitechyHackingLib;
namespace ComputerHackingProject
{
    public partial class GoogleChromeBrowserHacking : Form
    {
        public GoogleChromeBrowserHacking()
        {
            InitializeComponent();
        }

        private void GoogleChromeBrowserHacking_Load(object sender, EventArgs e )
        {

        }
        WikitechyHackingLib.WikitechyHackingLib hackingLibrary = new WikitechyHackingLib.WikitechyHackingLib();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataset = hackingLibrary.ChromeHackingConnection();

            if (dataset != null && dataset.Tables.Count > 0 && dataset.Tables[0] != null)
            {
                DataTable dt = dataset.Tables[0];

                DataTable hackingtable = new DataTable();
                DataColumn DC1 = new DataColumn("Browser URL");
                DataColumn DC2 = new DataColumn("Browser Site Title");
                DataColumn DC3 = new DataColumn("Browsing Site Count");
                DataColumn DC4 = new DataColumn("Browsing Site Timing");
                

                hackingtable.Columns.Add(DC1);
                hackingtable.Columns.Add(DC2);
                hackingtable.Columns.Add(DC3);
                hackingtable.Columns.Add(DC4);

                String URL = "";
                string visittiming = "";
                string title = "";
                string visit_count = "";

                foreach (DataRow chromehistory in dt.Rows)
                {
                    URL = Convert.ToString(chromehistory["url"]);

                    visittiming = Convert.ToString(chromehistory["last_visit_time"]);

                    long chromeMSData = Convert.ToInt64(visittiming);

                    DateTime dtWindows = DateTime.FromFileTimeUtc(10 * chromeMSData);

                    DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(dtWindows, TimeZoneInfo.Local);

                    title = Convert.ToString(chromehistory["title"]);

                    visit_count = Convert.ToString(chromehistory["visit_count"]);

                    DataRow dr = hackingtable.NewRow();

                    dr[0] = URL;
                    dr[0] = title;
                    dr[0] = visit_count;
                    dr[0] = localTime.ToString(); // visittiming;

                    hackingtable.Rows.Add(dr);

                }

                dataGridView1.DataSource = hackingtable;
            }
        }
    }
}
