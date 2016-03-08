using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace MultipleJoysticks
{
    public partial class Form1 : Form
    {
        bool[] AutonomousMode = { true, true, true, true, true, true };
        bool[] TeleOp = { false, false, false, false, false, false };
        bool[] FinshedScoring = { false, false, false, false, false, false };

        //Arrays that hold the values for the made and attempt numbers of the frisbee scoring
        // 1 point frisbees
        int[] displayDefSlot4Made = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot4Made = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefSlot4Att = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot4Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot4Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot4Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot4Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot4Att = { 0, 0, 0, 0, 0, 0 };

        // 2 point frisbees
        int[] displayDefSlot3Made = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot3Made = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefSlot3Att = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot3Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot3Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot3Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot3Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot3Att = { 0, 0, 0, 0, 0, 0 };

        // 3 point frisbees
        int[] displayDefSlot2Made = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot2Made = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefSlot2Att = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot2Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot2Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot2Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot2Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot2Att = { 0, 0, 0, 0, 0, 0 };

        // Pyramid Frisbees
        int[] displayDefSlot1Made = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot1Made = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefSlot1Att = { 0, 0, 0, 0, 0, 0 };
        int[] DefSlot1Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot1Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot1Made = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefSlot1Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefSlot1Att = { 0, 0, 0, 0, 0, 0 };

        // Robot Scaleing
        int[] scale = { 0, 0, 0, 0, 0, 0 };
        int[] robotScale = { 0, 0, 0, 0, 0, 0 };

        // Total Points
        int[] teleOpTotalPoints = { 0, 0, 0, 0, 0, 0 };
        int[] autoTotalPoints = { 0, 0, 0, 0, 0, 0 };

        // Defense Ratings
        int[] defenseRating = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefenseRating = { 0, 0, 0, 0, 0, 0 };

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

        struct GameCommands
        {
            public const int TeleOp = 0;
            public const int Autonomous = 1;
            public const int scoreHigh = 2;
            public const int scoreLow = 3;
            public const int DefSlot1MadeMinus = 4;
            public const int DefSlot1MadePlus = 5;
            public const int DefSlot1AttMinus = 6;
            public const int DefSlot1AttPlus = 7;
            public const int DefSlot2MadeMinus = 8;
            public const int DefSlot2MadePlus = 9;
            public const int DefSlot2AttMinus = 10;
            public const int DefSlot2AttPlus = 11;
            public const int DefSlot3MadeMinus = 12;
            public const int DefSlot3MadePlus = 13;
            public const int DefSlot3AttMinus = 14;
            public const int DefSlot3AttPlus = 15;
            public const int DefSlot4MadeMinus = 16;
            public const int DefSlot4MadePlus = 17;
            public const int DefSlot4AttMinus = 18;
            public const int DefSlot4AttPlus = 19;
            public const int RobotScalePlus = 20;
            public const int FinishedScoring = 21;
        }

        String[,] ControllerCommands = new String[6, 22];
        String[] LastButtonPattern = new String[6];
        Label[] displayButtons;


        // --- INITIALIZATION
        public Form1()
        {
            InitializeComponent();
            displayButtons = new[] { lbldisplayButtons1, lbldisplayButtons2, lbldisplayButtons3, lbldisplayButtons4, lbldisplayButtons5, lbldisplayButtons6 };

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
            switch (Command[0].ToUpper())  //Case name should be all caps
            {
                case "TELEOP":
                    ControllerCommands[controllernumber, Form1.GameCommands.TeleOp] = buttons;
                    break;
                case "AUTONOMOUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Autonomous] = buttons;
                    break;
                case "DEFENSIVERATINGPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.scoreHigh] = buttons;
                    break;
                case "DEFENSIVERATINGMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.scoreLow] = buttons;
                    break;
                case "DEFSLOT1MADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot1MadeMinus] = buttons;
                    break;
                case "DEFSLOT1MADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot1MadePlus] = buttons;
                    break;
                case "DEFSLOT1ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot1AttMinus] = buttons;
                    break;
                case "DEFSLOT1ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot1AttPlus] = buttons;
                    break;
                case "DEFSLOT2MADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot2MadeMinus] = buttons;
                    break;
                case "DEFSLOT2MADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot2MadePlus] = buttons;
                    break;
                case "DEFSLOT2ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot2AttMinus] = buttons;
                    break;
                case "DEFSLOT2ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot2AttPlus] = buttons;
                    break;
                case "DEFSLOT3MADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot3MadeMinus] = buttons;
                    break;
                case "DEFSLOT3MADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot3MadePlus] = buttons;
                    break;
                case "DEFSLOT3ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot3AttMinus] = buttons;
                    break;
                case "DEFSLOT3ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot3AttPlus] = buttons;
                    break;
                case "DEFSLOT4MADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot4MadeMinus] = buttons;
                    break;
                case "DEFSLOT4MADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot4MadePlus] = buttons;
                    break;
                case "DEFSLOT4ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot4AttMinus] = buttons;
                    break;
                case "DEFSLOT4ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.DefSlot4AttPlus] = buttons;
                    break;
                case "ROBOTSCALEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.RobotScalePlus] = buttons;
                    break;
                case "FINISHEDSCORING":
                    ControllerCommands[controllernumber, Form1.GameCommands.FinishedScoring] = buttons;
                    break;
            }
        }

        // --- OPPERATION

        public void UseButtonMap(int id, string strButtonMap)
        {
            bool FinshedScoringNeedtoSave = true;

            if (!strButtonMap.Equals(LastButtonPattern[id]))
            {
                tm1939ProcessButton(strButtonMap, id);
                LastButtonPattern[id] = strButtonMap;
                for (int i = 0; i < 6; i++)
                    if (FinshedScoring[i] == false)
                        FinshedScoringNeedtoSave = false;
                if (FinshedScoringNeedtoSave && SavePromptActive == false)
                {
                    SavePromptActive = true;
                    if (MessageBox.Show("Are you ready to save?", "Save", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        SaveDataBtn.PerformClick();
                    SavePromptActive = false;
                }
                UpdateScores(id);
                tm1939RefreshScreen(id);
            }
        }

        void UpdateScores(int id)
        {
            autoTotalPoints[id] = (autoDefSlot2Made[id] * 6) +
                    (autoDefSlot3Made[id] * 4) +
                    (autoDefSlot4Made[id] * 2);
            teleOpTotalPoints[id] = (DefSlot1Made[id] * 5) +
                    (DefSlot2Made[id] * 3) +
                    (DefSlot3Made[id] * 2) +
                    DefSlot4Made[id];

        }

        void tm1939RefreshScreen(int id)
        {
            switch (id)
            {
                case 0:
                    tm1939UpdateController0();
                    break;

                case 1:
                    tm1939UpdateController1();
                    break;

                case 2:
                    tm1939UpdateController2();
                    break;

                case 3:
                    tm1939UpdateController3();
                    break;

                case 4:
                    tm1939UpdateController4();
                    break;

                case 5:
                    tm1939UpdateController5();
                    break;
            }

        }
        void tm1939UpdateController0()
        {
            if (TeleOp[0])
            {
                lblAuto.Visible = false;
                lblTeleOp.Visible = true;
                lblAutoDefSlot2Att.Visible = false;
                lblTeleOpDefSlot2Att.Visible = true;
                lblAutoDefSlot2Made.Visible = false;
                lblTeleOpDefSlot2Made.Visible = true;
                lblAutoDefSlot3Att.Visible = false;
                lblTeleOpDefSlot3Att.Visible = true;
                lblAutoDefSlot3Made.Visible = false;
                lblTeleOpDefSlot3Made.Visible = true;
                lblAutoDefSlot4Att.Visible = false;
                lblTeleOpDefSlot4Att.Visible = true;
                lblAutoDefSlot4Made.Visible = false;
                lblTeleOpDefSlot4Made.Visible = true;
                lblAutoDefSlot1Att.Visible = false;
                lblAutoDefSlot1Made.Visible = false;
                lblTeleOpDefSlot1Att.Visible = true;
                lblTeleOpDefSlot1Made.Visible = true;
                lblRobotScale.Visible = true;
            }
            if (AutonomousMode[0])
            {
                lblAuto.Visible = true;
                lblTeleOp.Visible = false;
                lblAutoDefSlot2Att.Visible = true;
                lblTeleOpDefSlot2Att.Visible = false;
                lblAutoDefSlot2Made.Visible = true;
                lblTeleOpDefSlot2Made.Visible = false;
                lblAutoDefSlot3Att.Visible = true;
                lblTeleOpDefSlot3Att.Visible = false;
                lblAutoDefSlot3Made.Visible = true;
                lblTeleOpDefSlot3Made.Visible = false;
                lblAutoDefSlot4Att.Visible = true;
                lblTeleOpDefSlot4Att.Visible = false;
                lblAutoDefSlot4Made.Visible = true;
                lblTeleOpDefSlot4Made.Visible = false;
                lblAutoDefSlot1Att.Visible = true;
                lblAutoDefSlot1Made.Visible = true;
                lblTeleOpDefSlot1Att.Visible = false;
                lblTeleOpDefSlot1Made.Visible = false;
                lblRobotScale.Visible = false;
            }
            //Defense Rating
            lblDefense.Text = displayDefenseRating[0].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made.Text = displayDefSlot1Made[0].ToString();
            lblTeleOpDefSlot1Att.Text = displayDefSlot1Att[0].ToString();
            lblAutoDefSlot2Made.Text = autoDisplayDefSlot1Made[0].ToString();
            lblAutoDefSlot2Att.Text = autoDisplayDefSlot1Att[0].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made.Text = displayDefSlot2Made[0].ToString();
            lblTeleOpDefSlot2Att.Text = displayDefSlot2Att[0].ToString();
            lblAutoDefSlot2Made.Text = autoDisplayDefSlot2Made[0].ToString();
            lblAutoDefSlot2Att.Text = autoDisplayDefSlot2Att[0].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made.Text = displayDefSlot3Made[0].ToString();
            lblTeleOpDefSlot3Att.Text = displayDefSlot3Att[0].ToString();
            lblAutoDefSlot3Made.Text = autoDisplayDefSlot3Made[0].ToString();
            lblAutoDefSlot3Att.Text = autoDisplayDefSlot3Att[0].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made.Text = displayDefSlot4Made[0].ToString();
            lblTeleOpDefSlot4Att.Text = displayDefSlot4Att[0].ToString();
            lblAutoDefSlot4Made.Text = autoDisplayDefSlot4Made[0].ToString();
            lblAutoDefSlot4Att.Text = autoDisplayDefSlot4Att[0].ToString();

            // Robot Scale
            lblRobotScale.Text = robotScale[0].ToString();

            lblTeleOpTotalPoints.Text = teleOpTotalPoints[0].ToString();
            lblAutoTotalPoints.Text = autoTotalPoints[0].ToString();
            lblTotalPoints.Text = (autoTotalPoints[0] + teleOpTotalPoints[0] + robotScale[0]).ToString();
            if (FinshedScoring[0])
                lblTeleOp.ForeColor = Color.DarkGreen;
            else
                lblTeleOp.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));



        }
        void tm1939UpdateController1()
        {
            if (TeleOp[1])
            {
                lblAuto2.Visible = false;
                lblTeleOp2.Visible = true;
                lblAutoDefSlot2Att2.Visible = false;
                lblTeleOpDefSlot2Att2.Visible = true;
                lblAutoDefSlot2Made2.Visible = false;
                lblTeleOpDefSlot2Made2.Visible = true;
                lblAutoDefSlot3Att2.Visible = false;
                lblTeleOpDefSlot3Att2.Visible = true;
                lblAutoDefSlot3Made2.Visible = false;
                lblTeleOpDefSlot3Made2.Visible = true;
                lblAutoDefSlot4Att2.Visible = false;
                lblTeleOpDefSlot4Att2.Visible = true;
                lblAutoDefSlot4Made2.Visible = false;
                lblTeleOpDefSlot4Made2.Visible = true;
                lblAutoDefSlot1Att2.Visible = false;
                lblAutoDefSlot1Made2.Visible = false;
                lblAutoDefSlot1Att2.Visible = true;
                lblAutoDefSlot1Made2.Visible = true;
                lblRobotScale2.Visible = true;
            }
            if (AutonomousMode[1])
            {
                lblAuto2.Visible = true;
                lblTeleOp2.Visible = false;
                lblAutoDefSlot2Att2.Visible = true;
                lblTeleOpDefSlot2Att2.Visible = false;
                lblAutoDefSlot2Made2.Visible = true;
                lblTeleOpDefSlot2Made2.Visible = false;
                lblAutoDefSlot3Att2.Visible = true;
                lblTeleOpDefSlot3Att2.Visible = false;
                lblAutoDefSlot3Made2.Visible = true;
                lblTeleOpDefSlot3Made2.Visible = false;
                lblAutoDefSlot4Att2.Visible = true;
                lblTeleOpDefSlot4Att2.Visible = false;
                lblAutoDefSlot4Made2.Visible = true;
                lblTeleOpDefSlot4Made2.Visible = false;
                lblAutoDefSlot1Att2.Visible = true;
                lblAutoDefSlot1Made2.Visible = true;
                lblTeleOpDefSlot1Att2.Visible = false;
                lblTeleOpDefSlot1Made2.Visible = false;
                lblRobotScale2.Visible = false;
            }
            //Defense Rating
            lblDefense2.Text = displayDefenseRating[1].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made2.Text = displayDefSlot1Made[1].ToString();
            lblTeleOpDefSlot1Att2.Text = displayDefSlot1Att[1].ToString();
            lblAutoDefSlot1Made2.Text = autoDisplayDefSlot1Made[1].ToString();
            lblAutoDefSlot1Att2.Text = autoDisplayDefSlot1Att[1].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made2.Text = displayDefSlot2Made[1].ToString();
            lblTeleOpDefSlot2Att2.Text = displayDefSlot2Att[1].ToString();
            lblAutoDefSlot2Made2.Text = autoDisplayDefSlot2Made[1].ToString();
            lblAutoDefSlot2Att2.Text = autoDisplayDefSlot2Att[1].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made2.Text = displayDefSlot3Made[1].ToString();
            lblTeleOpDefSlot3Att2.Text = displayDefSlot3Att[1].ToString();
            lblAutoDefSlot3Made2.Text = autoDisplayDefSlot3Made[1].ToString();
            lblAutoDefSlot3Att2.Text = autoDisplayDefSlot3Att[1].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made2.Text = displayDefSlot4Made[1].ToString();
            lblTeleOpDefSlot4Att2.Text = displayDefSlot4Att[1].ToString();
            lblAutoDefSlot4Made2.Text = autoDisplayDefSlot4Made[1].ToString();
            lblAutoDefSlot4Att2.Text = autoDisplayDefSlot4Att[1].ToString();

            // Robot Scale
            lblRobotScale2.Text = robotScale[1].ToString();

            lblTeleOpTotalPoints2.Text = teleOpTotalPoints[1].ToString();
            lblAutoTotalPoints2.Text = autoTotalPoints[1].ToString();
            lblTotalPoints2.Text = (autoTotalPoints[1] + teleOpTotalPoints[1] + robotScale[1]).ToString();
            if (FinshedScoring[1])
                lblTeleOp2.ForeColor = Color.DarkGreen;
            else
                lblTeleOp2.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));


        }
        void tm1939UpdateController2()
        {
            if (TeleOp[2])
            {
                lblAuto3.Visible = false;
                lblTeleOp3.Visible = true;
                lblAutoDefSlot2Att3.Visible = false;
                lblTeleOpDefSlot2Att3.Visible = true;
                lblAutoDefSlot2Made3.Visible = false;
                lblTeleOpDefSlot2Made3.Visible = true;
                lblAutoDefSlot3Att3.Visible = false;
                lblTeleOpDefSlot3Att3.Visible = true;
                lblAutoDefSlot3Made3.Visible = false;
                lblTeleOpDefSlot3Made3.Visible = true;
                lblAutoDefSlot4Att3.Visible = false;
                lblTeleOpDefSlot4Att3.Visible = true;
                lblAutoDefSlot4Made3.Visible = false;
                lblTeleOpDefSlot4Made3.Visible = true;
                lblAutoDefSlot1Att3.Visible = false;
                lblAutoDefSlot1Made3.Visible = false;
                lblTeleOpDefSlot1Att3.Visible = true;
                lblTeleOpDefSlot1Made3.Visible = true;
                lblRobotScale3.Visible = true;
            }
            if (AutonomousMode[2])
            {
                lblAuto3.Visible = true;
                lblTeleOp3.Visible = false;
                lblAutoDefSlot2Att3.Visible = true;
                lblTeleOpDefSlot2Att3.Visible = false;
                lblAutoDefSlot2Made3.Visible = true;
                lblTeleOpDefSlot2Made3.Visible = false;
                lblAutoDefSlot3Att3.Visible = true;
                lblTeleOpDefSlot3Att3.Visible = false;
                lblAutoDefSlot3Made3.Visible = true;
                lblTeleOpDefSlot3Made3.Visible = false;
                lblAutoDefSlot4Att3.Visible = true;
                lblTeleOpDefSlot4Att3.Visible = false;
                lblAutoDefSlot4Made3.Visible = true;
                lblTeleOpDefSlot4Made3.Visible = false;
                lblAutoDefSlot1Att3.Visible = true;
                lblAutoDefSlot1Made3.Visible = true;
                lblTeleOpDefSlot1Att3.Visible = false;
                lblTeleOpDefSlot1Made3.Visible = false;
                lblRobotScale3.Visible = false;
            }
            //Defense Rating
            lblDefense3.Text = displayDefenseRating[2].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made3.Text = displayDefSlot1Made[2].ToString();
            lblTeleOpDefSlot1Att3.Text = displayDefSlot1Att[2].ToString();
            lblAutoDefSlot1Made3.Text = autoDisplayDefSlot1Made[2].ToString();
            lblAutoDefSlot1Att3.Text = autoDisplayDefSlot1Att[2].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made3.Text = displayDefSlot2Made[2].ToString();
            lblTeleOpDefSlot2Att3.Text = displayDefSlot2Att[2].ToString();
            lblAutoDefSlot2Made3.Text = autoDisplayDefSlot2Made[2].ToString();
            lblAutoDefSlot2Att3.Text = autoDisplayDefSlot2Att[2].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made3.Text = displayDefSlot3Made[2].ToString();
            lblTeleOpDefSlot3Att3.Text = displayDefSlot3Att[2].ToString();
            lblAutoDefSlot3Made3.Text = autoDisplayDefSlot3Made[2].ToString();
            lblAutoDefSlot3Att3.Text = autoDisplayDefSlot3Att[2].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made3.Text = displayDefSlot4Made[2].ToString();
            lblTeleOpDefSlot4Att3.Text = displayDefSlot4Att[2].ToString();
            lblAutoDefSlot4Made3.Text = autoDisplayDefSlot4Made[2].ToString();
            lblAutoDefSlot4Att3.Text = autoDisplayDefSlot4Att[2].ToString();

            // Robot Scale
            lblRobotScale3.Text = robotScale[2].ToString();

            lblTeleOpTotalPoints3.Text = teleOpTotalPoints[2].ToString();
            lblAutoTotalPoints3.Text = autoTotalPoints[2].ToString();
            lblTotalPoints3.Text = (autoTotalPoints[2] + teleOpTotalPoints[2] + robotScale[2]).ToString();
            if (FinshedScoring[2])
                lblTeleOp3.ForeColor = Color.DarkGreen;
            else
                lblTeleOp3.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));



        }
        void tm1939UpdateController3()
        {
            if (TeleOp[3])
            {
                lblAuto4.Visible = false;
                lblTeleOp4.Visible = true;
                lblAutoDefSlot2Att4.Visible = false;
                lblTeleOpDefSlot2Att4.Visible = true;
                lblAutoDefSlot2Made4.Visible = false;
                lblTeleOpDefSlot2Made4.Visible = true;
                lblAutoDefSlot3Att4.Visible = false;
                lblTeleOpDefSlot3Att4.Visible = true;
                lblAutoDefSlot3Made4.Visible = false;
                lblTeleOpDefSlot3Made4.Visible = true;
                lblAutoDefSlot4Att4.Visible = false;
                lblTeleOpDefSlot4Att4.Visible = true;
                lblAutoDefSlot4Made4.Visible = false;
                lblTeleOpDefSlot4Made4.Visible = true;
                lblAutoDefSlot1Att4.Visible = false;
                lblAutoDefSlot1Made4.Visible = false;
                lblTeleOpDefSlot1Att4.Visible = true;
                lblTeleOpDefSlot1Made4.Visible = true;
                lblRobotScale4.Visible = true;
            }
            if (AutonomousMode[3])
            {
                lblAuto4.Visible = true;
                lblTeleOp4.Visible = false;
                lblAutoDefSlot2Att4.Visible = true;
                lblTeleOpDefSlot2Att4.Visible = false;
                lblAutoDefSlot2Made4.Visible = true;
                lblTeleOpDefSlot2Made4.Visible = false;
                lblAutoDefSlot3Att4.Visible = true;
                lblTeleOpDefSlot3Att4.Visible = false;
                lblAutoDefSlot3Made4.Visible = true;
                lblTeleOpDefSlot3Made4.Visible = false;
                lblAutoDefSlot4Att4.Visible = true;
                lblTeleOpDefSlot4Att4.Visible = false;
                lblAutoDefSlot4Made4.Visible = true;
                lblTeleOpDefSlot4Made4.Visible = false;
                lblAutoDefSlot1Att4.Visible = true;
                lblAutoDefSlot1Made4.Visible = true;
                lblTeleOpDefSlot1Att4.Visible = false;
                lblTeleOpDefSlot1Made4.Visible = false;
                lblRobotScale4.Visible = false;
            }
            //Defense Rating
            lblDefense4.Text = displayDefenseRating[3].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made4.Text = displayDefSlot1Made[3].ToString();
            lblTeleOpDefSlot1Att4.Text = displayDefSlot1Att[3].ToString();
            lblAutoDefSlot1Made4.Text = autoDisplayDefSlot1Made[3].ToString();
            lblAutoDefSlot1Att4.Text = autoDisplayDefSlot1Att[3].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made4.Text = displayDefSlot2Made[3].ToString();
            lblTeleOpDefSlot2Att4.Text = displayDefSlot2Att[3].ToString();
            lblAutoDefSlot2Made4.Text = autoDisplayDefSlot2Made[3].ToString();
            lblAutoDefSlot2Att4.Text = autoDisplayDefSlot2Att[3].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made4.Text = displayDefSlot3Made[3].ToString();
            lblTeleOpDefSlot3Att4.Text = displayDefSlot3Att[3].ToString();
            lblAutoDefSlot3Made4.Text = autoDisplayDefSlot3Made[3].ToString();
            lblAutoDefSlot3Att4.Text = autoDisplayDefSlot3Att[3].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made4.Text = displayDefSlot4Made[3].ToString();
            lblTeleOpDefSlot4Att4.Text = displayDefSlot4Att[3].ToString();
            lblAutoDefSlot4Made4.Text = autoDisplayDefSlot4Made[3].ToString();
            lblAutoDefSlot4Att4.Text = autoDisplayDefSlot4Att[3].ToString();

            // Robot Scale
            lblRobotScale4.Text = robotScale[3].ToString();

            lblTeleOpTotalPoints4.Text = teleOpTotalPoints[3].ToString();
            lblAutoTotalPoints4.Text = autoTotalPoints[3].ToString();
            lblTotalPoints4.Text = (autoTotalPoints[3] + teleOpTotalPoints[3] + robotScale[3]).ToString();
            if (FinshedScoring[3])
                lblTeleOp4.ForeColor = Color.DarkGreen;
            else
                lblTeleOp4.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));



        }
        void tm1939UpdateController4()
        {
            if (TeleOp[4])
            {
                lblAuto5.Visible = false;
                lblTeleOp5.Visible = true;
                lblAutoDefSlot2Att5.Visible = false;
                lblTeleOpDefSlot2Att5.Visible = true;
                lblAutoDefSlot2Made5.Visible = false;
                lblTeleOpDefSlot2Made5.Visible = true;
                lblAutoDefSlot3Att5.Visible = false;
                lblTeleOpDefSlot3Att5.Visible = true;
                lblAutoDefSlot3Made5.Visible = false;
                lblTeleOpDefSlot3Made5.Visible = true;
                lblAutoDefSlot4Att5.Visible = false;
                lblTeleOpDefSlot4Att5.Visible = true;
                lblAutoDefSlot4Made5.Visible = false;
                lblTeleOpDefSlot4Made5.Visible = true;
                lblAutoDefSlot1Att5.Visible = false;
                lblAutoDefSlot1Made5.Visible = false;
                lblTeleOpDefSlot1Att5.Visible = true;
                lblTeleOpDefSlot1Made5.Visible = true;
                lblRobotScale5.Visible = true;
            }
            if (AutonomousMode[4])
            {
                lblAuto5.Visible = true;
                lblTeleOp5.Visible = false;
                lblAutoDefSlot2Att5.Visible = true;
                lblTeleOpDefSlot2Att5.Visible = false;
                lblAutoDefSlot2Made5.Visible = true;
                lblTeleOpDefSlot2Made5.Visible = false;
                lblAutoDefSlot3Att5.Visible = true;
                lblTeleOpDefSlot3Att5.Visible = false;
                lblAutoDefSlot3Made5.Visible = true;
                lblTeleOpDefSlot3Made5.Visible = false;
                lblAutoDefSlot4Att5.Visible = true;
                lblTeleOpDefSlot4Att5.Visible = false;
                lblAutoDefSlot4Made5.Visible = true;
                lblTeleOpDefSlot4Made5.Visible = false;
                lblAutoDefSlot1Att5.Visible = true;
                lblAutoDefSlot1Made5.Visible = true;
                lblTeleOpDefSlot1Att5.Visible = false;
                lblTeleOpDefSlot1Made5.Visible = false;
                lblRobotScale5.Visible = false;
            }
            //Defense Rating
            lblDefense5.Text = displayDefenseRating[4].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made5.Text = displayDefSlot1Made[4].ToString();
            lblTeleOpDefSlot1Att5.Text = displayDefSlot1Att[4].ToString();
            lblAutoDefSlot1Made5.Text = autoDisplayDefSlot1Made[4].ToString();
            lblAutoDefSlot1Att5.Text = autoDisplayDefSlot1Att[4].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made5.Text = displayDefSlot2Made[4].ToString();
            lblTeleOpDefSlot2Att5.Text = displayDefSlot2Att[4].ToString();
            lblAutoDefSlot2Made5.Text = autoDisplayDefSlot2Made[4].ToString();
            lblAutoDefSlot2Att5.Text = autoDisplayDefSlot2Att[4].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made5.Text = displayDefSlot3Made[4].ToString();
            lblTeleOpDefSlot3Att5.Text = displayDefSlot3Att[4].ToString();
            lblAutoDefSlot3Made5.Text = autoDisplayDefSlot3Made[4].ToString();
            lblAutoDefSlot3Att5.Text = autoDisplayDefSlot3Att[4].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made5.Text = displayDefSlot4Made[4].ToString();
            lblTeleOpDefSlot4Att5.Text = displayDefSlot4Att[4].ToString();
            lblAutoDefSlot4Made5.Text = autoDisplayDefSlot4Made[4].ToString();
            lblAutoDefSlot4Att5.Text = autoDisplayDefSlot4Att[4].ToString();

            // Robot Scale
            lblRobotScale5.Text = robotScale[4].ToString();

            lblTeleOpTotalPoints5.Text = teleOpTotalPoints[4].ToString();
            lblAutoTotalPoints5.Text = autoTotalPoints[4].ToString();
            lblTotalPoints5.Text = (autoTotalPoints[4] + teleOpTotalPoints[4] + robotScale[4]).ToString();

            if (FinshedScoring[4])
                lblTeleOp5.ForeColor = Color.DarkGreen;
            else
                lblTeleOp5.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));


        }
        void tm1939UpdateController5()
        {
            if (TeleOp[5])
            {
                lblAuto6.Visible = false;
                lblTeleOp6.Visible = true;
                lblAutoDefSlot2Att6.Visible = false;
                lblTeleOpDefSlot2Att6.Visible = true;
                lblAutoDefSlot2Made6.Visible = false;
                lblTeleOpDefSlot2Made6.Visible = true;
                lblAutoDefSlot3Att6.Visible = false;
                lblTeleOpDefSlot3Att6.Visible = true;
                lblAutoDefSlot3Made6.Visible = false;
                lblTeleOpDefSlot3Made6.Visible = true;
                lblAutoDefSlot4Att6.Visible = false;
                lblTeleOpDefSlot4Att6.Visible = true;
                lblAutoDefSlot4Made6.Visible = false;
                lblTeleOpDefSlot4Made6.Visible = true;
                lblAutoDefSlot1Att6.Visible = false;
                lblAutoDefSlot1Made6.Visible = false;
                lblTeleOpDefSlot1Att6.Visible = true;PyraDefense Slot 3 Crossings
                lblTeleOpDefSlot1Made6.Visible = true;
                lblRobotScale6.Visible = true;
            }
            if (AutonomousMode[5])
            {
                lblAuto6.Visible = true;
                lblTeleOp6.Visible = false;
                lblAutoDefSlot2Att6.Visible = true;
                lblTeleOpDefSlot2Att6.Visible = false;
                lblAutoDefSlot2Made6.Visible = true;
                lblTeleOpDefSlot2Made6.Visible = false;
                lblAutoDefSlot3Att6.Visible = true;
                lblTeleOpDefSlot3Att6.Visible = false;
                lblAutoDefSlot3Made6.Visible = true;
                lblTeleOpDefSlot3Made6.Visible = false;
                lblAutoDefSlot4Att6.Visible = true;
                lblTeleOpDefSlot4Att6.Visible = false;
                lblAutoDefSlot4Made6.Visible = true;
                lblTeleOpDefSlot4Made6.Visible = false;
                lblAutoDefSlot1Att6.Visible = true;
                lblAutoDefSlot1Made6.Visible = true;
                lblTeleOpDefSlot1Att6.Visible = false;
                lblTeleOpDefSlot1Made6.Visible = false;
                lblRobotScale6.Visible = false;
            }
            //Defense Rating
            lblDefense6.Text = displayDefenseRating[5].ToString();

            // Defense Slot 1 Crossings
            lblTeleOpDefSlot1Made6.Text = displayDefSlot1Made[5].ToString();
            lblTeleOpDefSlot1Att6.Text = displayDefSlot1Att[5].ToString();
            lblAutoDefSlot1Made6.Text = autoDisplayDefSlot1Made[5].ToString();
            lblAutoDefSlot1Att6.Text = autoDisplayDefSlot1Att[5].ToString();

            // Defense Slot 2 Crossings
            lblTeleOpDefSlot2Made6.Text = displayDefSlot2Made[5].ToString();
            lblTeleOpDefSlot2Att6.Text = displayDefSlot2Att[5].ToString();
            lblAutoDefSlot2Made6.Text = autoDisplayDefSlot2Made[5].ToString();
            lblAutoDefSlot2Att6.Text = autoDisplayDefSlot2Att[5].ToString();

            // Defense Slot 3 Crossings
            lblTeleOpDefSlot3Made6.Text = displayDefSlot3Made[5].ToString();
            lblTeleOpDefSlot3Att6.Text = displayDefSlot3Att[5].ToString();
            lblAutoDefSlot3Made6.Text = autoDisplayDefSlot3Made[5].ToString();
            lblAutoDefSlot3Att6.Text = autoDisplayDefSlot3Att[5].ToString();

            // Defense Slot 4 Crossings
            lblTeleOpDefSlot4Made6.Text = displayDefSlot4Made[5].ToString();
            lblTeleOpDefSlot4Att6.Text = displayDefSlot4Att[5].ToString();
            lblAutoDefSlot4Made6.Text = autoDisplayDefSlot4Made[5].ToString();
            lblAutoDefSlot4Att6.Text = autoDisplayDefSlot4Att[5].ToString();

            // Robot Scale
            lblRobotScale6.Text = robotScale[5].ToString();

            lblTeleOpTotalPoints6.Text = teleOpTotalPoints[5].ToString();
            lblAutoTotalPoints6.Text = autoTotalPoints[5].ToString();
            lblTotalPoints6.Text = (autoTotalPoints[5] + teleOpTotalPoints[5] + robotScale[5]).ToString();

            if (FinshedScoring[5])
                lblTeleOp6.ForeColor = Color.DarkGreen;
            else
                lblTeleOp6.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));


        }
        void tm1939ProcessButton(string strButtonMap, int id)
        {
            int FoundAt;

            // Find where the button maps are equal to get the command
            for (FoundAt = 0; FoundAt < 22 && !strButtonMap.Equals(ControllerCommands[id, FoundAt]); FoundAt++)
            {
            }

            // Perform the appropriate function

            switch (FoundAt)
            {
                case (GameCommands.TeleOp):
                    AutonomousMode[id] = false;
                    TeleOp[id] = true;

                    break;

                case (GameCommands.Autonomous):
                    AutonomousMode[id] = true;
                    TeleOp[id] = false;
                    FinshedScoring[id] = false;
                    break;

                case (GameCommands.scoreHigh):
                    if (TeleOp[id] && defenseRating[id] > 0)
                    {
                        defenseRating[id]--;
                        displayDefenseRating[id] = defenseRating[id];
                    }
                    break;

                case (GameCommands.scoreLow):
                    if (TeleOp[id])
                    {
                        defenseRating[id]++;
                        displayDefenseRating[id] = defenseRating[id];
                        if (displayDefenseRating[id] > 10)
                        {
                            defenseRating[id] = 0;
                            displayDefenseRating[id] = 0;
                        }
                    }

                    break;

                case (GameCommands.DefSlot2AttMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot2Att[id] > 0 && DefSlot2Made[id] < DefSlot2Att[id])
                        {
                            DefSlot2Att[id]--;
                            displayDefSlot2Att[id] = DefSlot2Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot2Att[id] > 0 && autoDefSlot2Made[id] < autoDefSlot2Att[id])
                        {
                            autoDefSlot2Att[id]--;
                            autoDisplayDefSlot2Att[id] = autoDefSlot2Att[id];
                        }
                    }

                    break;

                case (GameCommands.DefSlot2AttPlus):
                    if (TeleOp[id])
                    {
                        DefSlot2Att[id]++;
                        displayDefSlot2Att[id] = DefSlot2Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot2Att[id]++;
                        autoDisplayDefSlot2Att[id] = autoDefSlot2Att[id];
                    }

                    break;

                case (GameCommands.DefSlot2MadeMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot2Made[id] > 0)
                        {
                            DefSlot2Made[id]--;
                            displayDefSlot2Made[id] = DefSlot2Made[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot2Made[id] > 0)
                        {
                            autoDefSlot2Made[id]--;
                            autoDisplayDefSlot2Made[id] = autoDefSlot2Made[id];
                        }
                    }
                    break;

                case (GameCommands.DefSlot2MadePlus):
                    if (TeleOp[id])
                    {
                        DefSlot2Made[id]++;
                        displayDefSlot2Made[id] = DefSlot2Made[id];
                        DefSlot2Att[id]++;
                        displayDefSlot2Att[id] = DefSlot2Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot2Made[id]++;
                        autoDisplayDefSlot2Made[id] = autoDefSlot2Made[id];
                        autoDefSlot2Att[id]++;
                        autoDisplayDefSlot2Att[id] = autoDefSlot2Att[id];
                    }
                    break;

                case (GameCommands.DefSlot4AttMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot4Att[id] > 0 && DefSlot4Made[id] < DefSlot4Att[id])
                        {
                            DefSlot4Att[id]--;
                            displayDefSlot4Att[id] = DefSlot4Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot4Att[id] > 0 && autoDefSlot4Made[id] < autoDefSlot4Att[id])
                        {
                            autoDefSlot4Att[id]--;
                            autoDisplayDefSlot4Att[id] = autoDefSlot4Att[id];
                        }
                    }

                    break;

                case (GameCommands.DefSlot4AttPlus):
                    if (TeleOp[id])
                    {
                        DefSlot4Att[id]++;
                        displayDefSlot4Att[id] = DefSlot4Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot4Att[id]++;
                        autoDisplayDefSlot4Att[id] = autoDefSlot4Att[id];
                    }


                    break;

                case (GameCommands.DefSlot4MadeMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot4Made[id] > 0)
                        {
                            DefSlot4Made[id]--;
                            displayDefSlot4Made[id] = DefSlot4Made[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot4Made[id] > 0)
                        {
                            autoDefSlot4Made[id]--;
                            autoDisplayDefSlot4Made[id] = autoDefSlot4Made[id];
                        }
                    }

                    break;

                case (GameCommands.DefSlot4MadePlus):
                    if (TeleOp[id])
                    {
                        DefSlot4Made[id]++;
                        displayDefSlot4Made[id] = DefSlot4Made[id];
                        DefSlot4Att[id]++;
                        displayDefSlot4Att[id] = DefSlot4Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot4Made[id]++;
                        autoDisplayDefSlot4Made[id] = autoDefSlot4Made[id];
                        autoDefSlot4Att[id]++;
                        autoDisplayDefSlot4Att[id] = autoDefSlot4Att[id];
                    }

                    break;

                case (GameCommands.DefSlot3AttMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot3Att[id] > 0 && DefSlot3Made[id] < DefSlot3Att[id])
                        {
                            DefSlot3Att[id]--;
                            displayDefSlot3Att[id] = DefSlot3Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot3Att[id] > 0 && autoDefSlot3Made[id] < autoDefSlot3Att[id])
                        {
                            autoDefSlot3Att[id]--;
                            autoDisplayDefSlot3Att[id] = autoDefSlot3Att[id];
                        }
                    }
                    break;

                case (GameCommands.DefSlot3AttPlus):
                    if (TeleOp[id])
                    {
                        DefSlot3Att[id]++;
                        displayDefSlot3Att[id] = DefSlot3Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot3Att[id]++;
                        autoDisplayDefSlot3Att[id] = autoDefSlot3Att[id];
                    }


                    break;

                case (GameCommands.DefSlot3MadeMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot3Made[id] > 0)
                        {
                            DefSlot3Made[id]--;
                            displayDefSlot3Made[id] = DefSlot3Made[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot3Made[id] > 0)
                        {
                            autoDefSlot3Made[id]--;
                            autoDisplayDefSlot3Made[id] = autoDefSlot3Made[id];
                        }
                    }

                    break;

                case (GameCommands.DefSlot3MadePlus):
                    if (TeleOp[id])
                    {
                        DefSlot3Made[id]++;
                        displayDefSlot3Made[id] = DefSlot3Made[id];
                        DefSlot3Att[id]++;
                        displayDefSlot3Att[id] = DefSlot3Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot3Made[id]++;
                        autoDisplayDefSlot3Made[id] = autoDefSlot3Made[id];
                        autoDefSlot3Att[id]++;
                        autoDisplayDefSlot3Att[id] = autoDefSlot3Att[id];
                    }

                    break;

                case (GameCommands.DefSlot1AttMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot1Att[id] > 0 && DefSlot1Made[id] < DefSlot1Att[id])
                        {
                            DefSlot1Att[id]--;
                            displayDefSlot1Att[id] = DefSlot1Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot1Att[id] > 0 && autoDefSlot1Made[id] < autoDefSlot1Att[id])
                        {
                            autoDefSlot1Att[id]--;
                            autoDisplayDefSlot1Att[id] = autoDefSlot1Att[id];
                        }
                    }
                    break;

                case (GameCommands.DefSlot1AttPlus):
                    if (TeleOp[id])
                    {
                        DefSlot1Att[id]++;
                        displayDefSlot1Att[id] = DefSlot1Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot1Att[id]++;
                        autoDisplayDefSlot1Att[id] = autoDefSlot1Att[id];
                    }

                    break;

                case (GameCommands.DefSlot1MadeMinus):
                    if (TeleOp[id])
                    {
                        if (DefSlot1Made[id] > 0)
                        {
                            DefSlot1Made[id]--;
                            displayDefSlot1Made[id] = DefSlot1Made[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefSlot1Made[id] > 0)
                        {
                            autoDefSlot1Made[id]--;
                            autoDisplayDefSlot1Made[id] = autoDefSlot1Made[id];
                        }
                    }
                    break;

                case (GameCommands.DefSlot1MadePlus):
                    if (TeleOp[id])
                    {
                        DefSlot1Made[id]++;
                        displayDefSlot1Made[id] = DefSlot1Made[id];
                        DefSlot1Att[id]++;
                        displayDefSlot1Att[id] = DefSlot1Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefSlot1Made[id]++;
                        autoDisplayDefSlot1Made[id] = autoDefSlot1Made[id];
                        autoDefSlot1Att[id]++;
                        autoDisplayDefSlot1Att[id] = autoDefSlot1Att[id];
                    }

                    break;

                case (GameCommands.RobotScalePlus):
                    if (TeleOp[id])
                    {
                        scale[id]++;
                        robotScale[id] = scale[id];

                        if (robotScale[id] > 2)  //Three levels No, Capture, Scale
                        {
                            robotScale[id] = 0;
                            scale[id] = 0;
                        }

                        robotScale[id] = robotScale[id] * 10;
                    }
                    break;
                case (GameCommands.FinishedScoring):
                    FinshedScoring[id] = !FinshedScoring[id];

                    break;

                default:

                    break;
            }

            displayButtons[id].Text = GetButtonDisplay(strButtonMap);
        }

        // List buttons down for display
        private string GetButtonDisplay(string strButtonMap)
        {
            var result = "";
            for (int i = 0; i < strButtonMap.Length; i++)
            {
                if (strButtonMap[i] == 'T')
                {
                    result += i.ToString("00 ", CultureInfo.CurrentCulture);
                }
            }
            return result;
        }

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
                lblAutoTeamNo1.Text = AutoTeamNo1[match - 1].ToString();
                lblAutoTeamNo2.Text = AutoTeamNo2[match - 1].ToString();
                lblAutoTeamNo3.Text = AutoTeamNo3[match - 1].ToString();
                lblAutoTeamNo4.Text = AutoTeamNo4[match - 1].ToString();
                lblAutoTeamNo5.Text = AutoTeamNo5[match - 1].ToString();
                lblAutoTeamNo6.Text = AutoTeamNo6[match - 1].ToString();

                for (int f = 0; f < 6; f++)
                {
                    displayDefSlot4Made[f] = 0;
                    displayDefSlot4Att[f] = 0;
                    DefSlot4Made[f] = 0;
                    DefSlot4Att[f] = 0;
                    autoDisplayDefSlot4Made[f] = 0;
                    autoDefSlot4Made[f] = 0;
                    autoDisplayDefSlot4Att[f] = 0;
                    autoDefSlot4Att[f] = 0;
                    displayDefSlot3Made[f] = 0;
                    DefSlot3Made[f] = 0;
                    displayDefSlot3Att[f] = 0;
                    DefSlot3Att[f] = 0;
                    autoDisplayDefSlot3Made[f] = 0;
                    autoDefSlot3Made[f] = 0;
                    autoDisplayDefSlot3Att[f] = 0;
                    autoDefSlot3Att[f] = 0;
                    displayDefSlot2Made[f] = 0;
                    DefSlot2Made[f] = 0;
                    displayDefSlot2Att[f] = 0;
                    DefSlot2Att[f] = 0;
                    autoDisplayDefSlot2Made[f] = 0;
                    autoDefSlot2Made[f] = 0;
                    autoDisplayDefSlot2Att[f] = 0;
                    autoDefSlot2Att[f] = 0;
                    displayDefSlot1Made[f] = 0;
                    DefSlot1Made[f] = 0;
                    displayDefSlot1Att[f] = 0;
                    DefSlot1Att[f] = 0;
                    autoDisplayDefSlot1Made[f] = 0;
                    autoDefSlot1Made[f] = 0;
                    autoDisplayDefSlot1Att[f] = 0;
                    autoDefSlot1Att[f] = 0;
                    scale[f] = 0;
                    robotScale[f] = 0;
                    teleOpTotalPoints[f] = 0;
                    autoTotalPoints[f] = 0;
                    defenseRating[f] = 0;
                    displayDefenseRating[f] = 0;
                    lblAuto.Visible = true;
                    lblAuto2.Visible = true;
                    lblAuto3.Visible = true;
                    lblAuto4.Visible = true;
                    lblAuto5.Visible = true;
                    lblAuto6.Visible = true;
                    lblTeleOp.Visible = false;
                    lblTeleOp2.Visible = false;
                    lblTeleOp3.Visible = false;
                    lblTeleOp4.Visible = false;
                    lblTeleOp5.Visible = false;
                    lblTeleOp6.Visible = false;
                    lblRobotScale.Visible = false;
                    lblRobotScale2.Visible = false;
                    lblRobotScale3.Visible = false;
                    lblRobotScale4.Visible = false;
                    lblRobotScale5.Visible = false;
                    lblRobotScale6.Visible = false;
                    FinshedScoring[f] = false;
                    tm1939RefreshScreen(f);
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
            lblAutoTeamNo1.Text = AutoTeamNo1[match - 1].ToString();
            lblAutoTeamNo2.Text = AutoTeamNo2[match - 1].ToString();
            lblAutoTeamNo3.Text = AutoTeamNo3[match - 1].ToString();
            lblAutoTeamNo4.Text = AutoTeamNo4[match - 1].ToString();
            lblAutoTeamNo5.Text = AutoTeamNo5[match - 1].ToString();
            lblAutoTeamNo6.Text = AutoTeamNo6[match - 1].ToString();

            for (int f = 0; f < 6; f++)
            {
                displayDefSlot4Made[f] = 0;
                displayDefSlot4Att[f] = 0;
                DefSlot4Made[f] = 0;
                DefSlot4Att[f] = 0;
                autoDisplayDefSlot4Made[f] = 0;
                autoDefSlot4Made[f] = 0;
                autoDisplayDefSlot4Att[f] = 0;
                autoDefSlot4Att[f] = 0;
                displayDefSlot3Made[f] = 0;
                DefSlot3Made[f] = 0;
                displayDefSlot3Att[f] = 0;
                DefSlot3Att[f] = 0;
                autoDisplayDefSlot3Made[f] = 0;
                autoDefSlot3Made[f] = 0;
                autoDisplayDefSlot3Att[f] = 0;
                autoDefSlot3Att[f] = 0;
                displayDefSlot2Made[f] = 0;
                DefSlot2Made[f] = 0;
                displayDefSlot2Att[f] = 0;
                DefSlot2Att[f] = 0;
                autoDisplayDefSlot2Made[f] = 0;
                autoDefSlot2Made[f] = 0;
                autoDisplayDefSlot2Att[f] = 0;
                autoDefSlot2Att[f] = 0;
                displayDefSlot1Made[f] = 0;
                DefSlot1Made[f] = 0;
                displayDefSlot1Att[f] = 0;
                DefSlot1Att[f] = 0;
                autoDisplayDefSlot1Made[f] = 0;
                autoDefSlot1Made[f] = 0;
                autoDisplayDefSlot1Att[f] = 0;
                autoDefSlot1Att[f] = 0;
                scale[f] = 0;
                robotScale[f] = 0;
                teleOpTotalPoints[f] = 0;
                autoTotalPoints[f] = 0;
                defenseRating[f] = 0;
                displayDefenseRating[f] = 0;
                FinshedScoring[f] = false;
                tm1939RefreshScreen(f);
            }
            lblAuto.Visible = true;
            lblAuto2.Visible = true;
            lblAuto3.Visible = true;
            lblAuto4.Visible = true;
            lblAuto5.Visible = true;
            lblAuto6.Visible = true;
            lblTeleOp.Visible = false;
            lblTeleOp2.Visible = false;
            lblTeleOp3.Visible = false;
            lblTeleOp4.Visible = false;
            lblTeleOp5.Visible = false;
            lblTeleOp6.Visible = false;
            lblRobotScale.Visible = false;
            lblRobotScale2.Visible = false;
            lblRobotScale3.Visible = false;
            lblRobotScale4.Visible = false;
            lblRobotScale5.Visible = false;
            lblRobotScale6.Visible = false;
        }

        private void tm1939SaveFile(StreamWriter outputstream)
        {
            // A single writeline section to handle both save buttons.
            // Added Match to the end of each record
            outputstream.WriteLine(lblAutoTeamNo1.Text + x + lblAutoDefSlot1Made.Text + x + lblAutoDefSlot1Att.Text + x + lblAutoDefSlot2Made.Text + x + lblAutoDefSlot2Att.Text + x + lblAutoDefSlot3Made.Text + x + lblAutoDefSlot3Att.Text + x + lblAutoDefSlot4Made.Text + x + lblAutoDefSlot4Att.Text + x + lblAutoTotalPoints.Text + x + lblTeleOpDefSlot1Made.Text + x + lblTeleOpDefSlot1Att.Text + x + lblTeleOpDefSlot2Made.Text + x + lblTeleOpDefSlot2Att.Text + x + lblTeleOpDefSlot3Made.Text + x + lblTeleOpDefSlot3Att.Text + x + lblTeleOpDefSlot4Made.Text + x + lblTeleOpDefSlot4Att.Text + x + lblRobotScale.Text + x + lblTeleOpTotalPoints.Text + x + lblTotalPoints.Text + x + lblDefense.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo2.Text + x + lblAutoDefSlot1Made2.Text + x + lblAutoDefSlot1Att2.Text + x + lblAutoDefSlot2Made2.Text + x + lblAutoDefSlot2Att2.Text + x + lblAutoDefSlot3Made2.Text + x + lblAutoDefSlot3Att2.Text + x + lblAutoDefSlot4Made2.Text + x + lblAutoDefSlot4Att2.Text + x + lblAutoTotalPoints2.Text + x + lblTeleOpDefSlot1Made2.Text + x + lblTeleOpDefSlot1Att2.Text + x + lblTeleOpDefSlot2Made2.Text + x + lblTeleOpDefSlot2Att2.Text + x + lblTeleOpDefSlot3Made2.Text + x + lblTeleOpDefSlot3Att2.Text + x + lblTeleOpDefSlot4Made2.Text + x + lblTeleOpDefSlot4Att2.Text + x + lblRobotScale2.Text + x + lblTeleOpTotalPoints2.Text + x + lblTotalPoints2.Text + x + lblDefense2.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo3.Text + x + lblAutoDefSlot1Made3.Text + x + lblAutoDefSlot1Att3.Text + x + lblAutoDefSlot2Made3.Text + x + lblAutoDefSlot2Att3.Text + x + lblAutoDefSlot3Made3.Text + x + lblAutoDefSlot3Att3.Text + x + lblAutoDefSlot4Made3.Text + x + lblAutoDefSlot4Att3.Text + x + lblAutoTotalPoints3.Text + x + lblTeleOpDefSlot1Made3.Text + x + lblTeleOpDefSlot1Att3.Text + x + lblTeleOpDefSlot2Made3.Text + x + lblTeleOpDefSlot2Att3.Text + x + lblTeleOpDefSlot3Made3.Text + x + lblTeleOpDefSlot3Att3.Text + x + lblTeleOpDefSlot4Made3.Text + x + lblTeleOpDefSlot4Att3.Text + x + lblRobotScale3.Text + x + lblTeleOpTotalPoints3.Text + x + lblTotalPoints3.Text + x + lblDefense3.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo4.Text + x + lblAutoDefSlot1Made4.Text + x + lblAutoDefSlot1Att4.Text + x + lblAutoDefSlot2Made4.Text + x + lblAutoDefSlot2Att4.Text + x + lblAutoDefSlot3Made4.Text + x + lblAutoDefSlot3Att4.Text + x + lblAutoDefSlot4Made4.Text + x + lblAutoDefSlot4Att4.Text + x + lblAutoTotalPoints4.Text + x + lblTeleOpDefSlot1Made4.Text + x + lblTeleOpDefSlot1Att4.Text + x + lblTeleOpDefSlot2Made4.Text + x + lblTeleOpDefSlot2Att4.Text + x + lblTeleOpDefSlot3Made4.Text + x + lblTeleOpDefSlot3Att4.Text + x + lblTeleOpDefSlot4Made4.Text + x + lblTeleOpDefSlot4Att4.Text + x + lblRobotScale4.Text + x + lblTeleOpTotalPoints4.Text + x + lblTotalPoints4.Text + x + lblDefense4.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo5.Text + x + lblAutoDefSlot1Made5.Text + x + lblAutoDefSlot1Att5.Text + x + lblAutoDefSlot2Made5.Text + x + lblAutoDefSlot2Att5.Text + x + lblAutoDefSlot3Made5.Text + x + lblAutoDefSlot3Att5.Text + x + lblAutoDefSlot4Made5.Text + x + lblAutoDefSlot4Att5.Text + x + lblAutoTotalPoints5.Text + x + lblTeleOpDefSlot1Made5.Text + x + lblTeleOpDefSlot1Att5.Text + x + lblTeleOpDefSlot2Made5.Text + x + lblTeleOpDefSlot2Att5.Text + x + lblTeleOpDefSlot3Made5.Text + x + lblTeleOpDefSlot3Att5.Text + x + lblTeleOpDefSlot4Made5.Text + x + lblTeleOpDefSlot4Att5.Text + x + lblRobotScale5.Text + x + lblTeleOpTotalPoints5.Text + x + lblTotalPoints5.Text + x + lblDefense5.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo6.Text + x + lblAutoDefSlot1Made6.Text + x + lblAutoDefSlot1Att6.Text + x + lblAutoDefSlot2Made6.Text + x + lblAutoDefSlot2Att6.Text + x + lblAutoDefSlot3Made6.Text + x + lblAutoDefSlot3Att6.Text + x + lblAutoDefSlot4Made6.Text + x + lblAutoDefSlot4Att6.Text + x + lblAutoTotalPoints6.Text + x + lblTeleOpDefSlot1Made6.Text + x + lblTeleOpDefSlot1Att6.Text + x + lblTeleOpDefSlot2Made6.Text + x + lblTeleOpDefSlot2Att6.Text + x + lblTeleOpDefSlot3Made6.Text + x + lblTeleOpDefSlot3Att6.Text + x + lblTeleOpDefSlot4Made6.Text + x + lblTeleOpDefSlot4Att6.Text + x + lblRobotScale6.Text + x + lblTeleOpTotalPoints6.Text + x + lblTotalPoints6.Text + x + lblDefense6.Text + x + lblmatch.Text);



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

            lblAutoTeamNo1.Text = AutoTeamNo1[0].ToString();
            lblAutoTeamNo2.Text = AutoTeamNo2[0].ToString();
            lblAutoTeamNo3.Text = AutoTeamNo3[0].ToString();
            lblAutoTeamNo4.Text = AutoTeamNo4[0].ToString();
            lblAutoTeamNo5.Text = AutoTeamNo5[0].ToString();
            lblAutoTeamNo6.Text = AutoTeamNo6[0].ToString();
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
            lblAutoTeamNo1.Text = AutoTeamNo1[match - 1].ToString();
            lblAutoTeamNo2.Text = AutoTeamNo2[match - 1].ToString();
            lblAutoTeamNo3.Text = AutoTeamNo3[match - 1].ToString();
            lblAutoTeamNo4.Text = AutoTeamNo4[match - 1].ToString();
            lblAutoTeamNo5.Text = AutoTeamNo5[match - 1].ToString();
            lblAutoTeamNo6.Text = AutoTeamNo6[match - 1].ToString();
        }

        private void btnScouter1_Click(object sender, EventArgs e)
        {
            lblScouter1.Text = textBoxScout1.Text;
            textBoxScout1.Visible = false;
            btnScouter1.Visible = false;
            lblScouter1.Visible = true;
        }

        private void btnScouter2_Click(object sender, EventArgs e)
        {
            lblScouter2.Text = textBoxScout2.Text;
            textBoxScout2.Visible = false;
            btnScouter2.Visible = false;
            lblScouter2.Visible = true;
        }

        private void btnScouter3_Click(object sender, EventArgs e)
        {
            lblScouter3.Text = textBoxScout3.Text;
            textBoxScout3.Visible = false;
            btnScouter3.Visible = false;
            lblScouter3.Visible = true;
        }

        private void btnScouter4_Click(object sender, EventArgs e)
        {
            lblScouter4.Text = textBoxScout4.Text;
            textBoxScout4.Visible = false;
            btnScouter4.Visible = false;
            lblScouter4.Visible = true;
        }

        private void btnScouter5_Click(object sender, EventArgs e)
        {
            lblScouter5.Text = textBoxScout5.Text;
            textBoxScout5.Visible = false;
            btnScouter5.Visible = false;
            lblScouter5.Visible = true;
        }

        private void btnScouter6_Click(object sender, EventArgs e)
        {
            lblScouter6.Text = textBoxScout6.Text;
            textBoxScout6.Visible = false;
            btnScouter6.Visible = false;
            lblScouter6.Visible = true;
        }

        private void lblAutoTotalPoints_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblAutoTeamNo2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void lblAutoTeamNo4_Click(object sender, EventArgs e)
        {

        }

        private void lblAutoTeamNo5_Click(object sender, EventArgs e)
        {

        }
    }
}