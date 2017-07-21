using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimap_Training
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Use preset settings?");
            if (Console.ReadLine() != "yes")
            {
                Console.WriteLine("Please click on the top left of your minimap.");
                Application.Run(new Form3());

                Console.WriteLine("Minimum time between appearances? (ms)");
                Properties.Settings.Default.minTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Maximum time between appearances? (ms)");
                Properties.Settings.Default.maxTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Custom Color?");
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Red");
                    Properties.Settings.Default.Red = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Green");
                    Properties.Settings.Default.Green = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Blue");
                    Properties.Settings.Default.Blue = Convert.ToInt16(Console.ReadLine());
                }               
            }
            Console.WriteLine("Starting!");
            Application.Run(new Form1());
        }
    }
}
