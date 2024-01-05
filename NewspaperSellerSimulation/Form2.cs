using NewspaperSellerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperSellerSimulation
{
    public partial class Form2 : Form
    {
        SimulationSystem system1;
        public Form2(SimulationSystem sys)
        {
            system1 = sys;
            InitializeComponent();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox3.Text =system1.PerformanceMeasures.TotalSalesProfit.ToString();
            textBox16.Text=system1.PerformanceMeasures.TotalCost.ToString();
            textBox15.Text=system1.PerformanceMeasures.TotalLostProfit.ToString();
            textBox14.Text=system1.PerformanceMeasures.TotalScrapProfit.ToString(); 
            textBox4.Text=system1.PerformanceMeasures.TotalNetProfit.ToString();
            textBox7.Text=system1.PerformanceMeasures.DaysWithMoreDemand.ToString();
            textBox6.Text=system1.PerformanceMeasures.DaysWithUnsoldPapers.ToString();


        }
    }
}
