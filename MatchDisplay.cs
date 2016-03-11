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
        public GamePadControl[] Pads;
        bool SavePromptActive = false;

        public MatchDisplay()
        {
            InitializeComponent();
            Pads = new GamePadControl[] { gamePad1, gamePad2, gamePad3, gamePad4, gamePad5, gamePad6 };

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

        public void SetControllerCommands(int controllernumber, string[] Command, string buttons)
        {
            var pad = Pads[controllernumber];
            var controllerCommands = pad.ControllerCommands;
            switch (Command[0].ToUpper())  //In this section, case names should be all uppercase
            {
                case "TELEOP":
                    controllerCommands[GameCommands.TeleOp] = buttons;
                    break;
                case "AUTONOMOUS":
                    controllerCommands[GameCommands.Autonomous] = buttons;
                    break;
                case "DEFENSIVERATINGPLUS":
                    controllerCommands[GameCommands.scoreHigh] = buttons;
                    break;
                case "DEFENSIVERATINGMINUS":
                    controllerCommands[GameCommands.scoreLow] = buttons;
                    break;
                case "DEFENSE1CROSSMINUS":
                    controllerCommands[GameCommands.Defense1CrossMinus] = buttons;
                    break;
                case "DEFENSE1CROSSPLUS":
                    controllerCommands[GameCommands.Defense1CrossPlus] = buttons;
                    break;
                case "DEFENSE1ATTMINUS":
                    controllerCommands[GameCommands.Defense1AttMinus] = buttons;
                    break;
                case "DEFENSE1ATTPLUS":
                    controllerCommands[GameCommands.Defense1AttPlus] = buttons;
                    break;
                case "DEFENSE2CROSSMINUS":
                    controllerCommands[GameCommands.Defense2CrossMinus] = buttons;
                    break;
                case "DEFENSE2CROSSPLUS":
                    controllerCommands[GameCommands.Defense2CrossPlus] = buttons;
                    break;
                case "DEFENSE2ATTMINUS":
                    controllerCommands[GameCommands.Defense2AttMinus] = buttons;
                    break;
                case "DEFENSE2ATTPLUS":
                    controllerCommands[GameCommands.Defense2AttPlus] = buttons;
                    break;
                case "MIDFRISBEESMADEMINUS":
                    controllerCommands[GameCommands.MidFrisbeesMadeMinus] = buttons;
                    break;
                case "MIDFRISBEESMADEPLUS":
                    controllerCommands[GameCommands.MidFrisbeesMadePlus] = buttons;
                    break;
                case "MIDFRISBEESATTMINUS":
                    controllerCommands[GameCommands.MidFrisbeesAttMinus] = buttons;
                    break;
                case "MIDFRISBEESATTPLUS":
                    controllerCommands[GameCommands.MidFrisbeesAttPlus] = buttons;
                    break;
                case "LOWFRISBEESMADEMINUS":
                    controllerCommands[GameCommands.LowFrisbeesMadeMinus] = buttons;
                    break;
                case "LOWFRISBEESMADEPLUS":
                    controllerCommands[GameCommands.LowFrisbeesMadePlus] = buttons;
                    break;
                case "LOWFRISBEESATTMINUS":
                    controllerCommands[GameCommands.LowFrisbeesAttMinus] = buttons;
                    break;
                case "LOWFRISBEESATTPLUS":
                    controllerCommands[GameCommands.LowFrisbeesAttPlus] = buttons;
                    break;
                case "CHALLENGESCALEPLUS":
                    controllerCommands[GameCommands.ChallengeScalePlus] = buttons;
                    break;
                case "FINISHEDSCORING":
                    controllerCommands[GameCommands.FinishedScoring] = buttons;
                    break;
            }
        }

        void IMatchDisplay.UseButtonMap(int controllernumber, string strButtonMap)
        {
            var pad = Pads[controllernumber];
            if (pad.UseButtonMap(strButtonMap))
            {
                var finshedScoringNeedtoSave = true;
                for (int i = 0; i < 6; i++)
                    if (Pads[i].FinshedScoring == false)
                        finshedScoringNeedtoSave = false;
                if (finshedScoringNeedtoSave && SavePromptActive == false)
                {
                    SavePromptActive = true;
                    if (MessageBox.Show("Are you ready to save?", "Save", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        SaveDataBtn.PerformClick();
                        SavePromptActive = false;
                }
            }
        }
    }
}
