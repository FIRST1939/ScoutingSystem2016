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
        // Defense 5 
        int[] displayDefense5Cross = { 0, 0, 0, 0, 0, 0 };
        int[] defense5Cross = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefense5Att = { 0, 0, 0, 0, 0, 0 };
        int[] defense5Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense5Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense5Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense5Reach = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense5Reach = { 0, 0, 0, 0, 0, 0 };

        // 1 point frisbees
        int[] displayDefense4Cross = { 0, 0, 0, 0, 0, 0 };
        int[] defense4Cross = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefense4Att = { 0, 0, 0, 0, 0, 0 };
        int[] defense4Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense4Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense4Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense4Reach = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense4Reach = { 0, 0, 0, 0, 0, 0 };

        // 2 point frisbees
        int[] displayDefense3Cross = { 0, 0, 0, 0, 0, 0 };
        int[] defense3Cross = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefense3Att = { 0, 0, 0, 0, 0, 0 };
        int[] defense3Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense3Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense3Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense3Reach = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense3Reach = { 0, 0, 0, 0, 0, 0 };

        // 3 point frisbees
        int[] displayDefense2Cross = { 0, 0, 0, 0, 0, 0 };
        int[] defense2Cross = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefense2Att = { 0, 0, 0, 0, 0, 0 };
        int[] defense2Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense2Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense2Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense2Reach = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense2Reach = { 0, 0, 0, 0, 0, 0 };

        // Pyramid Frisbees
        int[] displayDefense1Cross = { 0, 0, 0, 0, 0, 0 };
        int[] defense1Cross = { 0, 0, 0, 0, 0, 0 };
        int[] displayDefense1Att = { 0, 0, 0, 0, 0, 0 };
        int[] defense1Att = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense1Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense1Cross = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayDefense1Reach = { 0, 0, 0, 0, 0, 0 };
        int[] autoDefense1Reach = { 0, 0, 0, 0, 0, 0 };

        // High Boulder Shot
        int[] displayHighShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] highShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayHighShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] highShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayHighShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoHighShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayHighShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoHighShotAtt = { 0, 0, 0, 0, 0, 0 };

        // Low Boulder Shot
        int[] displayLowShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] lowShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] displayLowShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] lowShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayLowShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoLowShotMade = { 0, 0, 0, 0, 0, 0 };
        int[] autoDisplayLowShotAtt = { 0, 0, 0, 0, 0, 0 };
        int[] autoLowShotAtt = { 0, 0, 0, 0, 0, 0 };

        // Robot Climbing
        int[] climb = { 0, 0, 0, 0, 0, 0 };
        int[] challengeScale = { 0, 0, 0, 0, 0, 0 };

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
            public const int Defense1CrossMinus = 4;
            public const int Defense1CrossPlus = 5;
            public const int Defense1AttMinus = 6;
            public const int Defense1AttPlus = 7;
            public const int Defense2CrossMinus = 8;
            public const int Defense2CrossPlus = 9;
            public const int Defense2AttMinus = 10;
            public const int Defense2AttPlus = 11;
            public const int Defense3CrossMinus = 12;
            public const int Defense3CrossPlus = 13;
            public const int Defense3AttMinus = 14;
            public const int Defense3AttPlus = 15;
            public const int Defense4CrossMinus = 16;
            public const int Defense4CrossPlus = 17;
            public const int Defense4AttMinus = 18;
            public const int Defense4AttPlus = 19;
            public const int Defense5CrossMinus = 22;
            public const int Defense5CrossPlus = 23;
            public const int Defense5AttMinus = 24;
            public const int Defense5AttPlus = 25;
            public const int HighShotMadeMinus = 26;
            public const int HighShotMadePlus = 27;
            public const int HighShotAttMinus = 28;
            public const int HighShotAttPlus = 29;
            public const int LowShotMadeMinus = 30;
            public const int LowShotMadePlus = 31;
            public const int LowShotAttMinus = 32;
            public const int LowShotAttPlus = 33;
            public const int ChallengeScalePlus = 20;
            public const int FinishedScoring = 21;
        }

        String[,] ControllerCommands = new String[6, 34];
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
            switch (Command[0].ToUpper())  //In this section, case names should be all uppercase
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
                case "DEFENSE1CROSSMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense1CrossMinus] = buttons;
                    break;
                case "DEFENSE1CROSSPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense1CrossPlus] = buttons;
                    break;
                case "DEFENSE1ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense1AttMinus] = buttons;
                    break;
                case "DEFENSE1ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense1AttPlus] = buttons;
                    break;
                case "DEFENSE2CROSSMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense2CrossMinus] = buttons;
                    break;
                case "DEFENSE2CROSSPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense2CrossPlus] = buttons;
                    break;
                case "DEFENSE2ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense2AttMinus] = buttons;
                    break;
                case "DEFENSE2ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense2AttPlus] = buttons;
                    break;
                case "DEFENSE3CROSSMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense3CrossMinus] = buttons;
                    break;
                case "DEFENSE3CROSSPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense3CrossPlus] = buttons;
                    break;
                case "DEFENSE3ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense3AttMinus] = buttons;
                    break;
                case "DEFENSE3ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense3AttPlus] = buttons;
                    break;
                case "DEFENSE4CROSSMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense4CrossMinus] = buttons;
                    break;
                case "DEFENSE4CROSSPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense4CrossPlus] = buttons;
                    break;
                case "DEFENSE4ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense4AttMinus] = buttons;
                    break;
                case "DEFENSE4ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense4AttPlus] = buttons;
                    break;
                case "DEFENSE5CROSSMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense5CrossMinus] = buttons;
                    break;
                case "DEFENSE5CROSSPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense5CrossPlus] = buttons;
                    break;
                case "DEFENSE5ATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense5AttMinus] = buttons;
                    break;
                case "DEFENSE5ATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.Defense5AttPlus] = buttons;
                    break;
                case "HIGHSHOTMADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighShotMadeMinus] = buttons;
                    break;
                case "HIGHSHOTMADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighShotMadePlus] = buttons;
                    break;
                case "HIGHSHOTATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighShotAttMinus] = buttons;
                    break;
                case "HIGHSHOTATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.HighShotAttPlus] = buttons;
                    break;
                case "LOWSHOTMADEMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowShotMadeMinus] = buttons;
                    break;
                case "LOWSHOTMADEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowShotMadePlus] = buttons;
                    break;
                case "LOWSHOTATTMINUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowShotAttMinus] = buttons;
                    break;
                case "LOWSHOTATTPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.LowShotAttPlus] = buttons;
                    break;
                case "CHALLENGESCALEPLUS":
                    ControllerCommands[controllernumber, Form1.GameCommands.ChallengeScalePlus] = buttons;
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

        void UpdateScores(int id)   //COOK George, this one is yours to fix.
        {
            autoTotalPoints[id] = (autoDefense2Cross[id] * 6) +
                    (autoDefense3Cross[id] * 4) +
                    (autoDefense4Cross[id] * 2);
            teleOpTotalPoints[id] = (defense1Cross[id] * 5) +
                    (defense2Cross[id] * 3) +
                    (defense3Cross[id] * 2) +
                    defense4Cross[id];

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
                lblAutoD1Reach.Visible = false;
                lblTeleOpD1Att.Visible = true;
                lblAutoD1Cross.Visible = false;
                lblTeleOpD1Cross.Visible = true;
                lblAutoD2Reach.Visible = false;
                lblTeleOpD2Att.Visible = true;
                lblAutoD2Cross.Visible = false;
                lblTeleOpD2Cross.Visible = true;
                lblAutoD3Reach.Visible = false;
                lblTeleOpD3Att.Visible = true;
                lblAutoD3Cross.Visible = false;
                lblTeleOpD3Cross.Visible = true;
                lblAutoD4Reach.Visible = false;
                lblTeleOpD4Att.Visible = true;
                lblAutoD4Cross.Visible = false;
                lblTeleOpD4Cross.Visible = true;
                lblAutoD5Reach.Visible = false;
                lblTeleOpD5Att.Visible = true;
                lblAutoD5Cross.Visible = false;
                lblTeleOpD5Cross.Visible = true;
                lblAutoHighShotAtt.Visible = false;
                lblTeleOpHighShotAtt.Visible = true;
                lblAutoHighShotMade.Visible = false;
                lblTeleOpHighShotMade.Visible = true;
                lblAutoLowShotAtt.Visible = false;
                lblTeleOpLowShotAtt.Visible = true;
                lblAutoLowShotMade.Visible = false;
                lblTeleOpLowShotMade.Visible = true;
                lblChallengeScale.Visible = true;
            }
            if (AutonomousMode[0])
            {
                lblAuto.Visible = true;
                lblTeleOp.Visible = false;
                lblAutoD1Reach.Visible = true;
                lblTeleOpD1Att.Visible = false;
                lblAutoD1Cross.Visible = true;
                lblTeleOpD1Cross.Visible = false;
                lblAutoD2Reach.Visible = true;
                lblTeleOpD2Att.Visible = false;
                lblAutoD2Cross.Visible = true;
                lblTeleOpD2Cross.Visible = false;
                lblAutoD3Reach.Visible = true;
                lblTeleOpD3Att.Visible = false;
                lblAutoD3Cross.Visible = true;
                lblTeleOpD3Cross.Visible = false;
                lblAutoD4Reach.Visible = true;
                lblTeleOpD4Att.Visible = false;
                lblAutoD4Cross.Visible = true;
                lblTeleOpD4Cross.Visible = false;
                lblAutoD5Reach.Visible = true;
                lblTeleOpD5Att.Visible = false;
                lblAutoD5Cross.Visible = true;
                lblTeleOpD5Cross.Visible = false;
                lblAutoHighShotAtt.Visible = true;
                lblTeleOpHighShotAtt.Visible = false;
                lblAutoHighShotMade.Visible = true;
                lblTeleOpHighShotMade.Visible = false;
                lblAutoLowShotAtt.Visible = true;
                lblTeleOpLowShotAtt.Visible = false;
                lblAutoLowShotMade.Visible = true;
                lblTeleOpLowShotMade.Visible = false;
                lblChallengeScale.Visible = false;
            }
            //Defense Rating
            lblDefense.Text = displayDefenseRating[0].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross.Text = displayDefense1Cross[0].ToString();
            lblTeleOpD1Att.Text = displayDefense1Att[0].ToString();
            lblAutoD1Cross.Text = autoDisplayDefense1Cross[0].ToString();
            lblAutoD1Reach.Text = autoDisplayDefense1Reach[0].ToString();

            // High Goals
            lblTeleOpD2Cross.Text = displayDefense2Cross[0].ToString();
            lblTeleOpD2Att.Text = displayDefense2Att[0].ToString();
            lblAutoD2Cross.Text = autoDisplayDefense2Cross[0].ToString();
            lblAutoD2Reach.Text = autoDisplayDefense2Reach[0].ToString();

            // Mid Goals
            lblTeleOpD3Cross.Text = displayDefense3Cross[0].ToString();
            lblTeleOpD3Att.Text = displayDefense3Att[0].ToString();
            lblAutoD3Cross.Text = autoDisplayDefense3Cross[0].ToString();
            lblAutoD3Reach.Text = autoDisplayDefense3Reach[0].ToString();

            // Low Goals
            lblTeleOpD4Cross.Text = displayDefense4Cross[0].ToString();
            lblTeleOpD4Att.Text = displayDefense4Att[0].ToString();
            lblAutoD4Cross.Text = autoDisplayDefense4Cross[0].ToString();
            lblAutoD4Reach.Text = autoDisplayDefense4Reach[0].ToString();

            // Defense 5
            lblTeleOpD5Cross.Text = displayDefense5Cross[0].ToString();
            lblTeleOpD5Att.Text = displayDefense5Att[0].ToString();
            lblAutoD5Cross.Text = autoDisplayDefense5Cross[0].ToString();
            lblAutoD5Reach.Text = autoDisplayDefense5Reach[0].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade.Text = displayHighShotMade[0].ToString();
            lblTeleOpHighShotAtt.Text = displayHighShotAtt[0].ToString();
            lblAutoHighShotMade.Text = autoDisplayHighShotMade[0].ToString();
            lblAutoHighShotAtt.Text = autoDisplayHighShotAtt[0].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade.Text = displayLowShotMade[0].ToString();
            lblTeleOpLowShotAtt.Text = displayLowShotAtt[0].ToString();
            lblAutoLowShotMade.Text = autoDisplayLowShotMade[0].ToString();
            lblAutoLowShotAtt.Text = autoDisplayLowShotAtt[0].ToString();

            // Robot Climb
            lblChallengeScale.Text = challengeScale[0].ToString();

            lblTeleOpTotalPoints.Text = teleOpTotalPoints[0].ToString();
            lblAutoTotalPoints.Text = autoTotalPoints[0].ToString();
            lblTotalPoints.Text = (autoTotalPoints[0] + teleOpTotalPoints[0] + challengeScale[0]).ToString();
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
                lblAutoD1Reach2.Visible = false;
                lblTeleOpD1Att2.Visible = true;
                lblAutoD1Cross2.Visible = false;
                lblTeleOpD1Cross2.Visible = true;
                lblAutoD2Reach2.Visible = false;
                lblTeleOpD2Att2.Visible = true;
                lblAutoD2Cross2.Visible = false;
                lblTeleOpD2Cross2.Visible = true;
                lblAutoD3Reach2.Visible = false;
                lblTeleOpD3Att2.Visible = true;
                lblAutoD3Cross2.Visible = false;
                lblTeleOpD3Cross2.Visible = true;
                lblAutoD4Reach2.Visible = false;
                lblTeleOpD4Att2.Visible = true;
                lblAutoD4Cross2.Visible = false;
                lblTeleOpD4Cross2.Visible = true;
                lblAutoD5Reach2.Visible = false;
                lblTeleOpD5Att2.Visible = true;
                lblAutoD5Cross2.Visible = false;
                lblTeleOpD5Cross2.Visible = true;
                lblAutoHighShotAtt2.Visible = false;
                lblTeleOpHighShotAtt2.Visible = true;
                lblAutoHighShotMade2.Visible = false;
                lblTeleOpHighShotMade2.Visible = true;
                lblAutoLowShotAtt2.Visible = false;
                lblTeleOpLowShotAtt2.Visible = true;
                lblAutoLowShotMade2.Visible = false;
                lblTeleOpLowShotMade2.Visible = true;
                lblChallengeScale2.Visible = true;
            }
            if (AutonomousMode[1])
            {
                lblAuto2.Visible = true;
                lblTeleOp2.Visible = false;
                lblAutoD1Reach2.Visible = true;
                lblTeleOpD1Att2.Visible = false;
                lblAutoD1Cross2.Visible = true;
                lblTeleOpD1Cross2.Visible = false;
                lblAutoD2Reach2.Visible = true;
                lblTeleOpD2Att2.Visible = false;
                lblAutoD2Cross2.Visible = true;
                lblTeleOpD2Cross2.Visible = false;
                lblAutoD3Reach2.Visible = true;
                lblTeleOpD3Att2.Visible = false;
                lblAutoD3Cross2.Visible = true;
                lblTeleOpD3Cross2.Visible = false;
                lblAutoD4Reach2.Visible = true;
                lblTeleOpD4Att2.Visible = false;
                lblAutoD4Cross2.Visible = true;
                lblTeleOpD4Cross2.Visible = false;
                lblAutoD5Reach2.Visible = true;
                lblTeleOpD5Att2.Visible = false;
                lblAutoD5Cross2.Visible = true;
                lblTeleOpD5Cross2.Visible = false;
                lblAutoHighShotAtt2.Visible = true;
                lblTeleOpHighShotAtt2.Visible = false;
                lblAutoHighShotMade2.Visible = true;
                lblTeleOpHighShotMade2.Visible = false;
                lblAutoLowShotAtt2.Visible = true;
                lblTeleOpLowShotAtt2.Visible = false;
                lblAutoLowShotMade2.Visible = true;
                lblTeleOpLowShotMade2.Visible = false;
                lblChallengeScale2.Visible = false;
            }
            //Defense Rating
            lblDefense2.Text = displayDefenseRating[1].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross2.Text = displayDefense1Cross[1].ToString();
            lblTeleOpD1Att2.Text = displayDefense1Att[1].ToString();
            lblAutoD1Cross2.Text = autoDisplayDefense1Cross[1].ToString();
            lblAutoD1Reach2.Text = autoDisplayDefense1Reach[1].ToString();

            // High Goals
            lblTeleOpD2Cross2.Text = displayDefense2Cross[1].ToString();
            lblTeleOpD2Att2.Text = displayDefense2Att[1].ToString();
            lblAutoD2Cross2.Text = autoDisplayDefense2Cross[1].ToString();
            lblAutoD2Reach2.Text = autoDisplayDefense2Reach[1].ToString();

            // Mid Goals
            lblTeleOpD3Cross2.Text = displayDefense3Cross[1].ToString();
            lblTeleOpD3Att2.Text = displayDefense3Att[1].ToString();
            lblAutoD3Cross2.Text = autoDisplayDefense3Cross[1].ToString();
            lblAutoD3Reach2.Text = autoDisplayDefense3Reach[1].ToString();

            // Low Goals
            lblTeleOpD4Cross2.Text = displayDefense4Cross[1].ToString();
            lblTeleOpD4Att2.Text = displayDefense4Att[1].ToString();
            lblAutoD4Cross2.Text = autoDisplayDefense4Cross[1].ToString();
            lblAutoD4Reach2.Text = autoDisplayDefense4Reach[1].ToString();

            // Defense 5
            lblTeleOpD5Cross2.Text = displayDefense5Cross[1].ToString();
            lblTeleOpD5Att2.Text = displayDefense5Att[1].ToString();
            lblAutoD5Cross2.Text = autoDisplayDefense5Cross[1].ToString();
            lblAutoD5Reach2.Text = autoDisplayDefense5Reach[1].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade2.Text = displayHighShotMade[1].ToString();
            lblTeleOpHighShotAtt2.Text = displayHighShotAtt[1].ToString();
            lblAutoHighShotMade2.Text = autoDisplayHighShotMade[1].ToString();
            lblAutoHighShotAtt2.Text = autoDisplayHighShotAtt[1].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade2.Text = displayLowShotMade[1].ToString();
            lblTeleOpLowShotAtt2.Text = displayLowShotAtt[1].ToString();
            lblAutoLowShotMade2.Text = autoDisplayLowShotMade[1].ToString();
            lblAutoLowShotAtt2.Text = autoDisplayLowShotAtt[1].ToString();

            // Robot Climb
            lblChallengeScale2.Text = challengeScale[1].ToString();

            lblTeleOpTotalPoints2.Text = teleOpTotalPoints[1].ToString();
            lblAutoTotalPoints2.Text = autoTotalPoints[1].ToString();
            lblTotalPoints2.Text = (autoTotalPoints[1] + teleOpTotalPoints[1] + challengeScale[1]).ToString();
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
                lblAutoD1Reach3.Visible = false;
                lblTeleOpD1Att3.Visible = true;
                lblAutoD1Cross3.Visible = false;
                lblTeleOpD1Cross3.Visible = true;
                lblAutoD1Reach3.Visible = false;
                lblTeleOpD2Att3.Visible = true;
                lblAutoD2Cross3.Visible = false;
                lblTeleOpD2Cross3.Visible = true;
                lblAutoD3Reach3.Visible = false;
                lblTeleOpD3Att3.Visible = true;
                lblAutoD3Cross3.Visible = false;
                lblTeleOpD3Cross3.Visible = true;
                lblAutoD4Reach3.Visible = false;
                lblTeleOpD4Att3.Visible = true;
                lblAutoD4Cross3.Visible = false;
                lblTeleOpD4Cross3.Visible = true;
                lblAutoD5Reach3.Visible = false;
                lblTeleOpD5Att3.Visible = true;
                lblAutoD5Cross3.Visible = false;
                lblTeleOpD5Cross3.Visible = true;
                lblAutoHighShotAtt3.Visible = false;
                lblTeleOpHighShotAtt3.Visible = true;
                lblAutoHighShotMade3.Visible = false;
                lblTeleOpHighShotMade3.Visible = true;
                lblAutoLowShotAtt3.Visible = false;
                lblTeleOpLowShotAtt3.Visible = true;
                lblAutoLowShotMade3.Visible = false;
                lblTeleOpLowShotMade3.Visible = true;
                lblChallengeScale3.Visible = true;
            }
            if (AutonomousMode[2])
            {
                lblAuto3.Visible = true;
                lblTeleOp3.Visible = false;
                lblAutoD1Reach3.Visible = true;
                lblTeleOpD1Att3.Visible = false;
                lblAutoD1Cross3.Visible = true;
                lblTeleOpD1Cross3.Visible = false;
                lblAutoD2Reach3.Visible = true;
                lblTeleOpD2Att3.Visible = false;
                lblAutoD2Cross3.Visible = true;
                lblTeleOpD2Cross3.Visible = false;
                lblAutoD3Reach3.Visible = true;
                lblTeleOpD3Att3.Visible = false;
                lblAutoD3Cross3.Visible = true;
                lblTeleOpD3Cross3.Visible = false;
                lblAutoD4Reach3.Visible = true;
                lblTeleOpD4Att3.Visible = false;
                lblAutoD4Cross3.Visible = true;
                lblTeleOpD4Cross3.Visible = false;
                lblAutoD5Reach3.Visible = true;
                lblTeleOpD5Att3.Visible = false;
                lblAutoD5Cross3.Visible = true;
                lblTeleOpD5Cross3.Visible = false;
                lblAutoHighShotAtt3.Visible = true;
                lblTeleOpHighShotAtt3.Visible = false;
                lblAutoHighShotMade3.Visible = true;
                lblTeleOpHighShotMade3.Visible = false;
                lblAutoLowShotAtt3.Visible = true;
                lblTeleOpLowShotAtt3.Visible = false;
                lblAutoLowShotMade3.Visible = true;
                lblTeleOpLowShotMade3.Visible = false;
                lblChallengeScale3.Visible = false;
            }
            //Defense Rating
            lblDefense3.Text = displayDefenseRating[2].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross3.Text = displayDefense1Cross[2].ToString();
            lblTeleOpD1Att3.Text = displayDefense1Att[2].ToString();
            lblAutoD1Cross3.Text = autoDisplayDefense1Cross[2].ToString();
            lblAutoD1Reach3.Text = autoDisplayDefense1Reach[2].ToString();

            // High Goals
            lblTeleOpD2Cross3.Text = displayDefense2Cross[2].ToString();
            lblTeleOpD2Att3.Text = displayDefense2Att[2].ToString();
            lblAutoD2Cross3.Text = autoDisplayDefense2Cross[2].ToString();
            lblAutoD2Reach3.Text = autoDisplayDefense2Reach[2].ToString();

            // Mid Goals
            lblTeleOpD3Cross3.Text = displayDefense3Cross[2].ToString();
            lblTeleOpD3Att3.Text = displayDefense3Att[2].ToString();
            lblAutoD3Cross3.Text = autoDisplayDefense3Cross[2].ToString();
            lblAutoD3Reach3.Text = autoDisplayDefense3Reach[2].ToString();

            // Low Goals
            lblTeleOpD4Cross3.Text = displayDefense4Cross[2].ToString();
            lblTeleOpD4Att3.Text = displayDefense4Att[2].ToString();
            lblAutoD4Cross3.Text = autoDisplayDefense4Cross[2].ToString();
            lblAutoD4Reach3.Text = autoDisplayDefense4Reach[2].ToString();

            // Defense 5
            lblTeleOpD5Cross3.Text = displayDefense5Cross[2].ToString();
            lblTeleOpD5Att3.Text = displayDefense5Att[2].ToString();
            lblAutoD5Cross3.Text = autoDisplayDefense5Cross[2].ToString();
            lblAutoD5Reach3.Text = autoDisplayDefense5Reach[2].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade3.Text = displayHighShotMade[2].ToString();
            lblTeleOpHighShotAtt3.Text = displayHighShotAtt[2].ToString();
            lblAutoHighShotMade3.Text = autoDisplayHighShotMade[2].ToString();
            lblAutoHighShotAtt3.Text = autoDisplayHighShotAtt[2].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade3.Text = displayLowShotMade[2].ToString();
            lblTeleOpLowShotAtt3.Text = displayLowShotAtt[2].ToString();
            lblAutoLowShotMade3.Text = autoDisplayLowShotMade[2].ToString();
            lblAutoLowShotAtt3.Text = autoDisplayLowShotAtt[2].ToString();

            // Robot Climb
            lblChallengeScale3.Text = challengeScale[2].ToString();

            lblTeleOpTotalPoints3.Text = teleOpTotalPoints[2].ToString();
            lblAutoTotalPoints3.Text = autoTotalPoints[2].ToString();
            lblTotalPoints3.Text = (autoTotalPoints[2] + teleOpTotalPoints[2] + challengeScale[2]).ToString();
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
                lblAutoD1Reach4.Visible = false;
                lblTeleOpD1Att4.Visible = true;
                lblAutoD1Cross4.Visible = false;
                lblTeleOpD1Cross4.Visible = true;
                lblAutoD2Reach4.Visible = false;
                lblTeleOpD2Att4.Visible = true;
                lblAutoD2Cross4.Visible = false;
                lblTeleOpD2Cross4.Visible = true;
                lblAutoD3Reach4.Visible = false;
                lblTeleOpD3Att4.Visible = true;
                lblAutoD3Cross4.Visible = false;
                lblTeleOpD3Cross4.Visible = true;
                lblAutoD4Reach4.Visible = false;
                lblTeleOpD4Att4.Visible = true;
                lblAutoD4Cross4.Visible = false;
                lblTeleOpD4Cross4.Visible = true;
                lblAutoD5Reach4.Visible = false;
                lblTeleOpD5Att4.Visible = true;
                lblAutoD5Cross4.Visible = false;
                lblTeleOpD5Cross4.Visible = true;
                lblAutoHighShotAtt4.Visible = false;
                lblTeleOpHighShotAtt4.Visible = true;
                lblAutoHighShotMade4.Visible = false;
                lblTeleOpHighShotMade4.Visible = true;
                lblAutoLowShotAtt4.Visible = false;
                lblTeleOpLowShotAtt4.Visible = true;
                lblAutoLowShotMade4.Visible = false;
                lblTeleOpLowShotMade4.Visible = true;
                lblChallengeScale4.Visible = true;
            }
            if (AutonomousMode[3])
            {
                lblAuto4.Visible = true;
                lblTeleOp4.Visible = false;
                lblAutoD1Reach4.Visible = true;
                lblTeleOpD1Att4.Visible = false;
                lblAutoD1Cross4.Visible = true;
                lblTeleOpD1Cross4.Visible = false;
                lblAutoD2Reach4.Visible = true;
                lblTeleOpD2Att4.Visible = false;
                lblAutoD2Cross4.Visible = true;
                lblTeleOpD2Cross4.Visible = false;
                lblAutoD3Reach4.Visible = true;
                lblTeleOpD3Att4.Visible = false;
                lblAutoD3Cross4.Visible = true;
                lblTeleOpD3Cross4.Visible = false;
                lblAutoD4Reach4.Visible = true;
                lblTeleOpD4Att4.Visible = false;
                lblAutoD4Cross4.Visible = true;
                lblTeleOpD4Cross4.Visible = false;
                lblAutoD5Reach4.Visible = true;
                lblTeleOpD5Att4.Visible = false;
                lblAutoD5Cross4.Visible = true;
                lblTeleOpD5Cross4.Visible = false;
                lblAutoHighShotAtt4.Visible = true;
                lblTeleOpHighShotAtt4.Visible = false;
                lblAutoHighShotMade4.Visible = true;
                lblTeleOpHighShotMade4.Visible = false;
                lblAutoLowShotAtt4.Visible = true;
                lblTeleOpLowShotAtt4.Visible = false;
                lblAutoLowShotMade4.Visible = true;
                lblTeleOpLowShotMade4.Visible = false;
                lblChallengeScale4.Visible = false;
            }
            //Defense Rating
            lblDefense4.Text = displayDefenseRating[3].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross4.Text = displayDefense1Cross[3].ToString();
            lblTeleOpD1Att4.Text = displayDefense1Att[3].ToString();
            lblAutoD1Cross4.Text = autoDisplayDefense1Cross[3].ToString();
            lblAutoD1Reach4.Text = autoDisplayDefense1Reach[3].ToString();

            // High Goals
            lblTeleOpD2Cross4.Text = displayDefense2Cross[3].ToString();
            lblTeleOpD2Att4.Text = displayDefense2Att[3].ToString();
            lblAutoD2Cross4.Text = autoDisplayDefense2Cross[3].ToString();
            lblAutoD2Reach4.Text = autoDisplayDefense2Reach[3].ToString();

            // Mid Goals
            lblTeleOpD3Cross4.Text = displayDefense3Cross[3].ToString();
            lblTeleOpD3Att4.Text = displayDefense3Att[3].ToString();
            lblAutoD3Cross4.Text = autoDisplayDefense3Cross[3].ToString();
            lblAutoD3Reach4.Text = autoDisplayDefense3Reach[3].ToString();

            // Low Goals
            lblTeleOpD4Cross4.Text = displayDefense4Cross[3].ToString();
            lblTeleOpD4Att4.Text = displayDefense4Att[3].ToString();
            lblAutoD4Cross4.Text = autoDisplayDefense4Cross[3].ToString();
            lblAutoD4Reach4.Text = autoDisplayDefense4Reach[3].ToString();

            // Defense 5
            lblTeleOpD5Cross4.Text = displayDefense5Cross[3].ToString();
            lblTeleOpD5Att4.Text = displayDefense5Att[3].ToString();
            lblAutoD5Cross4.Text = autoDisplayDefense5Cross[3].ToString();
            lblAutoD5Reach4.Text = autoDisplayDefense5Reach[3].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade4.Text = displayHighShotMade[3].ToString();
            lblTeleOpHighShotAtt4.Text = displayHighShotAtt[3].ToString();
            lblAutoHighShotMade4.Text = autoDisplayHighShotMade[3].ToString();
            lblAutoHighShotAtt4.Text = autoDisplayHighShotAtt[3].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade4.Text = displayLowShotMade[3].ToString();
            lblTeleOpLowShotAtt4.Text = displayLowShotAtt[3].ToString();
            lblAutoLowShotMade4.Text = autoDisplayLowShotMade[3].ToString();
            lblAutoLowShotAtt4.Text = autoDisplayLowShotAtt[3].ToString();

            // Robot Climb
            lblChallengeScale4.Text = challengeScale[3].ToString();

            lblTeleOpTotalPoints4.Text = teleOpTotalPoints[3].ToString();
            lblAutoTotalPoints4.Text = autoTotalPoints[3].ToString();
            lblTotalPoints4.Text = (autoTotalPoints[3] + teleOpTotalPoints[3] + challengeScale[3]).ToString();
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
                lblAutoD1Reach5.Visible = false;
                lblTeleOpD1Att5.Visible = true;
                lblAutoD1Cross5.Visible = false;
                lblTeleOpD1Cross5.Visible = true;
                lblAutoD2Reach5.Visible = false;
                lblTeleOpD2Att5.Visible = true;
                lblAutoD2Cross5.Visible = false;
                lblTeleOpD2Cross5.Visible = true;
                lblAutoD3Reach5.Visible = false;
                lblTeleOpD3Att5.Visible = true;
                lblAutoD3Cross5.Visible = false;
                lblTeleOpD3Cross5.Visible = true;
                lblAutoD4Reach5.Visible = false;
                lblTeleOpD4Att5.Visible = true;
                lblAutoD4Cross5.Visible = false;
                lblTeleOpD4Cross5.Visible = true;
                lblAutoD5Reach5.Visible = false;
                lblTeleOpD5Att5.Visible = true;
                lblAutoD5Cross5.Visible = false;
                lblTeleOpD5Cross5.Visible = true;
                lblAutoHighShotAtt5.Visible = false;
                lblTeleOpHighShotAtt5.Visible = true;
                lblAutoHighShotMade5.Visible = false;
                lblTeleOpHighShotMade5.Visible = true;
                lblAutoLowShotAtt5.Visible = false;
                lblTeleOpLowShotAtt5.Visible = true;
                lblAutoLowShotMade5.Visible = false;
                lblTeleOpLowShotMade5.Visible = true;
                lblChallengeScale5.Visible = true;
            }
            if (AutonomousMode[4])
            {
                lblAuto5.Visible = true;
                lblTeleOp5.Visible = false;
                lblAutoD1Reach5.Visible = true;
                lblTeleOpD1Att5.Visible = false;
                lblAutoD1Cross5.Visible = true;
                lblTeleOpD1Cross5.Visible = false;
                lblAutoD2Reach5.Visible = true;
                lblTeleOpD2Att5.Visible = false;
                lblAutoD2Cross5.Visible = true;
                lblTeleOpD2Cross5.Visible = false;
                lblAutoD3Reach5.Visible = true;
                lblTeleOpD3Att5.Visible = false;
                lblAutoD3Cross5.Visible = true;
                lblTeleOpD3Cross5.Visible = false;
                lblAutoD4Reach5.Visible = true;
                lblTeleOpD4Att5.Visible = false;
                lblAutoD4Cross5.Visible = true;
                lblTeleOpD4Cross5.Visible = false;
                lblAutoD5Reach5.Visible = true;
                lblTeleOpD5Att5.Visible = false;
                lblAutoD5Cross5.Visible = true;
                lblTeleOpD5Cross5.Visible = false;
                lblAutoHighShotAtt5.Visible = true;
                lblTeleOpHighShotAtt5.Visible = false;
                lblAutoHighShotMade5.Visible = true;
                lblTeleOpHighShotMade5.Visible = false;
                lblAutoLowShotAtt5.Visible = true;
                lblTeleOpLowShotAtt5.Visible = false;
                lblAutoLowShotMade5.Visible = true;
                lblTeleOpLowShotMade5.Visible = false;
                lblChallengeScale5.Visible = false;
            }
            //Defense Rating
            lblDefense5.Text = displayDefenseRating[4].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross5.Text = displayDefense1Cross[4].ToString();
            lblTeleOpD1Att5.Text = displayDefense1Att[4].ToString();
            lblAutoD1Cross5.Text = autoDisplayDefense1Cross[4].ToString();
            lblAutoD1Reach5.Text = autoDisplayDefense1Reach[4].ToString();

            // High Goals
            lblTeleOpD2Cross5.Text = displayDefense2Cross[4].ToString();
            lblTeleOpD2Att5.Text = displayDefense2Att[4].ToString();
            lblAutoD2Cross5.Text = autoDisplayDefense2Cross[4].ToString();
            lblAutoD2Reach5.Text = autoDisplayDefense2Reach[4].ToString();

            // Mid Goals
            lblTeleOpD3Cross5.Text = displayDefense3Cross[4].ToString();
            lblTeleOpD3Att5.Text = displayDefense3Att[4].ToString();
            lblAutoD3Cross5.Text = autoDisplayDefense3Cross[4].ToString();
            lblAutoD3Reach5.Text = autoDisplayDefense3Reach[4].ToString();

            // Low Goals
            lblTeleOpD4Cross5.Text = displayDefense4Cross[4].ToString();
            lblTeleOpD4Att5.Text = displayDefense4Att[4].ToString();
            lblAutoD4Cross5.Text = autoDisplayDefense4Cross[4].ToString();
            lblAutoD4Reach5.Text = autoDisplayDefense4Reach[4].ToString();

            // Defense 5
            lblTeleOpD5Cross5.Text = displayDefense5Cross[4].ToString();
            lblTeleOpD5Att5.Text = displayDefense5Att[4].ToString();
            lblAutoD5Cross5.Text = autoDisplayDefense5Cross[4].ToString();
            lblAutoD5Reach5.Text = autoDisplayDefense5Reach[4].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade5.Text = displayHighShotMade[4].ToString();
            lblTeleOpHighShotAtt5.Text = displayHighShotAtt[4].ToString();
            lblAutoHighShotMade5.Text = autoDisplayHighShotMade[4].ToString();
            lblAutoHighShotAtt5.Text = autoDisplayHighShotAtt[4].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade5.Text = displayLowShotMade[4].ToString();
            lblTeleOpLowShotAtt5.Text = displayLowShotAtt[4].ToString();
            lblAutoLowShotMade5.Text = autoDisplayLowShotMade[4].ToString();
            lblAutoLowShotAtt5.Text = autoDisplayLowShotAtt[4].ToString();

            // Robot Climb
            lblChallengeScale5.Text = challengeScale[4].ToString();

            lblTeleOpTotalPoints5.Text = teleOpTotalPoints[4].ToString();
            lblAutoTotalPoints5.Text = autoTotalPoints[4].ToString();
            lblTotalPoints5.Text = (autoTotalPoints[4] + teleOpTotalPoints[4] + challengeScale[4]).ToString();

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
                lblAutoD1Reach6.Visible = false;
                lblTeleOpD1Att6.Visible = true;
                lblAutoD1Cross6.Visible = false;
                lblTeleOpD1Cross6.Visible = true;
                lblAutoD2Reach6.Visible = false;
                lblTeleOpD2Att6.Visible = true;
                lblAutoD2Cross6.Visible = false;
                lblTeleOpD2Cross6.Visible = true;
                lblAutoD3Reach6.Visible = false;
                lblTeleOpD3Att6.Visible = true;
                lblAutoD3Cross6.Visible = false;
                lblTeleOpD3Cross6.Visible = true;
                lblAutoD4Reach6.Visible = false;
                lblTeleOpD4Att6.Visible = true;
                lblAutoD4Cross6.Visible = false;
                lblTeleOpD4Cross6.Visible = true;
                lblAutoD5Reach6.Visible = false;
                lblTeleOpD5Att6.Visible = true;
                lblAutoD5Cross6.Visible = false;
                lblTeleOpD5Cross6.Visible = true;
                lblAutoHighShotAtt6.Visible = false;
                lblTeleOpHighShotAtt6.Visible = true;
                lblAutoHighShotMade6.Visible = false;
                lblTeleOpHighShotMade6.Visible = true;
                lblAutoLowShotAtt6.Visible = false;
                lblTeleOpLowShotAtt6.Visible = true;
                lblAutoLowShotMade6.Visible = false;
                lblTeleOpLowShotMade6.Visible = true;
                lblChallengeScale6.Visible = true;
            }
            if (AutonomousMode[5])
            {
                lblAuto6.Visible = true;
                lblTeleOp6.Visible = false;
                lblAutoD1Reach6.Visible = true;
                lblTeleOpD1Att6.Visible = false;
                lblAutoD1Cross6.Visible = true;
                lblTeleOpD1Cross6.Visible = false;
                lblAutoD2Reach6.Visible = true;
                lblTeleOpD2Att6.Visible = false;
                lblAutoD2Cross6.Visible = true;
                lblTeleOpD2Cross6.Visible = false;
                lblAutoD3Reach6.Visible = true;
                lblTeleOpD3Att6.Visible = false;
                lblAutoD3Cross6.Visible = true;
                lblTeleOpD3Cross6.Visible = false;
                lblAutoD4Reach6.Visible = true;
                lblTeleOpD4Att6.Visible = false;
                lblAutoD4Cross6.Visible = true;
                lblTeleOpD4Cross6.Visible = false;
                lblAutoD5Reach6.Visible = true;
                lblTeleOpD5Att6.Visible = false;
                lblAutoD5Cross6.Visible = true;
                lblTeleOpD5Cross6.Visible = false;
                lblAutoHighShotAtt6.Visible = true;
                lblTeleOpHighShotAtt6.Visible = false;
                lblAutoHighShotMade6.Visible = true;
                lblTeleOpHighShotMade6.Visible = false;
                lblAutoLowShotAtt6.Visible = true;
                lblTeleOpLowShotAtt6.Visible = false;
                lblAutoLowShotMade6.Visible = true;
                lblTeleOpLowShotMade6.Visible = false;
                lblChallengeScale6.Visible = false;
            }
            //Defense Rating
            lblDefense6.Text = displayDefenseRating[5].ToString();

            // Pyramid Goals
            lblTeleOpD1Cross6.Text = displayDefense1Cross[5].ToString();
            lblTeleOpD1Att6.Text = displayDefense1Att[5].ToString();
            lblAutoD1Cross6.Text = autoDisplayDefense1Cross[5].ToString();
            lblAutoD1Reach6.Text = autoDisplayDefense1Reach[5].ToString();

            // High Goals
            lblTeleOpD2Cross6.Text = displayDefense2Cross[5].ToString();
            lblTeleOpD2Att6.Text = displayDefense2Att[5].ToString();
            lblAutoD2Cross6.Text = autoDisplayDefense2Cross[5].ToString();
            lblAutoD2Reach6.Text = autoDisplayDefense2Reach[5].ToString();

            // Mid Goals
            lblTeleOpD3Cross6.Text = displayDefense3Cross[5].ToString();
            lblTeleOpD3Att6.Text = displayDefense3Att[5].ToString();
            lblAutoD3Cross6.Text = autoDisplayDefense3Cross[5].ToString();
            lblAutoD3Reach6.Text = autoDisplayDefense3Reach[5].ToString();

            // Low Goals
            lblTeleOpD4Cross6.Text = displayDefense4Cross[5].ToString();
            lblTeleOpD4Att6.Text = displayDefense4Att[5].ToString();
            lblAutoD4Cross6.Text = autoDisplayDefense4Cross[5].ToString();
            lblAutoD4Reach6.Text = autoDisplayDefense4Reach[5].ToString();

            // Defense 5
            lblTeleOpD5Cross6.Text = displayDefense5Cross[5].ToString();
            lblTeleOpD5Att6.Text = displayDefense5Att[5].ToString();
            lblAutoD5Cross6.Text = autoDisplayDefense5Cross[5].ToString();
            lblAutoD5Reach6.Text = autoDisplayDefense5Reach[5].ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade6.Text = displayHighShotMade[5].ToString();
            lblTeleOpHighShotAtt6.Text = displayHighShotAtt[5].ToString();
            lblAutoHighShotMade6.Text = autoDisplayHighShotMade[5].ToString();
            lblAutoHighShotAtt6.Text = autoDisplayHighShotAtt[5].ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade6.Text = displayLowShotMade[5].ToString();
            lblTeleOpLowShotAtt6.Text = displayLowShotAtt[5].ToString();
            lblAutoLowShotMade6.Text = autoDisplayLowShotMade[5].ToString();
            lblAutoLowShotAtt6.Text = autoDisplayLowShotAtt[5].ToString();

            // Robot Climb
            lblChallengeScale6.Text = challengeScale[5].ToString();

            lblTeleOpTotalPoints6.Text = teleOpTotalPoints[5].ToString();
            lblAutoTotalPoints6.Text = autoTotalPoints[5].ToString();
            lblTotalPoints6.Text = (autoTotalPoints[5] + teleOpTotalPoints[5] + challengeScale[5]).ToString();

            if (FinshedScoring[5])
                lblTeleOp6.ForeColor = Color.DarkGreen;
            else
                lblTeleOp6.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));


        }
        void tm1939ProcessButton(string strButtonMap, int id)
        {
            int FoundAt;

            // Find where the button maps are equal to get the command
            for (FoundAt = 0; FoundAt < 34 && !strButtonMap.Equals(ControllerCommands[id, FoundAt]); FoundAt++)
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

                case (GameCommands.Defense2AttMinus):
                    if (TeleOp[id])
                    {
                        if (defense2Att[id] > 0 && defense2Cross[id] < defense2Att[id])
                        {
                            defense2Att[id]--;
                            displayDefense2Att[id] = defense2Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense2Reach[id] > 0 && autoDefense2Cross[id] < autoDefense2Reach[id])
                        {
                            autoDefense2Reach[id]--;
                            autoDisplayDefense2Reach[id] = autoDefense2Reach[id];
                        }
                    }

                    break;

                case (GameCommands.Defense2AttPlus):
                    if (TeleOp[id])
                    {
                        defense2Att[id]++;
                        displayDefense2Att[id] = defense2Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense2Reach[id]++;
                        autoDisplayDefense2Reach[id] = autoDefense2Reach[id];
                    }

                    break;

                case (GameCommands.Defense2CrossMinus):
                    if (TeleOp[id])
                    {
                        if (defense2Cross[id] > 0)
                        {
                            defense2Cross[id]--;
                            displayDefense2Cross[id] = defense2Cross[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense2Cross[id] > 0)
                        {
                            autoDefense2Cross[id]--;
                            autoDisplayDefense2Cross[id] = autoDefense2Cross[id];
                        }
                    }
                    break;

                case (GameCommands.Defense2CrossPlus):
                    if (TeleOp[id])
                    {
                        defense2Cross[id]++;
                        displayDefense2Cross[id] = defense2Cross[id];
                        defense2Att[id]++;
                        displayDefense2Att[id] = defense2Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense2Cross[id]++;
                        autoDisplayDefense2Cross[id] = autoDefense2Cross[id];
                        autoDefense2Reach[id]++;
                        autoDisplayDefense2Reach[id] = autoDefense2Reach[id];
                    }
                    break;

                case (GameCommands.Defense4AttMinus):
                    if (TeleOp[id])
                    {
                        if (defense4Att[id] > 0 && defense4Cross[id] < defense4Att[id])
                        {
                            defense4Att[id]--;
                            displayDefense4Att[id] = defense4Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense4Reach[id] > 0 && autoDefense4Cross[id] < autoDefense4Reach[id])
                        {
                            autoDefense4Reach[id]--;
                            autoDisplayDefense4Reach[id] = autoDefense4Reach[id];
                        }
                    }

                    break;

                case (GameCommands.Defense4AttPlus):
                    if (TeleOp[id])
                    {
                        defense4Att[id]++;
                        displayDefense4Att[id] = defense4Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense4Reach[id]++;
                        autoDisplayDefense4Reach[id] = autoDefense4Reach[id];
                    }


                    break;

                case (GameCommands.Defense4CrossMinus):
                    if (TeleOp[id])
                    {
                        if (defense4Cross[id] > 0)
                        {
                            defense4Cross[id]--;
                            displayDefense4Cross[id] = defense4Cross[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense4Cross[id] > 0)
                        {
                            autoDefense4Cross[id]--;
                            autoDisplayDefense4Cross[id] = autoDefense4Cross[id];
                        }
                    }

                    break;

                case (GameCommands.Defense4CrossPlus):
                    if (TeleOp[id])
                    {
                        defense4Cross[id]++;
                        displayDefense4Cross[id] = defense4Cross[id];
                        defense4Att[id]++;
                        displayDefense4Att[id] = defense4Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense4Cross[id]++;
                        autoDisplayDefense4Cross[id] = autoDefense4Cross[id];
                        autoDefense4Reach[id]++;
                        autoDisplayDefense4Reach[id] = autoDefense4Reach[id];
                    }

                    break;

                case (GameCommands.Defense5AttPlus):
                    if (TeleOp[id])
                    {
                        defense5Att[id]++;
                        displayDefense5Att[id] = defense5Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense5Reach[id]++;
                        autoDisplayDefense5Reach[id] = autoDefense5Reach[id];
                    }


                    break;

                case (GameCommands.Defense5CrossMinus):
                    if (TeleOp[id])
                    {
                        if (defense5Cross[id] > 0)
                        {
                            defense5Cross[id]--;
                            displayDefense5Cross[id] = defense5Cross[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense5Cross[id] > 0)
                        {
                            autoDefense5Cross[id]--;
                            autoDisplayDefense5Cross[id] = autoDefense5Cross[id];
                        }
                    }

                    break;

                case (GameCommands.Defense5CrossPlus):
                    if (TeleOp[id])
                    {
                        defense5Cross[id]++;
                        displayDefense5Cross[id] = defense5Cross[id];
                        defense5Att[id]++;
                        displayDefense5Att[id] = defense5Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense5Cross[id]++;
                        autoDisplayDefense5Cross[id] = autoDefense5Cross[id];
                        autoDefense5Reach[id]++;
                        autoDisplayDefense5Reach[id] = autoDefense5Reach[id];
                    }

                    break;

                case (GameCommands.Defense3AttMinus):
                    if (TeleOp[id])
                    {
                        if (defense3Att[id] > 0 && defense3Cross[id] < defense3Att[id])
                        {
                            defense3Att[id]--;
                            displayDefense3Att[id] = defense3Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense3Reach[id] > 0 && autoDefense3Cross[id] < autoDefense3Reach[id])
                        {
                            autoDefense3Reach[id]--;
                            autoDisplayDefense3Reach[id] = autoDefense3Reach[id];
                        }
                    }
                    break;

                case (GameCommands.Defense3AttPlus):
                    if (TeleOp[id])
                    {
                        defense3Att[id]++;
                        displayDefense3Att[id] = defense3Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense3Reach[id]++;
                        autoDisplayDefense3Reach[id] = autoDefense3Reach[id];
                    }


                    break;

                case (GameCommands.Defense3CrossMinus):
                    if (TeleOp[id])
                    {
                        if (defense3Cross[id] > 0)
                        {
                            defense3Cross[id]--;
                            displayDefense3Cross[id] = defense3Cross[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense3Cross[id] > 0)
                        {
                            autoDefense3Cross[id]--;
                            autoDisplayDefense3Cross[id] = autoDefense3Cross[id];
                        }
                    }

                    break;

                case (GameCommands.Defense3CrossPlus):
                    if (TeleOp[id])
                    {
                        defense3Cross[id]++;
                        displayDefense3Cross[id] = defense3Cross[id];
                        defense3Att[id]++;
                        displayDefense3Att[id] = defense3Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense3Cross[id]++;
                        autoDisplayDefense3Cross[id] = autoDefense3Cross[id];
                        autoDefense3Reach[id]++;
                        autoDisplayDefense3Reach[id] = autoDefense3Reach[id];
                    }

                    break;

                case (GameCommands.Defense1AttMinus):
                    if (TeleOp[id])
                    {
                        if (defense1Att[id] > 0 && defense1Cross[id] < defense1Att[id])
                        {
                            defense1Att[id]--;
                            displayDefense1Att[id] = defense1Att[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense1Reach[id] > 0 && autoDefense1Cross[id] < autoDefense1Reach[id])
                        {
                            autoDefense1Reach[id]--;
                            autoDisplayDefense1Reach[id] = autoDefense1Reach[id];
                        }
                    }

                    break;

                case (GameCommands.Defense1AttPlus):
                    if (TeleOp[id])
                    {
                        defense1Att[id]++;
                        displayDefense1Att[id] = defense1Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense1Reach[id]++;
                        autoDisplayDefense1Reach[id] = autoDefense1Reach[id];
                    }
                    break;

                case (GameCommands.Defense1CrossMinus):
                    if (TeleOp[id])
                    {
                        if (defense1Cross[id] > 0)
                        {
                            defense1Cross[id]--;
                            displayDefense1Cross[id] = defense1Cross[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoDefense1Cross[id] > 0)
                        {
                            autoDefense1Cross[id]--;
                            autoDisplayDefense1Cross[id] = autoDefense1Cross[id];
                        }
                    }
                    break;

                case (GameCommands.Defense1CrossPlus):
                    if (TeleOp[id])
                    {
                        defense1Cross[id]++;
                        displayDefense1Cross[id] = defense1Cross[id];
                        defense1Att[id]++;
                        displayDefense1Att[id] = defense1Att[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoDefense1Cross[id]++;
                        autoDisplayDefense1Cross[id] = autoDefense1Cross[id];
                        autoDefense1Reach[id]++;
                        autoDisplayDefense1Reach[id] = autoDefense1Reach[id];
                    }

                    break;

                case (GameCommands.HighShotAttMinus):
                    if (TeleOp[id])
                    {
                        if (highShotAtt[id] > 0 && highShotMade[id] < highShotAtt[id])
                        {
                            highShotAtt[id]--;
                            displayHighShotAtt[id] = highShotAtt[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoHighShotAtt[id] > 0 && autoHighShotMade[id] < autoHighShotAtt[id])
                        {
                            autoHighShotAtt[id]--;
                            autoDisplayHighShotAtt[id] = autoHighShotAtt[id];
                        }
                    }

                    break;

                case (GameCommands.HighShotAttPlus):
                    if (TeleOp[id])
                    {
                        highShotAtt[id]++;
                        displayHighShotAtt[id] = highShotAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoHighShotAtt[id]++;
                        autoDisplayHighShotAtt[id] = autoHighShotAtt[id];
                    }
                    break;

                case (GameCommands.HighShotMadeMinus):
                    if (TeleOp[id])
                    {
                        if (highShotMade[id] > 0)
                        {
                            highShotMade[id]--;
                            displayHighShotMade[id] = highShotMade[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoHighShotMade[id] > 0)
                        {
                            autoHighShotMade[id]--;
                            autoDisplayHighShotMade[id] = autoHighShotMade[id];
                        }
                    }
                    break;

                case (GameCommands.HighShotMadePlus):
                    if (TeleOp[id])
                    {
                        highShotMade[id]++;
                        displayHighShotMade[id] = highShotMade[id];
                        highShotAtt[id]++;
                        displayHighShotAtt[id] = highShotAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoHighShotMade[id]++;
                        autoDisplayHighShotMade[id] = autoHighShotMade[id];
                        autoHighShotAtt[id]++;
                        autoDisplayHighShotAtt[id] = autoHighShotAtt[id];
                    }

                    break;

                case (GameCommands.LowShotAttMinus):
                    if (TeleOp[id])
                    {
                        if (lowShotAtt[id] > 0 && lowShotMade[id] < lowShotAtt[id])
                        {
                            lowShotAtt[id]--;
                            displayLowShotAtt[id] = lowShotAtt[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoLowShotAtt[id] > 0 && autoLowShotMade[id] < autoLowShotAtt[id])
                        {
                            autoLowShotAtt[id]--;
                            autoDisplayLowShotAtt[id] = autoLowShotAtt[id];
                        }
                    }

                    break;

                case (GameCommands.LowShotAttPlus):
                    if (TeleOp[id])
                    {
                        lowShotAtt[id]++;
                        displayLowShotAtt[id] = lowShotAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoLowShotAtt[id]++;
                        autoDisplayLowShotAtt[id] = autoLowShotAtt[id];
                    }
                    break;

                case (GameCommands.LowShotMadeMinus):
                    if (TeleOp[id])
                    {
                        if (lowShotMade[id] > 0)
                        {
                            lowShotMade[id]--;
                            displayLowShotMade[id] = lowShotMade[id];
                        }
                    }
                    if (AutonomousMode[id])
                    {
                        if (autoLowShotMade[id] > 0)
                        {
                            autoLowShotMade[id]--;
                            autoDisplayLowShotMade[id] = autoLowShotMade[id];
                        }
                    }
                    break;

                case (GameCommands.LowShotMadePlus):
                    if (TeleOp[id])
                    {
                        lowShotMade[id]++;
                        displayLowShotMade[id] = lowShotMade[id];
                        lowShotAtt[id]++;
                        displayLowShotAtt[id] = lowShotAtt[id];
                    }
                    if (AutonomousMode[id])
                    {
                        autoLowShotMade[id]++;
                        autoDisplayLowShotMade[id] = autoLowShotMade[id];
                        autoLowShotAtt[id]++;
                        autoDisplayLowShotAtt[id] = autoLowShotAtt[id];
                    }

                    break;

                case (GameCommands.ChallengeScalePlus):
                    if (TeleOp[id])
                    {
                        climb[id]++;
                        challengeScale[id] = climb[id];

                        if (challengeScale[id] > 2) // 0 = not done, 1 = challenge, 2 = scale
                        {
                            challengeScale[id] = 0;
                            climb[id] = 0;
                        }

                        //This line multiplied by 10 for points, and is not relevant
                        //robotClimb[id] = robotClimb[id] * 10;
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
                    displayDefense5Cross[f] = 0;
                    displayDefense5Att[f] = 0;
                    defense5Cross[f] = 0;
                    defense5Att[f] = 0;
                    autoDisplayDefense5Cross[f] = 0;
                    autoDefense5Cross[f] = 0;
                    autoDisplayDefense5Reach[f] = 0;
                    autoDefense5Reach[f] = 0;
                    displayDefense4Cross[f] = 0;
                    displayDefense4Att[f] = 0;
                    defense4Cross[f] = 0;
                    defense4Att[f] = 0;
                    autoDisplayDefense4Cross[f] = 0;
                    autoDefense4Cross[f] = 0;
                    autoDisplayDefense4Reach[f] = 0;
                    autoDefense4Reach[f] = 0;
                    displayDefense3Cross[f] = 0;
                    defense3Cross[f] = 0;
                    displayDefense3Att[f] = 0;
                    defense3Att[f] = 0;
                    autoDisplayDefense3Cross[f] = 0;
                    autoDefense3Cross[f] = 0;
                    autoDisplayDefense3Reach[f] = 0;
                    autoDefense3Reach[f] = 0;
                    displayDefense2Cross[f] = 0;
                    defense2Cross[f] = 0;
                    displayDefense2Att[f] = 0;
                    defense2Att[f] = 0;
                    autoDisplayDefense2Cross[f] = 0;
                    autoDefense2Cross[f] = 0;
                    autoDisplayDefense2Reach[f] = 0;
                    autoDefense2Reach[f] = 0;
                    autoDisplayDefense1Cross[f] = 0;
                    autoDefense1Cross[f] = 0;
                    autoDisplayDefense1Reach[f] = 0;
                    autoDefense1Reach[f] = 0;
                    displayDefense1Cross[f] = 0;
                    defense1Cross[f] = 0;
                    displayDefense1Att[f] = 0;
                    defense1Att[f] = 0;
                    autoDisplayHighShotMade[f] = 0;
                    autoHighShotMade[f] = 0;
                    autoDisplayHighShotAtt[f] = 0;
                    autoHighShotAtt[f] = 0;
                    displayHighShotMade[f] = 0;
                    highShotMade[f] = 0;
                    displayHighShotAtt[f] = 0;
                    highShotAtt[f] = 0;
                    autoDisplayLowShotMade[f] = 0;
                    autoLowShotMade[f] = 0;
                    autoDisplayLowShotAtt[f] = 0;
                    autoLowShotAtt[f] = 0;
                    displayLowShotMade[f] = 0;
                    lowShotMade[f] = 0;
                    displayLowShotAtt[f] = 0;
                    lowShotAtt[f] = 0;
                    climb[f] = 0;
                    challengeScale[f] = 0;
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
                    lblChallengeScale.Visible = false;
                    lblChallengeScale2.Visible = false;
                    lblChallengeScale3.Visible = false;
                    lblChallengeScale4.Visible = false;
                    lblChallengeScale5.Visible = false;
                    lblChallengeScale6.Visible = false;
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
                displayDefense5Cross[f] = 0;
                displayDefense5Att[f] = 0;
                defense5Cross[f] = 0;
                defense5Att[f] = 0;
                autoDisplayDefense5Cross[f] = 0;
                autoDefense5Cross[f] = 0;
                autoDisplayDefense5Reach[f] = 0;
                autoDefense5Reach[f] = 0;
                displayDefense4Cross[f] = 0;
                displayDefense4Att[f] = 0;
                defense4Cross[f] = 0;
                defense4Att[f] = 0;
                autoDisplayDefense4Cross[f] = 0;
                autoDefense4Cross[f] = 0;
                autoDisplayDefense4Reach[f] = 0;
                autoDefense4Reach[f] = 0;
                displayDefense3Cross[f] = 0;
                defense3Cross[f] = 0;
                displayDefense3Att[f] = 0;
                defense3Att[f] = 0;
                autoDisplayDefense3Cross[f] = 0;
                autoDefense3Cross[f] = 0;
                autoDisplayDefense3Reach[f] = 0;
                autoDefense3Reach[f] = 0;
                displayDefense2Cross[f] = 0;
                defense2Cross[f] = 0;
                displayDefense2Att[f] = 0;
                defense2Att[f] = 0;
                autoDisplayDefense2Cross[f] = 0;
                autoDefense2Cross[f] = 0;
                autoDisplayDefense2Reach[f] = 0;
                autoDefense2Reach[f] = 0;
                displayDefense1Cross[f] = 0;
                defense1Cross[f] = 0;
                displayDefense1Att[f] = 0;
                defense1Att[f] = 0;
                autoDisplayHighShotMade[f] = 0;
                autoHighShotMade[f] = 0;
                autoDisplayHighShotAtt[f] = 0;
                autoHighShotAtt[f] = 0;
                displayHighShotMade[f] = 0;
                highShotMade[f] = 0;
                displayHighShotAtt[f] = 0;
                highShotAtt[f] = 0;
                autoDisplayLowShotMade[f] = 0;
                autoLowShotMade[f] = 0;
                autoDisplayLowShotAtt[f] = 0;
                autoLowShotAtt[f] = 0;
                displayLowShotMade[f] = 0;
                lowShotMade[f] = 0;
                displayLowShotAtt[f] = 0;
                lowShotAtt[f] = 0;
                climb[f] = 0;
                challengeScale[f] = 0;
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
            lblChallengeScale.Visible = false;
            lblChallengeScale2.Visible = false;
            lblChallengeScale3.Visible = false;
            lblChallengeScale4.Visible = false;
            lblChallengeScale5.Visible = false;
            lblChallengeScale6.Visible = false;
        }

        private void tm1939SaveFile(StreamWriter outputstream)
        {
            // A single writeline section to handle both save buttons.
            // Added Match to the end of each record
            outputstream.WriteLine(lblAutoTeamNo1.Text + x + lblAutoD1Cross.Text + x + lblAutoD1Reach.Text + x + lblAutoD2Cross.Text + x + lblAutoD2Reach.Text + x + lblAutoD3Cross.Text + x + lblAutoD3Reach.Text + x + lblAutoD4Cross.Text + x + lblAutoD4Reach.Text + x + lblAutoD5Cross.Text + x + lblAutoD5Reach.Text + x + lblAutoHighShotMade + x + lblAutoHighShotAtt + x + lblAutoLowShotMade + x + lblAutoLowShotAtt + x + lblAutoTotalPoints.Text + x + lblTeleOpD1Cross.Text + x + lblTeleOpD1Att.Text + x + lblTeleOpD2Cross.Text + x + lblTeleOpD2Att.Text + x + lblTeleOpD3Cross.Text + x + lblTeleOpD3Att.Text + x + lblTeleOpD4Cross.Text + x  + lblTeleOpD4Att.Text + x + lblTeleOpD5Cross.Text + x + lblTeleOpD5Att.Text + x + lblChallengeScale.Text + x + lblTeleOpHighShotMade + x + lblTeleOpHighShotAtt + x + lblTeleOpLowShotMade + x + lblTeleOpLowShotAtt + x + lblTeleOpTotalPoints.Text + x + lblTotalPoints.Text + x + lblDefense.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo2.Text + x + lblAutoD1Cross2.Text + x + lblAutoD1Reach2.Text + x + lblAutoD2Cross2.Text + x + lblAutoD2Reach2.Text + x + lblAutoD3Cross2.Text + x + lblAutoD3Reach2.Text + x + lblAutoD4Cross2.Text + x + lblAutoD4Reach2.Text + x + lblAutoD5Cross2.Text + x + lblAutoD5Reach2.Text + x + lblAutoHighShotMade2 + x + lblAutoHighShotAtt2 + x + lblAutoLowShotMade2 + x + lblAutoLowShotAtt2 + x + lblAutoTotalPoints2.Text + x + lblTeleOpD1Cross2.Text + x + lblTeleOpD1Att2.Text + x + lblTeleOpD2Cross2.Text + x + lblTeleOpD2Att2.Text + x + lblTeleOpD3Cross2.Text + x + lblTeleOpD3Att2.Text + x + lblTeleOpD4Cross2.Text + x + lblTeleOpD4Att2.Text + x + lblTeleOpD5Cross2.Text + x + lblTeleOpD5Att2.Text + x + lblChallengeScale2.Text + x + lblTeleOpHighShotMade2 + x + lblTeleOpHighShotAtt2 + x + lblTeleOpLowShotMade2 + x + lblTeleOpLowShotAtt2 + x + lblTeleOpTotalPoints2.Text + x + lblTotalPoints2.Text + x + lblDefense2.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo3.Text + x + lblAutoD1Cross3.Text + x + lblAutoD1Reach3.Text + x + lblAutoD2Cross3.Text + x + lblAutoD2Reach3.Text + x + lblAutoD3Cross3.Text + x + lblAutoD3Reach3.Text + x + lblAutoD4Cross3.Text + x + lblAutoD4Reach3.Text + x + lblAutoD5Cross3.Text + x + lblAutoD5Reach3.Text + x + lblAutoHighShotMade3 + x + lblAutoHighShotAtt3 + x + lblAutoLowShotMade3 + x + lblAutoLowShotAtt3 + x + lblAutoTotalPoints3.Text + x + lblTeleOpD1Cross3.Text + x + lblTeleOpD1Att3.Text + x + lblTeleOpD2Cross3.Text + x + lblTeleOpD2Att3.Text + x + lblTeleOpD3Cross3.Text + x + lblTeleOpD3Att3.Text + x + lblTeleOpD4Cross3.Text + x + lblTeleOpD4Att3.Text + x + lblTeleOpD5Cross3.Text + x + lblTeleOpD5Att3.Text + x + lblChallengeScale3.Text + x + lblTeleOpHighShotMade3 + x + lblTeleOpHighShotAtt3 + x + lblTeleOpLowShotMade3 + x + lblTeleOpLowShotAtt3 + x + lblTeleOpTotalPoints3.Text + x + lblTotalPoints3.Text + x + lblDefense3.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo4.Text + x + lblAutoD1Cross4.Text + x + lblAutoD1Reach4.Text + x + lblAutoD2Cross4.Text + x + lblAutoD2Reach4.Text + x + lblAutoD3Cross4.Text + x + lblAutoD3Reach4.Text + x + lblAutoD4Cross4.Text + x + lblAutoD4Reach4.Text + x + lblAutoD5Cross4.Text + x + lblAutoD5Reach4.Text + x + lblAutoHighShotMade4 + x + lblAutoHighShotAtt4 + x + lblAutoLowShotMade4 + x + lblAutoLowShotAtt4 + x + lblAutoTotalPoints4.Text + x + lblTeleOpD1Cross4.Text + x + lblTeleOpD1Att4.Text + x + lblTeleOpD2Cross4.Text + x + lblTeleOpD2Att4.Text + x + lblTeleOpD3Cross4.Text + x + lblTeleOpD3Att4.Text + x + lblTeleOpD4Cross4.Text + x + lblTeleOpD4Att4.Text + x + lblTeleOpD5Cross4.Text + x + lblTeleOpD5Att4.Text + x + lblChallengeScale4.Text + x + lblTeleOpHighShotMade4 + x + lblTeleOpHighShotAtt4 + x + lblTeleOpLowShotMade4 + x + lblTeleOpLowShotAtt4 + x + lblTeleOpTotalPoints4.Text + x + lblTotalPoints4.Text + x + lblDefense4.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo5.Text + x + lblAutoD1Cross5.Text + x + lblAutoD1Reach5.Text + x + lblAutoD2Cross5.Text + x + lblAutoD2Reach5.Text + x + lblAutoD3Cross5.Text + x + lblAutoD3Reach5.Text + x + lblAutoD4Cross5.Text + x + lblAutoD4Reach5.Text + x + lblAutoD5Cross5.Text + x + lblAutoD5Reach5.Text + x + lblAutoHighShotMade5 + x + lblAutoHighShotAtt5 + x + lblAutoLowShotMade5 + x + lblAutoLowShotAtt5 + x + lblAutoTotalPoints5.Text + x + lblTeleOpD1Cross5.Text + x + lblTeleOpD1Att5.Text + x + lblTeleOpD2Cross5.Text + x + lblTeleOpD2Att5.Text + x + lblTeleOpD3Cross5.Text + x + lblTeleOpD3Att5.Text + x + lblTeleOpD4Cross5.Text + x + lblTeleOpD4Att5.Text + x + lblTeleOpD5Cross5.Text + x + lblTeleOpD5Att5.Text + x + lblChallengeScale5.Text + x + lblTeleOpHighShotMade5 + x + lblTeleOpHighShotAtt5 + x + lblTeleOpLowShotMade5 + x + lblTeleOpLowShotAtt5 + x + lblTeleOpTotalPoints5.Text + x + lblTotalPoints5.Text + x + lblDefense5.Text + x + lblmatch.Text);
            outputstream.WriteLine(lblAutoTeamNo6.Text + x + lblAutoD1Cross6.Text + x + lblAutoD1Reach6.Text + x + lblAutoD2Cross6.Text + x + lblAutoD2Reach6.Text + x + lblAutoD3Cross6.Text + x + lblAutoD3Reach6.Text + x + lblAutoD4Cross6.Text + x + lblAutoD4Reach6.Text + x + lblAutoD5Cross6.Text + x + lblAutoD5Reach6.Text + x + lblAutoHighShotMade6 + x + lblAutoHighShotAtt6 + x + lblAutoLowShotMade6 + x + lblAutoLowShotAtt6 + x + lblAutoTotalPoints6.Text + x + lblTeleOpD1Cross6.Text + x + lblTeleOpD1Att6.Text + x + lblTeleOpD2Cross6.Text + x + lblTeleOpD2Att6.Text + x + lblTeleOpD3Cross6.Text + x + lblTeleOpD3Att6.Text + x + lblTeleOpD4Cross6.Text + x + lblTeleOpD4Att6.Text + x + lblTeleOpD5Cross6.Text + x + lblTeleOpD5Att6.Text + x + lblChallengeScale6.Text + x + lblTeleOpHighShotMade6 + x + lblTeleOpHighShotAtt6 + x + lblTeleOpLowShotMade6 + x + lblTeleOpLowShotAtt6 + x + lblTeleOpTotalPoints6.Text + x + lblTotalPoints6.Text + x + lblDefense6.Text + x + lblmatch.Text);



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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblTeleOpMidMade6_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }
    }
}