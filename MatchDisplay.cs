using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleJoysticks
{
    public partial class MatchDisplay : Form, IMatchDisplay
    {
        public GamePad[] Pads;

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
            Pads = new GamePad[] { gamePad1, gamePad2, gamePad3, gamePad4, gamePad5, gamePad6 };

var gameInput = new GameInput();
            var sticks = gameInput.GetSticks(this);
            if (sticks > 0)
            {
                timer1.Enabled = true;
                timer1.Tick += gameInput.timer1_Tick;
            }
            else
            {
<<<<<<< HEAD
                MessageBox.Show("No controllers were found... for some reason.", "         *Sigh*", MessageBoxButtons.OK);
=======
                MessageBox.Show("No controllers were+ found... for some reason.", "         *Sigh*", MessageBoxButtons.OK);
>>>>>>> origin/User-controls
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
        //--------------------- BUTTON CLICKS -------

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    MessageBox.Show(saveFileDialog1.FileName);
                    fileName = saveFileDialog1.FileName;
                    tm1939SaveFile(sw);
                    sw.Close();
                }
                //Increases match Number
                match++;
                lblmatch.Text = match.ToString();

                //Updates the team # automatically when a new match starts.
                Pads[0].lblAutoTeamNo.Text = AutoTeamNo1[match - 1].ToString();
                Pads[1].lblAutoTeamNo.Text = AutoTeamNo2[match - 1].ToString();
                Pads[2].lblAutoTeamNo.Text = AutoTeamNo3[match - 1].ToString();
                Pads[3].lblAutoTeamNo.Text = AutoTeamNo4[match - 1].ToString();
                Pads[4].lblAutoTeamNo.Text = AutoTeamNo5[match - 1].ToString();
                Pads[5].lblAutoTeamNo.Text = AutoTeamNo6[match - 1].ToString();

                for (int f = 0; f < 6; f++)
                {
                    var pad = Pads[f];
                    pad.Clear();
                }
            }
        }

        //The following code updates the time and the date.
        private void tmrtime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String myFileName = fileName;
            StreamWriter sww = File.AppendText(myFileName);
            tm1939SaveFile(sww);

            sww.Close();
            //Increases match Number
            match++;
            lblmatch.Text = match.ToString();

            //Updates the team # automatically when a new match starts.
            Pads[0].lblAutoTeamNo.Text = AutoTeamNo1[match - 1].ToString();
            Pads[1].lblAutoTeamNo.Text = AutoTeamNo2[match - 1].ToString();
            Pads[2].lblAutoTeamNo.Text = AutoTeamNo3[match - 1].ToString();
            Pads[3].lblAutoTeamNo.Text = AutoTeamNo4[match - 1].ToString();
            Pads[4].lblAutoTeamNo.Text = AutoTeamNo5[match - 1].ToString();
            Pads[5].lblAutoTeamNo.Text = AutoTeamNo6[match - 1].ToString();

            for (int f = 0; f < 6; f++)
            {
                var pad = Pads[f];
                pad.Clear();
            }
        }

        private void tm1939SaveFile(StreamWriter outputstream)
        {
            // A single writeline section to handle both save buttons.
            // Added Match to the end of each record
            outputstream.WriteLine(Pads[0].GetResults(lblmatch.Text));
            outputstream.WriteLine(Pads[1].GetResults(lblmatch.Text));
            outputstream.WriteLine(Pads[2].GetResults(lblmatch.Text));
            outputstream.WriteLine(Pads[3].GetResults(lblmatch.Text));
            outputstream.WriteLine(Pads[4].GetResults(lblmatch.Text));
            outputstream.WriteLine(Pads[5].GetResults(lblmatch.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                String test = sr.ReadToEnd();
                String[] newTeams = test.Split(',');
                int countAgain = newTeams.Length;
                teamsNotePad = new string[countAgain];
                newTeams.CopyTo(teamsNotePad, 0);
                autoTeams = teamsNotePad.Length;
                int teamsDivide = teamsNotePad.Length / 6;

                DialogResult dialogResult = MessageBox.Show(teamsDivide.ToString() + "\n Is this the correct number of matches?", "Adding Teams", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sr.Close();

                    AutoTeamNo1 = new int[autoTeams];
                    AutoTeamNo2 = new int[autoTeams];
                    AutoTeamNo3 = new int[autoTeams];
                    AutoTeamNo4 = new int[autoTeams];
                    AutoTeamNo5 = new int[autoTeams];
                    AutoTeamNo6 = new int[autoTeams];
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Check your text file with the schedule to make sure it is right!");
                    System.Environment.Exit(0);
                }
            }

            int count = 0;
            for (int j = 0; j < teamsNotePad.Length / 6; j++)
            {
                AutoTeamNo1[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
                AutoTeamNo2[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
                AutoTeamNo3[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
                AutoTeamNo4[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
                AutoTeamNo5[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
                AutoTeamNo6[j] = Convert.ToInt32(teamsNotePad[count]);
                count++;
            }

            Pads[0].lblAutoTeamNo.Text = AutoTeamNo1[0].ToString();
            Pads[1].lblAutoTeamNo.Text = AutoTeamNo2[0].ToString();
            Pads[2].lblAutoTeamNo.Text = AutoTeamNo3[0].ToString();
            Pads[3].lblAutoTeamNo.Text = AutoTeamNo4[0].ToString();
            Pads[4].lblAutoTeamNo.Text = AutoTeamNo5[0].ToString();
            Pads[5].lblAutoTeamNo.Text = AutoTeamNo6[0].ToString();
        }

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

            Pads[0].lblAutoTeamNo.Text = AutoTeamNo1[match - 1].ToString();
            Pads[1].lblAutoTeamNo.Text = AutoTeamNo2[match - 1].ToString();
            Pads[2].lblAutoTeamNo.Text = AutoTeamNo3[match - 1].ToString();
            Pads[3].lblAutoTeamNo.Text = AutoTeamNo4[match - 1].ToString();
            Pads[4].lblAutoTeamNo.Text = AutoTeamNo5[match - 1].ToString();
            Pads[5].lblAutoTeamNo.Text = AutoTeamNo6[match - 1].ToString();
        }
    }
}
