using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleJoysticks
{
    public partial class GamePad : UserControl
    {
        // Reduced from Arrays 
        private bool AutonomousMode = true;
        private bool TeleOp = false;
        public bool FinshedScoring = false;

        //Arrays that hold the values for the made and attempt numbers of the frisbee scoring
        // Defense 5 
        int displayDefense5Cross = 0;
        int defense5Cross = 0;
        int displayDefense5Att = 0;
        int defense5Att = 0;
        int autoDisplayDefense5Cross = 0;
        int autoDefense5Cross = 0;
        int autoDisplayDefense5Reach = 0;
        int autoDefense5Reach = 0;

        // 1 point frisbees
        int displayDefense4Cross = 0;
        int defense4Cross = 0;
        int displayDefense4Att = 0;
        int defense4Att = 0;
        int autoDisplayDefense4Cross = 0;
        int autoDefense4Cross = 0;
        int autoDisplayDefense4Reach = 0;
        int autoDefense4Reach = 0;

        // 2 point frisbees
        int displayDefense3Cross = 0;
        int defense3Cross = 0;
        int displayDefense3Att = 0;
        int defense3Att = 0;
        int autoDisplayDefense3Cross = 0;
        int autoDefense3Cross = 0;
        int autoDisplayDefense3Reach = 0;
        int autoDefense3Reach = 0;

        // 3 point frisbees
        int displayDefense2Cross = 0;
        int defense2Cross = 0;
        int displayDefense2Att = 0;
        int defense2Att = 0;
        int autoDisplayDefense2Cross = 0;
        int autoDefense2Cross = 0;
        int autoDisplayDefense2Reach = 0;
        int autoDefense2Reach = 0;

        // Pyramid Frisbees
        int displayDefense1Cross = 0;
        int defense1Cross = 0;
        int displayDefense1Att = 0;
        int defense1Att = 0;
        int autoDisplayDefense1Cross = 0;
        int autoDefense1Cross = 0;
        int autoDisplayDefense1Reach = 0;
        int autoDefense1Reach = 0;

        // High Boulder Shot
        int displayHighShotMade = 0;
        int highShotMade = 0;
        int displayHighShotAtt = 0;
        int highShotAtt = 0;
        int autoDisplayHighShotMade = 0;
        int autoHighShotMade = 0;
        int autoDisplayHighShotAtt = 0;
        int autoHighShotAtt = 0;

        // Low Boulder Shot
        int displayLowShotMade = 0;
        int lowShotMade = 0;
        int displayLowShotAtt = 0;
        int lowShotAtt = 0;
        int autoDisplayLowShotMade = 0;
        int autoLowShotMade = 0;
        int autoDisplayLowShotAtt = 0;
        int autoLowShotAtt = 0;

        // Robot Climbing
        int climb = 0;
        int challengeScale = 0;

        // Total Points
        int teleOpTotalPoints = 0;
        int autoTotalPoints = 0;

        // Defense Ratings
        int defenseRating = 0;
        int displayDefenseRating = 0;

        //----

        public String[] ControllerCommands = new String[34];
        private string LastButtonPattern;

        public GamePad()
        {
            InitializeComponent();
        }

        public bool UseButtonMap(string strButtonMap)
        {
            if (strButtonMap.Equals(LastButtonPattern))
                return false;
            tm1939ProcessButton(strButtonMap);
            LastButtonPattern = strButtonMap;
            UpdateScores();
            tm1939UpdateController(); // tm1939RefreshScreen();
            return true;
        }

        void UpdateScores()   //COOK George, this one is yours to fix.
        {
            autoTotalPoints = (autoDefense2Cross * 6) +
                    (autoDefense3Cross * 4) +
                    (autoDefense4Cross * 2);
            teleOpTotalPoints = (defense1Cross * 5) +
                    (defense2Cross * 3) +
                    (defense3Cross * 2) +
                    defense4Cross;
        }

        private void tm1939ProcessButton(string strButtonMap)
        {
            int FoundAt;

            // Find where the button maps are equal to get the command
            for (FoundAt = 0; FoundAt < 34 && !strButtonMap.Equals(ControllerCommands[FoundAt]); FoundAt++)
            {
            }

            // Perform the appropriate function

            switch (FoundAt)
            {
                case (GameCommands.TeleOp):
                    AutonomousMode = false;
                    TeleOp = true;

                    break;

                case (GameCommands.Autonomous):
                    AutonomousMode = true;
                    TeleOp = false;
                    FinshedScoring = false;
                    break;

                case (GameCommands.scoreHigh):
                    if (TeleOp && defenseRating > 0)
                    {
                        defenseRating--;
                        displayDefenseRating = defenseRating;
                    }
                    break;

                case (GameCommands.scoreLow):
                    if (TeleOp)
                    {
                        defenseRating++;
                        displayDefenseRating = defenseRating;
                        if (displayDefenseRating > 10)
                        {
                            defenseRating = 0;
                            displayDefenseRating = 0;
                        }
                    }

                    break;

                case (GameCommands.Defense2AttMinus):
                    if (TeleOp)
                    {
                        if (defense2Att > 0 && defense2Cross < defense2Att)
                        {
                            defense2Att--;
                            displayDefense2Att = defense2Att;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense2Reach > 0 && autoDefense2Cross < autoDefense2Reach)
                        {
                            autoDefense2Reach--;
                            autoDisplayDefense2Reach = autoDefense2Reach;
                        }
                    }

                    break;

                case (GameCommands.Defense2AttPlus):
                    if (TeleOp)
                    {
                        defense2Att++;
                        displayDefense2Att = defense2Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense2Reach++;
                        autoDisplayDefense2Reach = autoDefense2Reach;
                    }

                    break;

                case (GameCommands.Defense2CrossMinus):
                    if (TeleOp)
                    {
                        if (defense2Cross > 0)
                        {
                            defense2Cross--;
                            displayDefense2Cross = defense2Cross;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense2Cross > 0)
                        {
                            autoDefense2Cross--;
                            autoDisplayDefense2Cross = autoDefense2Cross;
                        }
                    }
                    break;

                case (GameCommands.Defense2CrossPlus):
                    if (TeleOp)
                    {
                        defense2Cross++;
                        displayDefense2Cross = defense2Cross;
                        defense2Att++;
                        displayDefense2Att = defense2Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense2Cross++;
                        autoDisplayDefense2Cross = autoDefense2Cross;
                        autoDefense2Reach++;
                        autoDisplayDefense2Reach = autoDefense2Reach;
                    }
                    break;

                case (GameCommands.Defense4AttMinus):
                    if (TeleOp)
                    {
                        if (defense4Att > 0 && defense4Cross < defense4Att)
                        {
                            defense4Att--;
                            displayDefense4Att = defense4Att;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense4Reach > 0 && autoDefense4Cross < autoDefense4Reach)
                        {
                            autoDefense4Reach--;
                            autoDisplayDefense4Reach = autoDefense4Reach;
                        }
                    }

                    break;

                case (GameCommands.Defense4AttPlus):
                    if (TeleOp)
                    {
                        defense4Att++;
                        displayDefense4Att = defense4Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense4Reach++;
                        autoDisplayDefense4Reach = autoDefense4Reach;
                    }


                    break;

                case (GameCommands.Defense4CrossMinus):
                    if (TeleOp)
                    {
                        if (defense4Cross > 0)
                        {
                            defense4Cross--;
                            displayDefense4Cross = defense4Cross;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense4Cross > 0)
                        {
                            autoDefense4Cross--;
                            autoDisplayDefense4Cross = autoDefense4Cross;
                        }
                    }

                    break;

                case (GameCommands.Defense4CrossPlus):
                    if (TeleOp)
                    {
                        defense4Cross++;
                        displayDefense4Cross = defense4Cross;
                        defense4Att++;
                        displayDefense4Att = defense4Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense4Cross++;
                        autoDisplayDefense4Cross = autoDefense4Cross;
                        autoDefense4Reach++;
                        autoDisplayDefense4Reach = autoDefense4Reach;
                    }

                    break;

                case (GameCommands.Defense5AttPlus):
                    if (TeleOp)
                    {
                        defense5Att++;
                        displayDefense5Att = defense5Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense5Reach++;
                        autoDisplayDefense5Reach = autoDefense5Reach;
                    }


                    break;

                case (GameCommands.Defense5CrossMinus):
                    if (TeleOp)
                    {
                        if (defense5Cross > 0)
                        {
                            defense5Cross--;
                            displayDefense5Cross = defense5Cross;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense5Cross > 0)
                        {
                            autoDefense5Cross--;
                            autoDisplayDefense5Cross = autoDefense5Cross;
                        }
                    }

                    break;

                case (GameCommands.Defense5CrossPlus):
                    if (TeleOp)
                    {
                        defense5Cross++;
                        displayDefense5Cross = defense5Cross;
                        defense5Att++;
                        displayDefense5Att = defense5Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense5Cross++;
                        autoDisplayDefense5Cross = autoDefense5Cross;
                        autoDefense5Reach++;
                        autoDisplayDefense5Reach = autoDefense5Reach;
                    }

                    break;

                case (GameCommands.Defense3AttMinus):
                    if (TeleOp)
                    {
                        if (defense3Att > 0 && defense3Cross < defense3Att)
                        {
                            defense3Att--;
                            displayDefense3Att = defense3Att;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense3Reach > 0 && autoDefense3Cross < autoDefense3Reach)
                        {
                            autoDefense3Reach--;
                            autoDisplayDefense3Reach = autoDefense3Reach;
                        }
                    }
                    break;

                case (GameCommands.Defense3AttPlus):
                    if (TeleOp)
                    {
                        defense3Att++;
                        displayDefense3Att = defense3Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense3Reach++;
                        autoDisplayDefense3Reach = autoDefense3Reach;
                    }


                    break;

                case (GameCommands.Defense3CrossMinus):
                    if (TeleOp)
                    {
                        if (defense3Cross > 0)
                        {
                            defense3Cross--;
                            displayDefense3Cross = defense3Cross;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense3Cross > 0)
                        {
                            autoDefense3Cross--;
                            autoDisplayDefense3Cross = autoDefense3Cross;
                        }
                    }

                    break;

                case (GameCommands.Defense3CrossPlus):
                    if (TeleOp)
                    {
                        defense3Cross++;
                        displayDefense3Cross = defense3Cross;
                        defense3Att++;
                        displayDefense3Att = defense3Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense3Cross++;
                        autoDisplayDefense3Cross = autoDefense3Cross;
                        autoDefense3Reach++;
                        autoDisplayDefense3Reach = autoDefense3Reach;
                    }

                    break;

                case (GameCommands.Defense1AttMinus):
                    if (TeleOp)
                    {
                        if (defense1Att > 0 && defense1Cross < defense1Att)
                        {
                            defense1Att--;
                            displayDefense1Att = defense1Att;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense1Reach > 0 && autoDefense1Cross < autoDefense1Reach)
                        {
                            autoDefense1Reach--;
                            autoDisplayDefense1Reach = autoDefense1Reach;
                        }
                    }

                    break;

                case (GameCommands.Defense1AttPlus):
                    if (TeleOp)
                    {
                        defense1Att++;
                        displayDefense1Att = defense1Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense1Reach++;
                        autoDisplayDefense1Reach = autoDefense1Reach;
                    }
                    break;

                case (GameCommands.Defense1CrossMinus):
                    if (TeleOp)
                    {
                        if (defense1Cross > 0)
                        {
                            defense1Cross--;
                            displayDefense1Cross = defense1Cross;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoDefense1Cross > 0)
                        {
                            autoDefense1Cross--;
                            autoDisplayDefense1Cross = autoDefense1Cross;
                        }
                    }
                    break;

                case (GameCommands.Defense1CrossPlus):
                    if (TeleOp)
                    {
                        defense1Cross++;
                        displayDefense1Cross = defense1Cross;
                        defense1Att++;
                        displayDefense1Att = defense1Att;
                    }
                    if (AutonomousMode)
                    {
                        autoDefense1Cross++;
                        autoDisplayDefense1Cross = autoDefense1Cross;
                        autoDefense1Reach++;
                        autoDisplayDefense1Reach = autoDefense1Reach;
                    }

                    break;

                case (GameCommands.HighShotAttMinus):
                    if (TeleOp)
                    {
                        if (highShotAtt > 0 && highShotMade < highShotAtt)
                        {
                            highShotAtt--;
                            displayHighShotAtt = highShotAtt;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoHighShotAtt > 0 && autoHighShotMade < autoHighShotAtt)
                        {
                            autoHighShotAtt--;
                            autoDisplayHighShotAtt = autoHighShotAtt;
                        }
                    }

                    break;

                case (GameCommands.HighShotAttPlus):
                    if (TeleOp)
                    {
                        highShotAtt++;
                        displayHighShotAtt = highShotAtt;
                    }
                    if (AutonomousMode)
                    {
                        autoHighShotAtt++;
                        autoDisplayHighShotAtt = autoHighShotAtt;
                    }
                    break;

                case (GameCommands.HighShotMadeMinus):
                    if (TeleOp)
                    {
                        if (highShotMade > 0)
                        {
                            highShotMade--;
                            displayHighShotMade = highShotMade;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoHighShotMade > 0)
                        {
                            autoHighShotMade--;
                            autoDisplayHighShotMade = autoHighShotMade;
                        }
                    }
                    break;

                case (GameCommands.HighShotMadePlus):
                    if (TeleOp)
                    {
                        highShotMade++;
                        displayHighShotMade = highShotMade;
                        highShotAtt++;
                        displayHighShotAtt = highShotAtt;
                    }
                    if (AutonomousMode)
                    {
                        autoHighShotMade++;
                        autoDisplayHighShotMade = autoHighShotMade;
                        autoHighShotAtt++;
                        autoDisplayHighShotAtt = autoHighShotAtt;
                    }

                    break;

                case (GameCommands.LowShotAttMinus):
                    if (TeleOp)
                    {
                        if (lowShotAtt > 0 && lowShotMade < lowShotAtt)
                        {
                            lowShotAtt--;
                            displayLowShotAtt = lowShotAtt;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoLowShotAtt > 0 && autoLowShotMade < autoLowShotAtt)
                        {
                            autoLowShotAtt--;
                            autoDisplayLowShotAtt = autoLowShotAtt;
                        }
                    }

                    break;

                case (GameCommands.LowShotAttPlus):
                    if (TeleOp)
                    {
                        lowShotAtt++;
                        displayLowShotAtt = lowShotAtt;
                    }
                    if (AutonomousMode)
                    {
                        autoLowShotAtt++;
                        autoDisplayLowShotAtt = autoLowShotAtt;
                    }
                    break;

                case (GameCommands.LowShotMadeMinus):
                    if (TeleOp)
                    {
                        if (lowShotMade > 0)
                        {
                            lowShotMade--;
                            displayLowShotMade = lowShotMade;
                        }
                    }
                    if (AutonomousMode)
                    {
                        if (autoLowShotMade > 0)
                        {
                            autoLowShotMade--;
                            autoDisplayLowShotMade = autoLowShotMade;
                        }
                    }
                    break;

                case (GameCommands.LowShotMadePlus):
                    if (TeleOp)
                    {
                        lowShotMade++;
                        displayLowShotMade = lowShotMade;
                        lowShotAtt++;
                        displayLowShotAtt = lowShotAtt;
                    }
                    if (AutonomousMode)
                    {
                        autoLowShotMade++;
                        autoDisplayLowShotMade = autoLowShotMade;
                        autoLowShotAtt++;
                        autoDisplayLowShotAtt = autoLowShotAtt;
                    }

                    break;

                case (GameCommands.ChallengeScalePlus):
                    if (TeleOp)
                    {
                        climb++;
                        challengeScale = climb;

                        if (challengeScale > 2) // 0 = not done, 1 = challenge, 2 = scale
                        {
                            challengeScale = 0;
                            climb = 0;
                        }

                        //This line multiplied by 10 for points, and is not relevant
                        //robotClimb = robotClimb * 10;
                    }
                    break;
                case (GameCommands.FinishedScoring):
                    FinshedScoring = !FinshedScoring;

                    break;

                default:

                    break;
                case (GameCommands.ControllerSwitch1):
                    

                    break;

                default:

                    break;
                case (GameCommands.ControllerSwitch2):


                    break;

                default:

                    break;
            }
        }

            lbldisplayButtons1.Text = GetButtonDisplay(strButtonMap);
        }

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


        void tm1939UpdateController()
        {
            if (TeleOp)
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
            if (AutonomousMode)
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
            lblDefense.Text = displayDefenseRating.ToString();

            // Pyramid Goals
            lblTeleOpD1Cross.Text = displayDefense1Cross.ToString();
            lblTeleOpD1Att.Text = displayDefense1Att.ToString();
            lblAutoD1Cross.Text = autoDisplayDefense1Cross.ToString();
            lblAutoD1Reach.Text = autoDisplayDefense1Reach.ToString();

            // High Goals
            lblTeleOpD2Cross.Text = displayDefense2Cross.ToString();
            lblTeleOpD2Att.Text = displayDefense2Att.ToString();
            lblAutoD2Cross.Text = autoDisplayDefense2Cross.ToString();
            lblAutoD2Reach.Text = autoDisplayDefense2Reach.ToString();

            // Mid Goals
            lblTeleOpD3Cross.Text = displayDefense3Cross.ToString();
            lblTeleOpD3Att.Text = displayDefense3Att.ToString();
            lblAutoD3Cross.Text = autoDisplayDefense3Cross.ToString();
            lblAutoD3Reach.Text = autoDisplayDefense3Reach.ToString();

            // Low Goals
            lblTeleOpD4Cross.Text = displayDefense4Cross.ToString();
            lblTeleOpD4Att.Text = displayDefense4Att.ToString();
            lblAutoD4Cross.Text = autoDisplayDefense4Cross.ToString();
            lblAutoD4Reach.Text = autoDisplayDefense4Reach.ToString();

            // Defense 5
            lblTeleOpD5Cross.Text = displayDefense5Cross.ToString();
            lblTeleOpD5Att.Text = displayDefense5Att.ToString();
            lblAutoD5Cross.Text = autoDisplayDefense5Cross.ToString();
            lblAutoD5Reach.Text = autoDisplayDefense5Reach.ToString();

            // High Boulder Shot 
            lblTeleOpHighShotMade.Text = displayHighShotMade.ToString();
            lblTeleOpHighShotAtt.Text = displayHighShotAtt.ToString();
            lblAutoHighShotMade.Text = autoDisplayHighShotMade.ToString();
            lblAutoHighShotAtt.Text = autoDisplayHighShotAtt.ToString();

            // Low Boulder Shot
            lblTeleOpLowShotMade.Text = displayLowShotMade.ToString();
            lblTeleOpLowShotAtt.Text = displayLowShotAtt.ToString();
            lblAutoLowShotMade.Text = autoDisplayLowShotMade.ToString();
            lblAutoLowShotAtt.Text = autoDisplayLowShotAtt.ToString();

            // Robot Climb
            lblChallengeScale.Text = challengeScale.ToString();

            lblTeleOpTotalPoints.Text = teleOpTotalPoints.ToString();
            lblAutoTotalPoints.Text = autoTotalPoints.ToString();
            lblTotalPoints.Text = (autoTotalPoints + teleOpTotalPoints + challengeScale).ToString();
            if (FinshedScoring)
                lblTeleOp.ForeColor = Color.DarkGreen;
            else
                lblTeleOp.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));

        }

        // -------------BUTTONS

        private void btnScouter1_Click(object sender, EventArgs e)
        {
            lblScouter1.Text = textBoxScout1.Text;
            textBoxScout1.Visible = false;
            btnScouter1.Visible = false;
            lblScouter1.Visible = true;
        }

        public void Clear()
        {
            displayDefense5Cross = 0;
            displayDefense5Att = 0;
            defense5Cross = 0;
            defense5Att = 0;
            autoDisplayDefense5Cross = 0;
            autoDefense5Cross = 0;
            autoDisplayDefense5Reach = 0;
            autoDefense5Reach = 0;
            displayDefense4Cross = 0;
            displayDefense4Att = 0;
            defense4Cross = 0;
            defense4Att = 0;
            autoDisplayDefense4Cross = 0;
            autoDefense4Cross = 0;
            autoDisplayDefense4Reach = 0;
            autoDefense4Reach = 0;
            displayDefense3Cross = 0;
            defense3Cross = 0;
            displayDefense3Att = 0;
            defense3Att = 0;
            autoDisplayDefense3Cross = 0;
            autoDefense3Cross = 0;
            autoDisplayDefense3Reach = 0;
            autoDefense3Reach = 0;
            displayDefense2Cross = 0;
            defense2Cross = 0;
            displayDefense2Att = 0;
            defense2Att = 0;
            autoDisplayDefense2Cross = 0;
            autoDefense2Cross = 0;
            autoDisplayDefense2Reach = 0;
            autoDefense2Reach = 0;
            autoDisplayDefense1Cross = 0;
            autoDefense1Cross = 0;
            autoDisplayDefense1Reach = 0;
            autoDefense1Reach = 0;
            displayDefense1Cross = 0;
            defense1Cross = 0;
            displayDefense1Att = 0;
            defense1Att = 0;
            autoDisplayHighShotMade = 0;
            autoHighShotMade = 0;
            autoDisplayHighShotAtt = 0;
            autoHighShotAtt = 0;
            displayHighShotMade = 0;
            highShotMade = 0;
            displayHighShotAtt = 0;
            highShotAtt = 0;
            autoDisplayLowShotMade = 0;
            autoLowShotMade = 0;
            autoDisplayLowShotAtt = 0;
            autoLowShotAtt = 0;
            displayLowShotMade = 0;
            lowShotMade = 0;
            displayLowShotAtt = 0;
            lowShotAtt = 0;
            climb = 0;
            challengeScale = 0;
            teleOpTotalPoints = 0;
            autoTotalPoints = 0;
            defenseRating = 0;
            displayDefenseRating = 0;
            lblAuto.Visible = true;
            lblTeleOp.Visible = false;
            lblChallengeScale.Visible = false;
            FinshedScoring = false;
            tm1939UpdateController(); // tm1939RefreshScreen(f);
        }

        public string GetResults(string match)
        {
            var x = ',';
            return lblAutoTeamNo.Text + x + lblAutoD1Cross.Text + x + lblAutoD1Reach.Text + x + lblAutoD2Cross.Text + x + lblAutoD2Reach.Text + x + lblAutoD3Cross.Text + x + lblAutoD3Reach.Text + x + lblAutoD4Cross.Text + x + lblAutoD4Reach.Text + x + lblAutoD5Cross.Text + x + lblAutoD5Reach.Text + x + lblAutoHighShotMade + x + lblAutoHighShotAtt + x + lblAutoLowShotMade + x + lblAutoLowShotAtt + x + lblAutoTotalPoints.Text + x + lblTeleOpD1Cross.Text + x + lblTeleOpD1Att.Text + x + lblTeleOpD2Cross.Text + x + lblTeleOpD2Att.Text + x + lblTeleOpD3Cross.Text + x + lblTeleOpD3Att.Text + x + lblTeleOpD4Cross.Text + x + lblTeleOpD4Att.Text + x + lblTeleOpD5Cross.Text + x + lblTeleOpD5Att.Text + x + lblChallengeScale.Text + x + lblTeleOpHighShotMade + x + lblTeleOpHighShotAtt + x + lblTeleOpLowShotMade + x + lblTeleOpLowShotAtt + x + lblTeleOpTotalPoints.Text + x + lblTotalPoints.Text + x + lblDefense.Text + x + match;
        }
    }
}
