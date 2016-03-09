using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleJoysticks
{
    public partial class GamePadControl : UserControl
    {
        public String[] ControllerCommands = new String[22];
        public GamePad GamePad = new GamePad();

        public GamePadControl()
        {
            InitializeComponent();
        }
    }
}
