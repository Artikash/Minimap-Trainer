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
        int x1 = Properties.Settings.Default.x1;
        int y1 = Properties.Settings.Default.y1;
        int x2 = Properties.Settings.Default.x2;
        int y2 = Properties.Settings.Default.y2;
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
                double average = responseTimes.Average();
                Console.WriteLine("Response Time: " + responseTime.ToString());
                Console.WriteLine("Average Time: " + average.ToString());
            }

            clicked++;
            int time = rng.Next(Properties.Settings.Default.minTime, Properties.Settings.Default.maxTime);
            Opacity = 0;
            dot.Opacity = 0;
            timer1.Interval = time;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Opacity = .01;
            dot.Opacity = 1;
            int x = rng.Next(x1, x2);
            int y = rng.Next(y1, y2);

            DesktopLocation = new Point(x, y);
            dot.DesktopLocation = new Point(x + 14, y + 14);
            time0 = DateTime.Now;
        }
    }
}
