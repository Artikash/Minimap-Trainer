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
            Console.WriteLine("Use previous settings?");
            if (Console.ReadLine().ToLower() != "yes")
            {
                Console.WriteLine("Please click on the top left of your minimap.");
                Application.Run(new CoordInput());

                Console.WriteLine("Custom Color?");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    new ColorInput();
                }

                Console.WriteLine("Custom times between appearances? (I recommend using the defaults.)");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.WriteLine("Please enter minimum time (in seconds).");
                    Properties.Settings.Default.minTime = 1000 * Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter maximum time (in seconds).");
                    Properties.Settings.Default.maxTime = 1000 * Int32.Parse(Console.ReadLine());
                }

                Properties.Settings.Default.Save(); //save user settings
            }
            Console.WriteLine("Starting!");
            Application.Run(new Container()); //the above is setup, most of the real code is here
        }
    }
}
