using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleJoysticks
{
    interface IMatchDisplay
    {
        void SetControllerCommands(int controllernumber, string[] Command, string buttons);
        void UseButtonMap(int id, string strButtonMap);
    }
}
