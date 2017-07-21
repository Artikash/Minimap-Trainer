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
                string x1string = Console.ReadLine();
                int x1int = Convert.ToInt16(x1string);
                Properties.Settings.Default.x1 = x1int;

                Console.WriteLine("y coord of top left of minimap");
                string y1string = Console.ReadLine();
                int y1int = Convert.ToInt16(y1string);
                Properties.Settings.Default.y1 = y1int;

                Console.WriteLine("x coord of bottom right of minimap");
                string x2string = Console.ReadLine();
                int x2int = Convert.ToInt16(x2string);
                Properties.Settings.Default.x2 = x2int;

                Console.WriteLine("y coord of bottom right of minimap");
                string y2string = Console.ReadLine();
                int y2int = Convert.ToInt16(y2string);
                Properties.Settings.Default.y2 = y2int;

                Console.WriteLine("min time between appearances (ms)");
                string minTimeString = Console.ReadLine();
                int minTimeInt = Convert.ToInt32(minTimeString);
                Properties.Settings.Default.minTime = minTimeInt;

                Console.WriteLine("max time between appearances (ms)");
                string maxTimeString = Console.ReadLine();
                int maxTimeInt = Convert.ToInt32(maxTimeString);
                Properties.Settings.Default.maxTime = maxTimeInt;

                Console.WriteLine("Red");
                string stringRed = Console.ReadLine();
                int intRed = Convert.ToInt16(stringRed);
                Properties.Settings.Default.Red = intRed;

                Console.WriteLine("Green");
                string stringGreen = Console.ReadLine();
                int intGreen = Convert.ToInt16(stringGreen);
                Properties.Settings.Default.Green = intGreen;

                Console.WriteLine("Blue");
                string stringBlue = Console.ReadLine();
                int intBlue = Convert.ToInt16(stringBlue);
                Properties.Settings.Default.Blue = intBlue;
            }
            else { };


            Console.WriteLine("Starting!");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
