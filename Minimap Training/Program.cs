﻿using System;
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
            if (Console.ReadLine() != "yes")
            {
                Console.WriteLine("Please click on the top left of your minimap.");
                Application.Run(new CoordInput());

                Console.WriteLine("Custom Color?");
                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine("Red");
                    Properties.Settings.Default.Red = Convert.ToInt16(Console.ReadLine());  //these properties.settings.default settings are saved 
                                                                                            //when you close and reopen the program
                    Console.WriteLine("Green");                                             
                    Properties.Settings.Default.Green = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Blue");
                    Properties.Settings.Default.Blue = Convert.ToInt16(Console.ReadLine());
                }
                Properties.Settings.Default.Save();
            }
            Console.WriteLine("Starting!");
            Application.Run(new Container()); //the above is setup, most of the real code is here
        }
    }
}
