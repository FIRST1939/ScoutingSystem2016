using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleJoysticks
{
    public partial class SortDataDisplay : Form
    {
        public SortDataDisplay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\ScoutingXYZ\\Scouting123.txt");
            String text = file.ReadLine();
            dataPanel.Enabled = true;
            dataPanel.Visible = true;

            if (dataPanel.Enabled == true && dataPanel.Visible == true)
            {
                lblData.Text = text;
            }
        }

        
    }
}
