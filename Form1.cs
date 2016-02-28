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
        int[] displayLowFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] lowFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayLowFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] lowFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayLowFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoLowFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayLowFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoLowFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };

        // 2 point frisbees
        int[] displayMidFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] midFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayMidFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] midFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayMidFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoMidFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayMidFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoMidFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };

        // 3 point frisbees
        int[] displayHighFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] highFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayHighFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] highFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayHighFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoHighFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayHighFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoHighFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };

        // Pyramid Frisbees
        int[] displayPyramidFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] pyramidFrisbeesMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayPyramidFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };
        int[] pyramidFrisbeesAtt = { 0, 0, 0, 0, 0, 0 };

        // Robot Climbing
        int[] climb = { 0, 0, 0, 0, 0, 0 };
        int[] robotClimb = { 0, 0, 0, 0, 0, 0 };

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
            public const int ShotsMissedPlus = 4;
            public const int ShotsMissedMinus = 5;
            public const int PyramidFrisbeesAttMinus = 6;
            public const int PyramidFrisbeesAttPlus = 7;
            public const int HighFrisbeesMadeMinus = 8;
            public const int HighFrisbeesMadePlus = 9;
            public const int HighFrisbeesAttMinus = 10;
            public const int HighFrisbeesAttPlus = 11;
            public const int MidFrisbeesMadeMinus = 12;
            public const int MidFrisbeesMadePlus = 13;
            public const int MidFrisbeesAttMinus = 14;
            public const int MidFrisbeesAttPlus = 15;
            public const int LowFrisbeesMadeMinus = 16;
            public const int LowFrisbeesMadePlus = 17;
            public const int LowFrisbeesAttMinus = 18;
            public const int LowFrisbeesAttPlus = 19;
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
            switch (Command[0].ToUpper())
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
                case "ShotsMissedPlus":
                    ControllerCommands[controllernumber, Form1.GameCommands.ShotsMissedPlus] = buttons;
                    break;
                case "ShotsMissedMinus":
                    ControllerCommands[controllernumber, Form1.GameCommands.ShotsMissedMinus] = buttons;
                    break;
                case "PYRAMIDFRISBEESATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.PyramidFrisbeesAttMinus] = buttons;
                    break;
                case "PYRAMIDFRISBEESATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.PyramidFrisbeesAttPlus] = buttons;
                    break;
                case "HIGHFRISBEESMADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighFrisbeesMadeMinus] = buttons;
                    break;
                case "HIGHFRISBEESMADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighFrisbeesMadePlus] = buttons;
                    break;
                case "HIGHFRISBEESATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighFrisbeesAttMinus] = buttons;
                    break;
                case "HIGHFRISBEESATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighFrisbeesAttPlus] = buttons;
                    break;
                case "MIDFRISBEESMADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.MidFrisbeesMadeMinus] = buttons;
                    break;
                case "MIDFRISBEESMADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.MidFrisbeesMadePlus] = buttons;
                    break;
                case "MIDFRISBEESATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.MidFrisbeesAttMinus] = buttons;
                    break;
                case "MIDFRISBEESATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.MidFrisbeesAttPlus] = buttons;
                    break;
                case "LOWFRISBEESMADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowFrisbeesMadeMinus] = buttons;
                    break;
                case "LOWFRISBEESMADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowFrisbeesMadePlus] = buttons;
                    break;
                case "LOWFRISBEESATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowFrisbeesAttMinus] = buttons;
                    break;
                case "LOWFRISBEESATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowFrisbeesAttPlus] = buttons;
                    break;
                case "RobotScalePlus":
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
            autoTotalPoints[id] = (autoHighFrisbeesMade[id] * 6) +
                    (autoMidFrisbeesMade[id] * 4) +
                    (autoLowFrisbeesMade[id] * 2);
            teleOpTotalPoints[id] = (pyramidFrisbeesMade[id] * 5) +
                    (highFrisbeesMade[id] * 3) +
                    (midFrisbeesMade[id] * 2) +
                    lowFrisbeesMade[id];

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
                lblAutoHighAtt.Visible = false;
                lblTeleOpHighAtt.Visible = true;
                lblAutoHighMade.Visible = false;
                lblTeleOpHighMade.Visible = true;
                lblAutoMidAtt.Visible = false;
                lblTeleOpMidAtt.Visible = true;
                lblAutoMidMade.Visible = false;
                lblTeleOpMidMade.Visible = true;
                lblAutoLowAtt.Visible = false;
                lblTeleOpLowAtt.Visible = true;
                lblAutoLowMade.Visible = false;
                lblTeleOpLowMade.Visible = true;
                lblTeleOpPyramidAtt.Visible = true;
                lblTeleOpPyramidMade.Visible = true;
                lblRobotClimb.Visible = true;
            }
            if (AutonomousMode[0])
            {
                lblAuto.Visible = true;
                lblTeleOp.Visible = false;
                lblAutoHighAtt.Visible = true;
                lblTeleOpHighAtt.Visible = false;
                lblAutoHighMade.Visible = true;
                lblTeleOpHighMade.Visible = false;
                lblAutoMidAtt.Visible = true;
                lblTeleOpMidAtt.Visible = false;
                lblAutoMidMade.Visible = true;
                lblTeleOpMidMade.Visible = false;
                lblAutoLowAtt.Visible = true;
                lblTeleOpLowAtt.Visible = false;
                lblAutoLowMade.Visible = true;
                lblTeleOpLowMade.Visible = false;
                lblTeleOpPyramidAtt.Visible = false;
                lblTeleOpPyramidMade.Visible = false;
                lblRobotClimb.Visible = false;
            }
            //Defense Rating
            lblDefense.Text = displayDefenseRating[0].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade.Text = displayPyramidFrisbeesMade[0].ToString();
            lblTeleOpPyramidAtt.Text = displayPyramidFrisbeesAtt[0].ToString();

            // High Goals
            lblTeleOpHighMade.Text = displayHighFrisbeesMade[0].ToString();
            lblTeleOpHighAtt.Text = displayHighFrisbeesAtt[0].ToString();
            lblAutoHighMade.Text = autoDisplayHighFrisbeesMade[0].ToString();
            lblAutoHighAtt.Text = autoDisplayHighFrisbeesAtt[0].ToString();

            // Mid Goals
            lblTeleOpMidMade.Text = displayMidFrisbeesMade[0].ToString();
            lblTeleOpMidAtt.Text = displayMidFrisbeesAtt[0].ToString();
            lblAutoMidMade.Text = autoDisplayMidFrisbeesMade[0].ToString();
            lblAutoMidAtt.Text = autoDisplayMidFrisbeesAtt[0].ToString();

            // Low Goals
            lblTeleOpLowMade.Text = displayLowFrisbeesMade[0].ToString();
            lblTeleOpLowAtt.Text = displayLowFrisbeesAtt[0].ToString();
            lblAutoLowMade.Text = autoDisplayLowFrisbeesMade[0].ToString();
            lblAutoLowAtt.Text = autoDisplayLowFrisbeesAtt[0].ToString();

            // Robot Climb
            lblRobotClimb.Text = robotClimb[0].ToString();

            lblTeleOpTotalPoints.Text = teleOpTotalPoints[0].ToString();
            lblAutoTotalPoints.Text = autoTotalPoints[0].ToString();
            lblTotalPoints.Text = (autoTotalPoints[0] + teleOpTotalPoints[0] + robotClimb[0]).ToString();
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
                lblAutoHighAtt2.Visible = false;
                lblTeleOpHighAtt2.Visible = true;
                lblAutoHighMade2.Visible = false;
                lblTeleOpHighMade2.Visible = true;
                lblAutoMidAtt2.Visible = false;
                lblTeleOpMidAtt2.Visible = true;
                lblAutoMidMade2.Visible = false;
                lblTeleOpMidMade2.Visible = true;
                lblAutoLowAtt2.Visible = false;
                lblTeleOpLowAtt2.Visible = true;
                lblAutoLowMade2.Visible = false;
                lblTeleOpLowMade2.Visible = true;
                lblTeleOpPyramidAtt2.Visible = true;
                lblTeleOpPyramidMade2.Visible = true;
                lblRobotClimb2.Visible = true;
            }
            if (AutonomousMode[1])
            {
                lblAuto2.Visible = true;
                lblTeleOp2.Visible = false;
                lblAutoHighAtt2.Visible = true;
                lblTeleOpHighAtt2.Visible = false;
                lblAutoHighMade2.Visible = true;
                lblTeleOpHighMade2.Visible = false;
                lblAutoMidAtt2.Visible = true;
                lblTeleOpMidAtt2.Visible = false;
                lblAutoMidMade2.Visible = true;
                lblTeleOpMidMade2.Visible = false;
                lblAutoLowAtt2.Visible = true;
                lblTeleOpLowAtt2.Visible = false;
                lblAutoLowMade2.Visible = true;
                lblTeleOpLowMade2.Visible = false;
                lblTeleOpPyramidAtt2.Visible = false;
                lblTeleOpPyramidMade2.Visible = false;
                lblRobotClimb2.Visible = false;
            }
            //Defense Rating
            lblDefense2.Text = displayDefenseRating[1].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade2.Text = displayPyramidFrisbeesMade[1].ToString();
            lblTeleOpPyramidAtt2.Text = displayPyramidFrisbeesAtt[1].ToString();

            // High Goals
            lblTeleOpHighMade2.Text = displayHighFrisbeesMade[1].ToString();
            lblTeleOpHighAtt2.Text = displayHighFrisbeesAtt[1].ToString();
            lblAutoHighMade2.Text = autoDisplayHighFrisbeesMade[1].ToString();
            lblAutoHighAtt2.Text = autoDisplayHighFrisbeesAtt[1].ToString();

            // Mid Goals
            lblTeleOpMidMade2.Text = displayMidFrisbeesMade[1].ToString();
            lblTeleOpMidAtt2.Text = displayMidFrisbeesAtt[1].ToString();
            lblAutoMidMade2.Text = autoDisplayMidFrisbeesMade[1].ToString();
            lblAutoMidAtt2.Text = autoDisplayMidFrisbeesAtt[1].ToString();

            // Low Goals
            lblTeleOpLowMade2.Text = displayLowFrisbeesMade[1].ToString();
            lblTeleOpLowAtt2.Text = displayLowFrisbeesAtt[1].ToString();
            lblAutoLowMade2.Text = autoDisplayLowFrisbeesMade[1].ToString();
            lblAutoLowAtt2.Text = autoDisplayLowFrisbeesAtt[1].ToString();

            // Robot Climb
            lblRobotClimb2.Text = robotClimb[1].ToString();

            lblTeleOpTotalPoints2.Text = teleOpTotalPoints[1].ToString();
            lblAutoTotalPoints2.Text = autoTotalPoints[1].ToString();
            lblTotalPoints2.Text = (autoTotalPoints[1] + teleOpTotalPoints[1] + robotClimb[1]).ToString();
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
                lblAutoHighAtt3.Visible = false;
                lblTeleOpHighAtt3.Visible = true;
                lblAutoHighMade3.Visible = false;
                lblTeleOpHighMade3.Visible = true;
                lblAutoMidAtt3.Visible = false;
                lblTeleOpMidAtt3.Visible = true;
                lblAutoMidMade3.Visible = false;
                lblTeleOpMidMade3.Visible = true;
                lblAutoLowAtt3.Visible = false;
                lblTeleOpLowAtt3.Visible = true;
                lblAutoLowMade3.Visible = false;
                lblTeleOpLowMade3.Visible = true;
                lblTeleOpPyramidAtt3.Visible = true;
                lblTeleOpPyramidMade3.Visible = true;
                lblRobotClimb3.Visible = true;
            }
            if (AutonomousMode[2])
            {
                lblAuto3.Visible = true;
                lblTeleOp3.Visible = false;
                lblAutoHighAtt3.Visible = true;
                lblTeleOpHighAtt3.Visible = false;
                lblAutoHighMade3.Visible = true;
                lblTeleOpHighMade3.Visible = false;
                lblAutoMidAtt3.Visible = true;
                lblTeleOpMidAtt3.Visible = false;
                lblAutoMidMade3.Visible = true;
                lblTeleOpMidMade3.Visible = false;
                lblAutoLowAtt3.Visible = true;
                lblTeleOpLowAtt3.Visible = false;
                lblAutoLowMade3.Visible = true;
                lblTeleOpLowMade3.Visible = false;
                lblTeleOpPyramidAtt3.Visible = false;
                lblTeleOpPyramidMade3.Visible = false;
                lblRobotClimb3.Visible = false;
            }
            //Defense Rating
            lblDefense3.Text = displayDefenseRating[2].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade3.Text = displayPyramidFrisbeesMade[2].ToString();
            lblTeleOpPyramidAtt3.Text = displayPyramidFrisbeesAtt[2].ToString();

            // High Goals
            lblTeleOpHighMade3.Text = displayHighFrisbeesMade[2].ToString();
            lblTeleOpHighAtt3.Text = displayHighFrisbeesAtt[2].ToString();
            lblAutoHighMade3.Text = autoDisplayHighFrisbeesMade[2].ToString();
            lblAutoHighAtt3.Text = autoDisplayHighFrisbeesAtt[2].ToString();

            // Mid Goals
            lblTeleOpMidMade3.Text = displayMidFrisbeesMade[2].ToString();
            lblTeleOpMidAtt3.Text = displayMidFrisbeesAtt[2].ToString();
            lblAutoMidMade3.Text = autoDisplayMidFrisbeesMade[2].ToString();
            lblAutoMidAtt3.Text = autoDisplayMidFrisbeesAtt[2].ToString();

            // Low Goals
            lblTeleOpLowMade3.Text = displayLowFrisbeesMade[2].ToString();
            lblTeleOpLowAtt3.Text = displayLowFrisbeesAtt[2].ToString();
            lblAutoLowMade3.Text = autoDisplayLowFrisbeesMade[2].ToString();
            lblAutoLowAtt3.Text = autoDisplayLowFrisbeesAtt[2].ToString();

            // Robot Climb
            lblRobotClimb3.Text = robotClimb[2].ToString();

            lblTeleOpTotalPoints3.Text = teleOpTotalPoints[2].ToString();
            lblAutoTotalPoints3.Text = autoTotalPoints[2].ToString();
            lblTotalPoints3.Text = (autoTotalPoints[2] + teleOpTotalPoints[2] + robotClimb[2]).ToString();
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
                lblAutoHighAtt4.Visible = false;
                lblTeleOpHighAtt4.Visible = true;
                lblAutoHighMade4.Visible = false;
                lblTeleOpHighMade4.Visible = true;
                lblAutoMidAtt4.Visible = false;
                lblTeleOpMidAtt4.Visible = true;
                lblAutoMidMade4.Visible = false;
                lblTeleOpMidMade4.Visible = true;
                lblAutoLowAtt4.Visible = false;
                lblTeleOpLowAtt4.Visible = true;
                lblAutoLowMade4.Visible = false;
                lblTeleOpLowMade4.Visible = true;
                lblTeleOpPyramidAtt4.Visible = true;
                lblTeleOpPyramidMade4.Visible = true;
                lblRobotClimb4.Visible = true;
            }
            if (AutonomousMode[3])
            {
                lblAuto4.Visible = true;
                lblTeleOp4.Visible = false;
                lblAutoHighAtt4.Visible = true;
                lblTeleOpHighAtt4.Visible = false;
                lblAutoHighMade4.Visible = true;
                lblTeleOpHighMade4.Visible = false;
                lblAutoMidAtt4.Visible = true;
                lblTeleOpMidAtt4.Visible = false;
                lblAutoMidMade4.Visible = true;
                lblTeleOpMidMade4.Visible = false;
                lblAutoLowAtt4.Visible = true;
                lblTeleOpLowAtt4.Visible = false;
                lblAutoLowMade4.Visible = true;
                lblTeleOpLowMade4.Visible = false;
                lblTeleOpPyramidAtt4.Visible = false;
                lblTeleOpPyramidMade4.Visible = false;
                lblRobotClimb4.Visible = false;
            }
            //Defense Rating
            lblDefense4.Text = displayDefenseRating[3].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade4.Text = displayPyramidFrisbeesMade[3].ToString();
            lblTeleOpPyramidAtt4.Text = displayPyramidFrisbeesAtt[3].ToString();

            // High Goals
            lblTeleOpHighMade4.Text = displayHighFrisbeesMade[3].ToString();
            lblTeleOpHighAtt4.Text = displayHighFrisbeesAtt[3].ToString();
            lblAutoHighMade4.Text = autoDisplayHighFrisbeesMade[3].ToString();
            lblAutoHighAtt4.Text = autoDisplayHighFrisbeesAtt[3].ToString();

            // Mid Goals
            lblTeleOpMidMade4.Text = displayMidFrisbeesMade[3].ToString();
            lblTeleOpMidAtt4.Text = displayMidFrisbeesAtt[3].ToString();
            lblAutoMidMade4.Text = autoDisplayMidFrisbeesMade[3].ToString();
            lblAutoMidAtt4.Text = autoDisplayMidFrisbeesAtt[3].ToString();

            // Low Goals
            lblTeleOpLowMade4.Text = displayLowFrisbeesMade[3].ToString();
            lblTeleOpLowAtt4.Text = displayLowFrisbeesAtt[3].ToString();
            lblAutoLowMade4.Text = autoDisplayLowFrisbeesMade[3].ToString();
            lblAutoLowAtt4.Text = autoDisplayLowFrisbeesAtt[3].ToString();

            // Robot Climb
            lblRobotClimb4.Text = robotClimb[3].ToString();

            lblTeleOpTotalPoints4.Text = teleOpTotalPoints[3].ToString();
            lblAutoTotalPoints4.Text = autoTotalPoints[3].ToString();
            lblTotalPoints4.Text = (autoTotalPoints[3] + teleOpTotalPoints[3] + robotClimb[3]).ToString();
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
                lblAutoHighAtt5.Visible = false;
                lblTeleOpHighAtt5.Visible = true;
                lblAutoHighMade5.Visible = false;
                lblTeleOpHighMade5.Visible = true;
                lblAutoMidAtt5.Visible = false;
                lblTeleOpMidAtt5.Visible = true;
                lblAutoMidMade5.Visible = false;
                lblTeleOpMidMade5.Visible = true;
                lblAutoLowAtt5.Visible = false;
                lblTeleOpLowAtt5.Visible = true;
                lblAutoLowMade5.Visible = false;
                lblTeleOpLowMade5.Visible = true;
                lblTeleOpPyramidAtt5.Visible = true;
                lblTeleOpPyramidMade5.Visible = true;
                lblRobotClimb5.Visible = true;
            }
            if (AutonomousMode[4])
            {
                lblAuto5.Visible = true;
                lblTeleOp5.Visible = false;
                lblAutoHighAtt5.Visible = true;
                lblTeleOpHighAtt5.Visible = false;
                lblAutoHighMade5.Visible = true;
                lblTeleOpHighMade5.Visible = false;
                lblAutoMidAtt5.Visible = true;
                lblTeleOpMidAtt5.Visible = false;
                lblAutoMidMade5.Visible = true;
                lblTeleOpMidMade5.Visible = false;
                lblAutoLowAtt5.Visible = true;
                lblTeleOpLowAtt5.Visible = false;
                lblAutoLowMade5.Visible = true;
                lblTeleOpLowMade5.Visible = false;
                lblTeleOpPyramidAtt5.Visible = false;
                lblTeleOpPyramidMade5.Visible = false;
                lblRobotClimb5.Visible = false;
            }
            //Defense Rating
            lblDefense5.Text = displayDefenseRating[4].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade5.Text = displayPyramidFrisbeesMade[4].ToString();
            lblTeleOpPyramidAtt5.Text = displayPyramidFrisbeesAtt[4].ToString();

            // High Goals
            lblTeleOpHighMade5.Text = displayHighFrisbeesMade[4].ToString();
            lblTeleOpHighAtt5.Text = displayHighFrisbeesAtt[4].ToString();
            lblAutoHighMade5.Text = autoDisplayHighFrisbeesMade[4].ToString();
            lblAutoHighAtt5.Text = autoDisplayHighFrisbeesAtt[4].ToString();

            // Mid Goals
            lblTeleOpMidMade5.Text = displayMidFrisbeesMade[4].ToString();
            lblTeleOpMidAtt5.Text = displayMidFrisbeesAtt[4].ToString();
            lblAutoMidMade5.Text = autoDisplayMidFrisbeesMade[4].ToString();
            lblAutoMidAtt5.Text = autoDisplayMidFrisbeesAtt[4].ToString();

            // Low Goals
            lblTeleOpLowMade5.Text = displayLowFrisbeesMade[4].ToString();
            lblTeleOpLowAtt5.Text = displayLowFrisbeesAtt[4].ToString();
            lblAutoLowMade5.Text = autoDisplayLowFrisbeesMade[4].ToString();
            lblAutoLowAtt5.Text = autoDisplayLowFrisbeesAtt[4].ToString();

            // Robot Climb
            lblRobotClimb5.Text = robotClimb[4].ToString();

            lblTeleOpTotalPoints5.Text = teleOpTotalPoints[4].ToString();
            lblAutoTotalPoints5.Text = autoTotalPoints[4].ToString();
            lblTotalPoints5.Text = (autoTotalPoints[4] + teleOpTotalPoints[4] + robotClimb[4]).ToString();

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
                lblAutoHighAtt6.Visible = false;
                lblTeleOpHighAtt6.Visible = true;
                lblAutoHighMade6.Visible = false;
                lblTeleOpHighMade6.Visible = true;
                lblAutoMidAtt6.Visible = false;
                lblTeleOpMidAtt6.Visible = true;
                lblAutoMidMade6.Visible = false;
                lblTeleOpMidMade6.Visible = true;
                lblAutoLowAtt6.Visible = false;
                lblTeleOpLowAtt6.Visible = true;
                lblAutoLowMade6.Visible = false;
                lblTeleOpLowMade6.Visible = true;
                lblTeleOpPyramidAtt6.Visible = true;
                lblTeleOpPyramidMade6.Visible = true;
                lblRobotClimb6.Visible = true;
            }
            if (AutonomousMode[5])
            {
                lblAuto6.Visible = true;
                lblTeleOp6.Visible = false;
                lblAutoHighAtt6.Visible = true;
                lblTeleOpHighAtt6.Visible = false;
                lblAutoHighMade6.Visible = true;
                lblTeleOpHighMade6.Visible = false;
                lblAutoMidAtt6.Visible = true;
                lblTeleOpMidAtt6.Visible = false;
                lblAutoMidMade6.Visible = true;
                lblTeleOpMidMade6.Visible = false;
                lblAutoLowAtt6.Visible = true;
                lblTeleOpLowAtt6.Visible = false;
                lblAutoLowMade6.Visible = true;
                lblTeleOpLowMade6.Visible = false;
                lblTeleOpPyramidAtt6.Visible = false;
                lblTeleOpPyramidMade6.Visible = false;
                lblRobotClimb6.Visible = false;
            }
            //Defense Rating
            lblDefense6.Text = displayDefenseRating[5].ToString();

            // Pyramid Goals
            lblTeleOpPyramidMade6.Text = displayPyramidFrisbeesMade[5].ToString();
            lblTeleOpPyramidAtt6.Text = displayPyramidFrisbeesAtt[5].ToString();

            // High Goals
            lblTeleOpHighMade6.Text = displayHighFrisbeesMade[5].ToString();
            lblTeleOpHighAtt6.Text = displayHighFrisbeesAtt[5].ToString();
            lblAutoHighMade6.Text = autoDisplayHighFrisbeesMade[5].ToString();
            lblAutoHighAtt6.Text = autoDisplayHighFrisbeesAtt[5].ToString();

            // Mid Goals
            lblTeleOpMidMade6.Text = displayMidFrisbeesMade[5].ToString();
            lblTeleOpMidAtt6.Text = displayMidFrisbeesAtt[5].ToString();
            lblAutoMidMade6.Text = autoDisplayMidFrisbeesMade[5].ToString();
            lblAutoMidAtt6.Text = autoDisplayMidFrisbeesAtt[5].ToString();

            // Low Goals
            lblTeleOpLowMade6.Text = displayLowFrisbeesMade[5].ToString();
            lblTeleOpLowAtt6.Text = displayLowFrisbeesAtt[5].ToString();
            lblAutoLowMade6.Text = autoDisplayLowFrisbeesMade[5].ToString();
            lblAutoLowAtt6.Text = autoDisplayLowFrisbeesAtt[5].ToString();

            // Robot Climb
            lblRobotClimb6.Text = robotClimb[5].ToString();

            lblTeleOpTotalPoints6.Text = teleOpTotalPoints[5].ToString();
            lblAutoTotalPoints6.Text = autoTotalPoints[5].ToString();
            lblTotalPoints6.Text = (autoTotalPoints[5] + teleOpTotalPoints[5] + robotClimb[5]).ToString();

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

                case (GameCommands.HighFrisbeesAttMinus):
                    if (TeleOp[id])
                    {
                        if (highFrisbeesAtt[id] > 0 && highFrisbeesMade[id] < highFrisbeesAtt[id])
                        {
                            highFrisbeesAtt[id]--;
                            displayHighFrisbeesAtt[id] = highFrisbeesAtt[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoHighFrisbeesAtt[id] > 0 && autoHighFrisbeesMade[id] < autoHighFrisbeesAtt[id])
                        {
                            autoHighFrisbeesAtt[id]--;
                            autoDisplayHighFrisbeesAtt[id] = autoHighFrisbeesAtt[id];
                        }
                    }

                    break;

                case (GameCommands.HighFrisbeesAttPlus):
                    if (TeleOp[id])
                    {
                        highFrisbeesAtt[id]++;
                        displayHighFrisbeesAtt[id] = highFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoHighFrisbeesAtt[id]++;
                        autoDisplayHighFrisbeesAtt[id] = autoHighFrisbeesAtt[id];
                    }

                    break;

                case (GameCommands.HighFrisbeesMadeMinus):
                    if (TeleOp[id])
                    {
                        if (highFrisbeesMade[id] > 0)
                        {
                            highFrisbeesMade[id]--;
                            displayHighFrisbeesMade[id] = highFrisbeesMade[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoHighFrisbeesMade[id] > 0)
                        {
                            autoHighFrisbeesMade[id]--;
                            autoDisplayHighFrisbeesMade[id] = autoHighFrisbeesMade[id];
                        }
                    }
                    break;

                case (GameCommands.HighFrisbeesMadePlus):
                    if (TeleOp[id])
                    {
                        highFrisbeesMade[id]++;
                        displayHighFrisbeesMade[id] = highFrisbeesMade[id];
                        highFrisbeesAtt[id]++;
                        displayHighFrisbeesAtt[id] = highFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoHighFrisbeesMade[id]++;
                        autoDisplayHighFrisbeesMade[id] = autoHighFrisbeesMade[id];
                        autoHighFrisbeesAtt[id]++;
                        autoDisplayHighFrisbeesAtt[id] = autoHighFrisbeesAtt[id];
                    }
                    break;

                case (GameCommands.LowFrisbeesAttMinus):
                    if (TeleOp[id])
                    {
                        if (lowFrisbeesAtt[id] > 0 && lowFrisbeesMade[id] < lowFrisbeesAtt[id])
                        {
                            lowFrisbeesAtt[id]--;
                            displayLowFrisbeesAtt[id] = lowFrisbeesAtt[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoLowFrisbeesAtt[id] > 0 && autoLowFrisbeesMade[id] < autoLowFrisbeesAtt[id])
                        {
                            autoLowFrisbeesAtt[id]--;
                            autoDisplayLowFrisbeesAtt[id] = autoLowFrisbeesAtt[id];
                        }
                    }

                    break;

                case (GameCommands.LowFrisbeesAttPlus):
                    if (TeleOp[id])
                    {
                        lowFrisbeesAtt[id]++;
                        displayLowFrisbeesAtt[id] = lowFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoLowFrisbeesAtt[id]++;
                        autoDisplayLowFrisbeesAtt[id] = autoLowFrisbeesAtt[id];
                    }


                    break;

                case (GameCommands.LowFrisbeesMadeMinus):
                    if (TeleOp[id])
                    {
                        if (lowFrisbeesMade[id] > 0)
                        {
                            lowFrisbeesMade[id]--;
                            displayLowFrisbeesMade[id] = lowFrisbeesMade[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoLowFrisbeesMade[id] > 0)
                        {
                            autoLowFrisbeesMade[id]--;
                            autoDisplayLowFrisbeesMade[id] = autoLowFrisbeesMade[id];
                        }
                    }

                    break;

                case (GameCommands.LowFrisbeesMadePlus):
                    if (TeleOp[id])
                    {
                        lowFrisbeesMade[id]++;
                        displayLowFrisbeesMade[id] = lowFrisbeesMade[id];
                        lowFrisbeesAtt[id]++;
                        displayLowFrisbeesAtt[id] = lowFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoLowFrisbeesMade[id]++;
                        autoDisplayLowFrisbeesMade[id] = autoLowFrisbeesMade[id];
                        autoLowFrisbeesAtt[id]++;
                        autoDisplayLowFrisbeesAtt[id] = autoLowFrisbeesAtt[id];
                    }

                    break;

                case (GameCommands.MidFrisbeesAttMinus):
                    if (TeleOp[id])
                    {
                        if (midFrisbeesAtt[id] > 0 && midFrisbeesMade[id] < midFrisbeesAtt[id])
                        {
                            midFrisbeesAtt[id]--;
                            displayMidFrisbeesAtt[id] = midFrisbeesAtt[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoMidFrisbeesAtt[id] > 0 && autoMidFrisbeesMade[id] < autoMidFrisbeesAtt[id])
                        {
                            autoMidFrisbeesAtt[id]--;
                            autoDisplayMidFrisbeesAtt[id] = autoMidFrisbeesAtt[id];
                        }
                    }
                    break;

                case (GameCommands.MidFrisbeesAttPlus):
                    if (TeleOp[id])
                    {
                        midFrisbeesAtt[id]++;
                        displayMidFrisbeesAtt[id] = midFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoMidFrisbeesAtt[id]++;
                        autoDisplayMidFrisbeesAtt[id] = autoMidFrisbeesAtt[id];
                    }


                    break;

                case (GameCommands.MidFrisbeesMadeMinus):
                    if (TeleOp[id])
                    {
                        if (midFrisbeesMade[id] > 0)
                        {
                            midFrisbeesMade[id]--;
                            displayMidFrisbeesMade[id] = midFrisbeesMade[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoMidFrisbeesMade[id] > 0)
                        {
                            autoMidFrisbeesMade[id]--;
                            autoDisplayMidFrisbeesMade[id] = autoMidFrisbeesMade[id];
                        }
                    }

                    break;

                case (GameCommands.MidFrisbeesMadePlus):
                    if (TeleOp[id])
                    {
                        midFrisbeesMade[id]++;
                        displayMidFrisbeesMade[id] = midFrisbeesMade[id];
                        midFrisbeesAtt[id]++;
                        displayMidFrisbeesAtt[id] = midFrisbeesAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoMidFrisbeesMade[id]++;
                        autoDisplayMidFrisbeesMade[id] = autoMidFrisbeesMade[id];
                        autoMidFrisbeesAtt[id]++;
                        autoDisplayMidFrisbeesAtt[id] = autoMidFrisbeesAtt[id];
                    }

                    break;

                case (GameCommands.PyramidFrisbeesAttMinus):
                    if (pyramidFrisbeesAtt[id] > 0 && pyramidFrisbeesMade[id] < pyramidFrisbeesAtt[id])
                        pyramidFrisbeesAtt[id]--;
                    displayPyramidFrisbeesAtt[id] = pyramidFrisbeesAtt[id];

                    break;

                case (GameCommands.PyramidFrisbeesAttPlus):
                    pyramidFrisbeesAtt[id]++;
                    displayPyramidFrisbeesAtt[id] = pyramidFrisbeesAtt[id];
                    break;

                case (GameCommands.ShotsMissedPlus):
                    if (pyramidFrisbeesMade[id] > 0)
                        pyramidFrisbeesMade[id]--;
                    displayPyramidFrisbeesMade[id] = pyramidFrisbeesMade[id];
                    break;

                case (GameCommands.ShotsMissedMinus):
                    pyramidFrisbeesMade[id]++;
                    displayPyramidFrisbeesMade[id] = pyramidFrisbeesMade[id];
                    // If they made it increase the attempts
                    pyramidFrisbeesAtt[id]++;
                    displayPyramidFrisbeesAtt[id] = pyramidFrisbeesAtt[id];

                    break;

                case (GameCommands.RobotScalePlus):
                    if (TeleOp[id])
                    {
                        climb[id]++;
                        robotClimb[id] = climb[id];

                        if (robotClimb[id] > 3)
                        {
                            robotClimb[id] = 0;
                            climb[id] = 0;
                        }

                        robotClimb[id] = robotClimb[id] * 10;
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
                    displayLowFrisbeesMade[f] = 0;
                    displayLowFrisbeesAtt[f] = 0;
                    lowFrisbeesMade[f] = 0;
                    lowFrisbeesAtt[f] = 0;
                    autoDisplayLowFrisbeesMade[f] = 0;
                    autoLowFrisbeesMade[f] = 0;
                    autoDisplayLowFrisbeesAtt[f] = 0;
                    autoLowFrisbeesAtt[f] = 0;
                    displayMidFrisbeesMade[f] = 0;
                    midFrisbeesMade[f] = 0;
                    displayMidFrisbeesAtt[f] = 0;
                    midFrisbeesAtt[f] = 0;
                    autoDisplayMidFrisbeesMade[f] = 0;
                    autoMidFrisbeesMade[f] = 0;
                    autoDisplayMidFrisbeesAtt[f] = 0;
                    autoMidFrisbeesAtt[f] = 0;
                    displayHighFrisbeesMade[f] = 0;
                    highFrisbeesMade[f] = 0;
                    displayHighFrisbeesAtt[f] = 0;
                    highFrisbeesAtt[f] = 0;
                    autoDisplayHighFrisbeesMade[f] = 0;
                    autoHighFrisbeesMade[f] = 0;
                    autoDisplayHighFrisbeesAtt[f] = 0;
                    autoHighFrisbeesAtt[f] = 0;
                    displayPyramidFrisbeesMade[f] = 0;
                    pyramidFrisbeesMade[f] = 0;
                    displayPyramidFrisbeesAtt[f] = 0;
                    pyramidFrisbeesAtt[f] = 0;
                    climb[f] = 0;
                    robotClimb[f] = 0;
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
                    lblRobotClimb.Visible = false;
                    lblRobotClimb2.Visible = false;
                    lblRobotClimb3.Visible = false;
                    lblRobotClimb4.Visible = false;
                    lblRobotClimb5.Visible = false;
                    lblRobotClimb6.Visible = false;
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
                displayLowFrisbeesMade[f] = 0;
                displayLowFrisbeesAtt[f] = 0;
                lowFrisbeesMade[f] = 0;
                lowFrisbeesAtt[f] = 0;
                autoDisplayLowFrisbeesMade[f] = 0;
                autoLowFrisbeesMade[f] = 0;
                autoDisplayLowFrisbeesAtt[f] = 0;
                autoLowFrisbeesAtt[f] = 0;
                displayMidFrisbeesMade[f] = 0;
                midFrisbeesMade[f] = 0;
                displayMidFrisbeesAtt[f] = 0;
                midFrisbeesAtt[f] = 0;
                autoDisplayMidFrisbeesMade[f] = 0;
                autoMidFrisbeesMade[f] = 0;
                autoDisplayMidFrisbeesAtt[f] = 0;
                autoMidFrisbeesAtt[f] = 0;
                displayHighFrisbeesMade[f] = 0;
                highFrisbeesMade[f] = 0;
                displayHighFrisbeesAtt[f] = 0;
                highFrisbeesAtt[f] = 0;
                autoDisplayHighFrisbeesMade[f] = 0;
                autoHighFrisbeesMade[f] = 0;
                autoDisplayHighFrisbeesAtt[f] = 0;
                autoHighFrisbeesAtt[f] = 0;
                displayPyramidFrisbeesMade[f] = 0;
                pyramidFrisbeesMade[f] = 0;
                displayPyramidFrisbeesAtt[f] = 0;
                pyramidFrisbeesAtt[f] = 0;
                climb[f] = 0;
                robotClimb[f] = 0;
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
            lblRobotClimb.Visible = false;
            lblRobotClimb2.Visible = false;
            lblRobotClimb3.Visible = false;
            lblRobotClimb4.Visible = false;
            lblRobotClimb5.Visible = false;
            lblRobotClimb6.Visible = false;
        }

        private void tm1939SaveFile(StreamWriter outputstream)
        {
            // A single writeline section to handle both save buttons.
            // Added Match to the end of each record
            outputstream.WriteLine(lblAutoTeamNo1.Text + x + lblAutoHighMade.Text + x + lblAutoHighAtt.Text + x + lblAutoMidMade.Text + x + lblAutoMidAtt.Text + x + lblAutoLowMade.Text + x + lblAutoLowAtt.Text + x + lblAutoTotalPoints.Text + x + lblTeleOpPyramidMade.Text + x + lblTeleOpPyramidAtt.Text + x + lblTeleOpHighMade.Text + x + lblTeleOpHighAtt.Text + x + lblTeleOpMidMade.Text + x + lblTeleOpMidAtt.Text + x + lblTeleOpLowMade.Text + x + lblTeleOpLowAtt.Text + x + lblRobotClimb.Text + x + lblTeleOpTotalPoints.Text + x + lblTotalPoints.Text + x + lblDefense.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo2.Text + x + lblAutoHighMade2.Text + x + lblAutoHighAtt2.Text + x + lblAutoMidMade2.Text + x + lblAutoMidAtt2.Text + x + lblAutoLowMade2.Text + x + lblAutoLowAtt2.Text + x + lblAutoTotalPoints2.Text + x + lblTeleOpPyramidMade2.Text + x + lblTeleOpPyramidAtt2.Text + x + lblTeleOpHighMade2.Text + x + lblTeleOpHighAtt2.Text + x + lblTeleOpMidMade2.Text + x + lblTeleOpMidAtt2.Text + x + lblTeleOpLowMade2.Text + x + lblTeleOpLowAtt2.Text + x + lblRobotClimb2.Text + x + lblTeleOpTotalPoints2.Text + x + lblTotalPoints2.Text + x + lblDefense2.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo3.Text + x + lblAutoHighMade3.Text + x + lblAutoHighAtt3.Text + x + lblAutoMidMade3.Text + x + lblAutoMidAtt3.Text + x + lblAutoLowMade3.Text + x + lblAutoLowAtt3.Text + x + lblAutoTotalPoints3.Text + x + lblTeleOpPyramidMade3.Text + x + lblTeleOpPyramidAtt3.Text + x + lblTeleOpHighMade3.Text + x + lblTeleOpHighAtt3.Text + x + lblTeleOpMidMade3.Text + x + lblTeleOpMidAtt3.Text + x + lblTeleOpLowMade3.Text + x + lblTeleOpLowAtt3.Text + x + lblRobotClimb3.Text + x + lblTeleOpTotalPoints3.Text + x + lblTotalPoints3.Text + x + lblDefense3.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo4.Text + x + lblAutoHighMade4.Text + x + lblAutoHighAtt4.Text + x + lblAutoMidMade4.Text + x + lblAutoMidAtt4.Text + x + lblAutoLowMade4.Text + x + lblAutoLowAtt4.Text + x + lblAutoTotalPoints4.Text + x + lblTeleOpPyramidMade4.Text + x + lblTeleOpPyramidAtt4.Text + x + lblTeleOpHighMade4.Text + x + lblTeleOpHighAtt4.Text + x + lblTeleOpMidMade4.Text + x + lblTeleOpMidAtt4.Text + x + lblTeleOpLowMade4.Text + x + lblTeleOpLowAtt4.Text + x + lblRobotClimb4.Text + x + lblTeleOpTotalPoints4.Text + x + lblTotalPoints4.Text + x + lblDefense4.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo5.Text + x + lblAutoHighMade5.Text + x + lblAutoHighAtt5.Text + x + lblAutoMidMade5.Text + x + lblAutoMidAtt5.Text + x + lblAutoLowMade5.Text + x + lblAutoLowAtt5.Text + x + lblAutoTotalPoints5.Text + x + lblTeleOpPyramidMade5.Text + x + lblTeleOpPyramidAtt5.Text + x + lblTeleOpHighMade5.Text + x + lblTeleOpHighAtt5.Text + x + lblTeleOpMidMade5.Text + x + lblTeleOpMidAtt5.Text + x + lblTeleOpLowMade5.Text + x + lblTeleOpLowAtt5.Text + x + lblRobotClimb5.Text + x + lblTeleOpTotalPoints5.Text + x + lblTotalPoints5.Text + x + lblDefense5.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo6.Text + x + lblAutoHighMade6.Text + x + lblAutoHighAtt6.Text + x + lblAutoMidMade6.Text + x + lblAutoMidAtt6.Text + x + lblAutoLowMade6.Text + x + lblAutoLowAtt6.Text + x + lblAutoTotalPoints6.Text + x + lblTeleOpPyramidMade6.Text + x + lblTeleOpPyramidAtt6.Text + x + lblTeleOpHighMade6.Text + x + lblTeleOpHighAtt6.Text + x + lblTeleOpMidMade6.Text + x + lblTeleOpMidAtt6.Text + x + lblTeleOpLowMade6.Text + x + lblTeleOpLowAtt6.Text + x + lblRobotClimb6.Text + x + lblTeleOpTotalPoints6.Text + x + lblTotalPoints6.Text + x + lblDefense6.Text + x + lblmatch.Text);



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