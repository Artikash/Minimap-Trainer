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
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
        Form dot;
        int clicked = -1;
        List<double> responseTimes = new List<double>();
        Random rng = new Random();
        static DateTime time0;
        IntPtr game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesktopLocation = new Point(Properties.Settings.Default.x1, Properties.Settings.Default.y1);
            dot = new Form2();
            dot.Show(this);
            dot.DesktopLocation = new Point(Properties.Settings.Default.x1 + 13, Properties.Settings.Default.y1 + 13);
            dot.BackColor = Color.FromArgb(255, Properties.Settings.Default.Red, Properties.Settings.Default.Green, Properties.Settings.Default.Blue);
            dot.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            SetForegroundWindow(game);
            if (clicked > -1)
            {
                double responseTime = (DateTime.Now - time0).TotalSeconds;
                responseTimes.Add(responseTime);
                Console.WriteLine("Response Time: " + responseTime.ToString() + "s");
                Console.WriteLine("Average Time: " + responseTimes.Average().ToString() + "s");
            }
            timer2.Stop();
            clicked++;
            Opacity = 0;
            dot.Opacity = 0;
            timer1.Interval = rng.Next(Properties.Settings.Default.minTime, Properties.Settings.Default.maxTime);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game = GetForegroundWindow();
            timer1.Stop();
            dot.Size = new Size(5, 5);
            Opacity = .01;
            dot.Opacity = 1;
            int x = rng.Next(Properties.Settings.Default.x1, Properties.Settings.Default.x2);
            int y = rng.Next(Properties.Settings.Default.y1, Properties.Settings.Default.y2);
            DesktopLocation = new Point(x - 13, y - 13);
            dot.DesktopLocation = new Point(x, y);
            time0 = DateTime.Now;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dot.Size.Height < 24)
            {
                dot.Size = new Size(dot.Size.Width + 6, dot.Size.Height + 6);
                dot.DesktopLocation = new Point(dot.DesktopLocation.X - 3, dot.DesktopLocation.Y - 3);
            }
            else
            {
                timer2.Stop();
            }
        }
    }
}
