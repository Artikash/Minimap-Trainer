using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace Minimap_Training
{
    public partial class Container : Form //this code is organized chronologically, in the order which it will run
    {                                 //once everything has run once, Container_MouseClick, DotAppearTimer_tick, and DotGrowTimer_tick will loop in that order
        [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
        Form dot;
        int clicked = 0;
        List<double> responseTimes = new List<double>();
        Random rng = new Random();
        static DateTime time0;
        IntPtr game;

        public Container()
        {
            InitializeComponent();
        }

        private void Container_Load(object sender, EventArgs e) //this method creates a visible dot in the center of the invisible container
        {                                                   //so that you have to watch the minimap carefully, which gives some leniency on where to click
            DesktopLocation = new Point(Properties.Settings.Default.x1, Properties.Settings.Default.y1); //but still keeps the dot hard to notice
            dot = new Dot();
            dot.Show(this);
            dot.DesktopLocation = new Point(Properties.Settings.Default.x1 + 13, Properties.Settings.Default.y1 + 13);
            dot.BackColor = Color.FromArgb(255, Properties.Settings.Default.Red, Properties.Settings.Default.Green, Properties.Settings.Default.Blue);
            dot.MouseClick += new MouseEventHandler(Container_MouseClick);  //Container_MouseClick is also called when dot is clicked
        }                         
                                                                       
        private void Container_MouseClick(object sender, MouseEventArgs e)
        {                              //normally when a window is clicked, Windows shifts the foreground window to that window
            SetForegroundWindow(game); //this causes the user's gameplay to be interrupted, which is bad, so the foreground window is immediately sent back
            if (clicked > 0)           //to the game once the user clicks on this program
            {
                double responseTime = (DateTime.Now - time0).TotalSeconds; //calculates time between dot appearing (see DotAppearTimer_tick) and when it was clicked
                responseTimes.Add(responseTime);
                Console.WriteLine("Response Time: " + responseTime.ToString() + "s");
                Console.WriteLine("Average Time: " + responseTimes.Average().ToString() + "s"); //display times
            }
            DotGrowTimer.Stop();
            clicked++;
            Opacity = 0; //makes everything invisible
            dot.Opacity = 0; //has side effect that if user now clicks where container or dot are, their onclick events will not trigger
            DotAppearTimer.Interval = rng.Next(Properties.Settings.Default.minTime, Properties.Settings.Default.maxTime); 
            DotAppearTimer.Start();  //makes the program wait for 3 to 60 seconds, this can be changed in config file
        }                                                                                                         

        private void DotAppearTimer_Tick(object sender, EventArgs e)
        {
            game = GetForegroundWindow();
            DotAppearTimer.Stop();
            dot.Size = new Size(5, 5);
            Opacity = .01;
            dot.Opacity = 1; //makes the dot visible and makes everything able to be clicked
            int x = rng.Next(Properties.Settings.Default.x1, Properties.Settings.Default.x2); //moves dot to random spot on the minimap
            int y = rng.Next(Properties.Settings.Default.y1, Properties.Settings.Default.y2); //as defined by user in coordinput
            DesktopLocation = new Point(x - 13, y - 13);
            dot.DesktopLocation = new Point(x, y);
            time0 = DateTime.Now; //used in Container_MouseClick to calculate response time
            DotGrowTimer.Start(); //this timer is used to make the dot bigger (more noticable) the longer the user doesn't notice it
        }

        private void DotGrowTimer_Tick(object sender, EventArgs e)
        {
            if (dot.Size.Height < 24)
            {
                dot.Size = new Size(dot.Size.Width + 6, dot.Size.Height + 6);
                dot.DesktopLocation = new Point(dot.DesktopLocation.X - 3, dot.DesktopLocation.Y - 3); //makes dot bigger, keeps it centered in container
            }
            else
            {
                DotGrowTimer.Stop();
            }
        }
    }
}
