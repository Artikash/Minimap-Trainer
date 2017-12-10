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
    public partial class ColorInput : Form
    {
        public ColorInput()
        {
            InitializeComponent();
            ColorInputDialog.ShowDialog();
            Properties.Settings.Default.Color = ColorInputDialog.Color;
            Close();
        }
    }
}
