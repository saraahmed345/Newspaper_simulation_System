using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        static string path;
       // List<SimulationCase> simulationtable;
        static SimulationSystem system2;
        public Form1(string pathinp)
        {
            path = pathinp;
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            if (fd.FileName == null || fd.FileName == "")
            {

                return;

            }
            else
            {

                path = fd.FileName;
                this.Close();


            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            if (fd.FileName == null || fd.FileName == "")
            {

                return;

            }
            else
            {

                path = fd.FileName;
                this.Close();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (path == null)

            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                button1.Enabled = false;

            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;

                button1.Enabled = true;
                setPath(path);
               


                for (int i = 0; i < system2.SimulationTable.Count; i++)
                {
                    //dataGridView1.Rows.Add("Server " + (i + 1));
                    

                    dataGridView1.DataSource = system2.SimulationTable;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }


                }


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();

            if (fd.FileName == null || fd.FileName == "")
            {

                return;

            }
            else
            {

                path = fd.FileName;
                this.Close();


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(system2);
            frm2.ShowDialog();
        }
        public static string getPath()
        {
            return path;
        }
        public static void setPath(string pa)
        {
            path = pa;
        }
        public static void setSystem(SimulationSystem sys)
        {
            system2 = sys;

            //dataGridView1.DataSource = simulationtable;

        }

    }
}
