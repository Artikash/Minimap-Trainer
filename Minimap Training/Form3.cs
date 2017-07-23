using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minimap_Training
{
    public partial class Form3 : Form
    {
        int clicked = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DesktopLocation = new Point(0, 0);
            Size = new Size(12000, 12000);
        }

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (clicked == 0)
            {
                Properties.Settings.Default.x1 = x;
                Properties.Settings.Default.y1 = y;
                Console.WriteLine("x1: " + x.ToString() + " y1: " + y.ToString());
                Console.WriteLine("Please click on the bottom right of your minimap");
                clicked++;
            }
            else
            {
                Properties.Settings.Default.x2 = x;
                Properties.Settings.Default.y2 = y;
                Console.WriteLine("x2: " + x.ToString() + " y2: " + y.ToString());
                Close();
            }
        }
    }
}
