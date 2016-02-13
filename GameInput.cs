using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SlimDX.DirectInput;

namespace MultipleJoysticks
{
    class GameInput
    {
        String[] tm1939strText = new String[6];
        Joystick[] Sticks;
        private const int maxbuttons = 15;
        private Form1 form;

        // --- INITIALIZTION ---

        public int GetSticks(Form1 form)
        {
            this.form = form;
            DirectInput Input = new DirectInput();

            List<Joystick> sticks = new List<Joystick>(); // Creates the list of joysticks connected to the computer via USB.
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                // Creates a joystick for each game device in USB Ports
                try
                {
                    var stick = new Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    // Gets the joysticks properties and sets the range for them.
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }

                    // Adds how ever many joysticks are connected to the computer into the sticks list.
                    sticks.Add(stick);
                }
                catch (DirectInputException)
                {
                }
            }
            Sticks = sticks.ToArray();
            var count = Sticks.Length;
            if (count > 0)
            {
                tm1939LoadSticks();
            }
            return count; // sticks.ToArray();
        }

        void tm1939LoadSticks()
        {
            StreamReader Controllers = new StreamReader(".\\Controllers\\Controllers.cfg");
            int ControllerCounter = 0;

            for (int i = 0; i < 6; i++)
                tm1939strText[i] = "";

            while (Controllers.Peek() > 0 && Sticks.Length > ControllerCounter)
            {
                tm1939LoadController(Controllers.ReadLine(), ControllerCounter);
                tm1939strText[ControllerCounter++] = "";
            }
        }

        void tm1939LoadController(string controllername, int controllernumber)
        {

            if (controllername.ToUpper().Equals("AUTO"))
            {
                controllername = Sticks[controllernumber].Properties.ProductName;
                controllername = Regex.Replace(controllername, @"\s+", "") + ".ctrl";
            }
            StreamReader ControllerCmds = new StreamReader(".\\Controllers\\" + controllername);


            while (ControllerCmds.Peek() > 0)
            {
                String[] Command = ControllerCmds.ReadLine().Split(',');
                String buttons = new String('F', maxbuttons);

                // Parse the second to nth items to set the T item in buttons
                for (int i = 1; i < Command.Length; i++)
                {
                    StringBuilder map = new StringBuilder(buttons);
                    map[Int32.Parse(Command[i])] = 'T';
                    buttons = map.ToString();
                }

                // Store it in the right position in the array

                form.SetControllerCommands(controllernumber, Command, buttons);
            }
        }

        //--- POLLING ---

        //Creates the StickHandlingLogic Method which takes all the joysticks in the sticks List and puts them into a timer.
        public void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Sticks.Length; i++)
            {
                tm1939StickHandlingLogic(Sticks[i], i);
            }
        }

        void tm1939StickHandlingLogic(Joystick stick, int id)
        {
            // Creates an object from the class JoystickState.
            JoystickState state = new JoystickState();

            state = stick.GetCurrentState(); //Gets the state of the joystick

            bool[] buttons = state.GetButtons(); // Stores the number of each button on the gamepad into the bool[] butons.

            String strButtonMap = tm1939GetButtonMap(buttons, id);

            form.UseButtonMap(id, strButtonMap);
        }

        private string tm1939GetButtonMap(bool[] inButtons, int iController)
        {
            string strReturn = "";
            string strState = "";
            tm1939strText[iController] = "";


            for (int i = 0; i < maxbuttons; i++)
            {
                strState = "F";
                if (inButtons[i] == true)
                {
                    strState = "T";
                    tm1939strText[iController] += i.ToString("00 ", CultureInfo.CurrentCulture);
                }
                strReturn += strState;
            }
            return strReturn;
        }

        public string GetText(int i)
        {
            return tm1939strText[0];
        }
    }
}
