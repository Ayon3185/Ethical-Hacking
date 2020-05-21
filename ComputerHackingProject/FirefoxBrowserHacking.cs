using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WikitechyHackingLib;
namespace ComputerHackingProject
{
    public partial class FirefoxBrowserHacking : Form
    {
        public FirefoxBrowserHacking()
        {
            InitializeComponent();
        }
        WikitechyHackingLib.WikitechyHackingLib hackingLibrary = new WikitechyHackingLib.WikitechyHackingLib();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Ayon_Barrie_local_folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            String mozillafirefox_path = Ayon_Barrie_local_folder  + "\\Mozilla\\Firefox\\Profiles\\";

            DataTable hackingtable = new DataTable();

            DataColumn DC1 = new DataColumn("Browsing URL");
            DataColumn DC2 = new DataColumn("Browsing Site Title");

            hackingtable.Columns.Add(DC1);
            hackingtable.Columns.Add(DC2);

            if(Directory.Exists(mozillafirefox_path))
            {

                foreach(string folder in Directory.GetDirectories(mozillafirefox_path))
                {

                    DataTable historyDataTable = hackingLibrary.FirefoxHackingConnection(folder);

                    //optional
                    DataTable visitsDT = hackingLibrary.FirefoxHackingConnection1(folder);

                    foreach(DataRow browseDate in historyDataTable.Rows)
                    {
                        //link
                        var entryInfo = (from dates in visitsDT.AsEnumerable()

                                         where dates["place_id"].ToString() == browseDate["id"].ToString()
                                         select dates).LastOrDefault();
                        string url = "";
                        string title = "";
                        if (entryInfo != null)
                        {
                            url = browseDate["Url"].ToString();
                            title = browseDate["title"].ToString();

                        }

                        if (url.Length > 0)
                        {
                            DataRow dr = hackingtable.NewRow();
                            dr[0] = url;
                            dr[1] = title;
                            hackingtable.Rows.Add(dr);
                        }
                    }

                }
            }
            dataGridView1.DataSource = hackingtable;
        }
        

    }
}
