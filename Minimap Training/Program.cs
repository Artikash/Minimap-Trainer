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
            Console.WriteLine("Use preset settings?");
            if (Console.ReadLine() != "yes")
            {
                Console.WriteLine("x coord of top left of minimap");
                Properties.Settings.Default.x1 = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("y coord of top left of minimap");
                Properties.Settings.Default.y1 = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("x coord of bottom right of minimap");
                Properties.Settings.Default.x2 = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("y coord of bottom right of minimap");
                Properties.Settings.Default.y2 = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("min time between appearances (ms)");
                Properties.Settings.Default.minTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("max time between appearances (ms)");
                Properties.Settings.Default.maxTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Red");
                Properties.Settings.Default.Red = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Green");
                Properties.Settings.Default.Green = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Blue");
                Properties.Settings.Default.Blue = Convert.ToInt16(Console.ReadLine());
            }
            else { };

            Console.WriteLine("Starting!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
