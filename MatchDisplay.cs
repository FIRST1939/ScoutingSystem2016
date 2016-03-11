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

        // Declaration of auto-filled team numbers.
        static int autoTeams = 0;
        int[] AutoTeamNo1;
        int[] AutoTeamNo2;
        int[] AutoTeamNo3;
        int[] AutoTeamNo4;
        int[] AutoTeamNo5;
        int[] AutoTeamNo6;

        //Keeps track of the match.
        static int match = 1;

        String fileName = "test1";
        String[] teamsNotePad;
        String x = ",";
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
            var ControllerCommands = pad.ControllerCommands;
            switch (Command[0].ToUpper())  //In this section, case names should be all uppercase
            {
                case "TELEOP":
                    ControllerCommands[GameCommands.TeleOp] = buttons;
                    break;
                case "AUTONOMOUS":
                    ControllerCommands[GameCommands.Autonomous] = buttons;
                    break;
                case "DEFENSIVERATINGPLUS":
                    ControllerCommands[GameCommands.scoreHigh] = buttons;
                    break;
                case "DEFENSIVERATINGMINUS":
                    ControllerCommands[GameCommands.scoreLow] = buttons;
                    break;
                case "DEFENSE1CROSSMINUS":
                    ControllerCommands[GameCommands.Defense1CrossMinus] = buttons;
                    break;
                case "DEFENSE1CROSSPLUS":
                    ControllerCommands[GameCommands.Defense1CrossPlus] = buttons;
                    break;
                case "DEFENSE1ATTMINUS":
                    ControllerCommands[GameCommands.Defense1AttMinus] = buttons;
                    break;
                case "DEFENSE1ATTPLUS":
                    ControllerCommands[GameCommands.Defense1AttPlus] = buttons;
                    break;
                case "DEFENSE2CROSSMINUS":
                    ControllerCommands[GameCommands.Defense2CrossMinus] = buttons;
                    break;
                case "DEFENSE2CROSSPLUS":
                    ControllerCommands[GameCommands.Defense2CrossPlus] = buttons;
                    break;
                case "DEFENSE2ATTMINUS":
                    ControllerCommands[GameCommands.Defense2AttMinus] = buttons;
                    break;
                case "DEFENSE2ATTPLUS":
                    ControllerCommands[GameCommands.Defense2AttPlus] = buttons;
                    break;
                case "DEFENSE3CROSSMINUS":
                    ControllerCommands[GameCommands.Defense3CrossMinus] = buttons;
                    break;
                case "DEFENSE3CROSSPLUS":
                    ControllerCommands[GameCommands.Defense3CrossPlus] = buttons;
                    break;
                case "DEFENSE3ATTMINUS":
                    ControllerCommands[GameCommands.Defense3AttMinus] = buttons;
                    break;
                case "DEFENSE3ATTPLUS":
                    ControllerCommands[GameCommands.Defense3AttPlus] = buttons;
                    break;
                case "DEFENSE4CROSSMINUS":
                    ControllerCommands[GameCommands.Defense4CrossMinus] = buttons;
                    break;
                case "DEFENSE4CROSSPLUS":
                    ControllerCommands[GameCommands.Defense4CrossPlus] = buttons;
                    break;
                case "DEFENSE4ATTMINUS":
                    ControllerCommands[GameCommands.Defense4AttMinus] = buttons;
                    break;
                case "DEFENSE4ATTPLUS":
                    ControllerCommands[GameCommands.Defense4AttPlus] = buttons;
                    break;
                case "DEFENSE5CROSSMINUS":
                    ControllerCommands[GameCommands.Defense5CrossMinus] = buttons;
                    break;
                case "DEFENSE5CROSSPLUS":
                    ControllerCommands[GameCommands.Defense5CrossPlus] = buttons;
                    break;
                case "DEFENSE5ATTMINUS":
                    ControllerCommands[GameCommands.Defense5AttMinus] = buttons;
                    break;
                case "DEFENSE5ATTPLUS":
                    ControllerCommands[GameCommands.Defense5AttPlus] = buttons;
                    break;
                case "HIGHSHOTMADEMINUS":
                    ControllerCommands[GameCommands.HighShotMadeMinus] = buttons;
                    break;
                case "HIGHSHOTMADEPLUS":
                    ControllerCommands[GameCommands.HighShotMadePlus] = buttons;
                    break;
                case "HIGHSHOTATTMINUS":
                    ControllerCommands[GameCommands.HighShotAttMinus] = buttons;
                    break;
                case "HIGHSHOTATTPLUS":
                    ControllerCommands[GameCommands.HighShotAttPlus] = buttons;
                    break;
                case "LOWSHOTMADEMINUS":
                    ControllerCommands[GameCommands.LowShotMadeMinus] = buttons;
                    break;
                case "LOWSHOTMADEPLUS":
                    ControllerCommands[GameCommands.LowShotMadePlus] = buttons;
                    break;
                case "LOWSHOTATTMINUS":
                    ControllerCommands[GameCommands.LowShotAttMinus] = buttons;
                    break;
                case "LOWSHOTATTPLUS":
                    ControllerCommands[GameCommands.LowShotAttPlus] = buttons;
                    break;
                case "CHALLENGESCALEPLUS":
                    ControllerCommands[GameCommands.ChallengeScalePlus] = buttons;
                    break;
                case "FINISHEDSCORING":
                    ControllerCommands[GameCommands.FinishedScoring] = buttons;
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
        //--------------------- SAVE -------

        private void button4_Click(object sender, EventArgs e)
        {
            lblEvent.Text = textBox1.Text;
            button4.Visible = false;
            btnSkip.Visible = true;
            textBox1.Clear();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            int skip = Convert.ToInt32(textBox1.Text);
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
            }
            match = skip;
            lblmatch.Text = match.ToString();
            //TODO
            //lblAutoTeamNo1.Text = AutoTeamNo1[match - 1].ToString();
            //lblAutoTeamNo2.Text = AutoTeamNo2[match - 1].ToString();
            //lblAutoTeamNo3.Text = AutoTeamNo3[match - 1].ToString();
            //lblAutoTeamNo4.Text = AutoTeamNo4[match - 1].ToString();
            //lblAutoTeamNo5.Text = AutoTeamNo5[match - 1].ToString();
            //lblAutoTeamNo6.Text = AutoTeamNo6[match - 1].ToString();
        }
    }
}
