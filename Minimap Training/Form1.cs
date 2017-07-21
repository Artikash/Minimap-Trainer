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

namespace Minimap_Training
{
    public partial class Form1 : Form
    {
        Form dot;
        int clicked = -1;
        List<double> responseTimes = new List<double>();
        Random rng = new Random();
        static DateTime time0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesktopLocation = new Point(945, 585);
            dot = new Form2();
            dot.Show(this);
            dot.DesktopLocation = new Point(959, 599);
            dot.BackColor = Color.FromArgb(255, Properties.Settings.Default.Red, Properties.Settings.Default.Green, Properties.Settings.Default.Blue);
            dot.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (clicked > -1)
            {
                TimeSpan span = DateTime.Now - time0;
                double responseTime = span.TotalSeconds;
                responseTimes.Add(responseTime);
                Console.WriteLine("Response Time: " + responseTime.ToString());
                Console.WriteLine("Average Time: " + responseTimes.Average().ToString());
            }
            clicked++;
            Opacity = 0;
            dot.Opacity = 0;
            timer1.Interval = rng.Next(Properties.Settings.Default.minTime, Properties.Settings.Default.maxTime);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            dot.Size = new Size(5, 5);
            Opacity = .01;
            dot.Opacity = 1;
            int x = rng.Next(Properties.Settings.Default.x1, Properties.Settings.Default.x2);
            int y = rng.Next(Properties.Settings.Default.y1, Properties.Settings.Default.y2);
            DesktopLocation = new Point(x, y);
            dot.DesktopLocation = new Point(x + 13, y + 13);
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
