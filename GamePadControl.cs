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
        private GamePad gamePad;

        public GamePad GamePad
        {
            get { return gamePad; } 
            set { gamePad = value; }
        }

        public GamePadControl()
        {
            InitializeComponent();
        }
    }
}
