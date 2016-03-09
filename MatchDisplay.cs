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
    public partial class MatchDisplay : Form, IMatchDisplay
    {
        public MatchDisplay()
        {
            InitializeComponent();

            var gameInput = new GameInput();
            var sticks = gameInput.GetSticks(this);
            if (sticks > 0)
            {
                timer1.Enabled = true;
                timer1.Tick += gameInput.timer1_Tick;
            }
            else
            {
                MessageBox.Show("No Joysticks found!", "Warning", MessageBoxButtons.OK);
            }
        }

        void IMatchDisplay.SetControllerCommands(int controllernumber, string[] Command, string buttons)
        {
            //throw new NotImplementedException();
        }

        void IMatchDisplay.UseButtonMap(int id, string strButtonMap)
        {
            //throw new NotImplementedException();
        }
    }
}
