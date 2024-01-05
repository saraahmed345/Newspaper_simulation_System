using NewspaperSellerModels;
using NewspaperSellerTesting;
using System;
using System.Windows.Forms;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            SimulationSystem system = new SimulationSystem();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = null;
            Application.Run(new Form1(path));
            path = Form1.getPath();

           // SimulationSystem s = new SimulationSystem();
            //s.Read_file("D:\\level 4\\modeling and simulation\\NewspaperSellerSimulation_Students\\NewspaperSellerSimulation\\TestCases\\TestCase1.txt");
            if (path == null) return;
            if (path == "") return;
            system.Read_file(path);

            system.simulation_table_records();

            system.calculate_Performance();

            Form1.setSystem(system);
            Application.Run(new Form1(path));

            string result = TestingManager.Test(system, Constants.FileNames.TestCase1);

            MessageBox.Show(result);

        }
    }
}
