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
        public String[] ControllerCommands = new String[22];
        //public GamePad GamePad = new GamePad();
        private string LastButtonPattern;
        private Label displayButtons;
        private bool AutonomousMode = true;
        private bool TeleOp = false;
        public bool FinshedScoring = false;

        public GamePadControl()
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

        private void tm1939ProcessButton(string strButtonMap)
        {
            //TODO
            //throw new NotImplementedException();
        }

        void UpdateScores()
        {
            //TODO
            //autoTotalPoints = (autoDefense2Cross * 6) +
            //        (autoMidFrisbeesMade * 4) +
            //        (autoLowFrisbeesMade * 2);
            //teleOpTotalPoints = (defense1Cross * 5) +
            //        (defense2Cross * 3) +
            //        (midFrisbeesMade * 2) +
            //        lowFrisbeesMade;
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
                lblAutoMidAtt.Visible = false;
                lblTeleOpMidAtt.Visible = true;
                lblAutoMidMade.Visible = false;
                lblTeleOpMidMade.Visible = true;
                lblAutoLowAtt.Visible = false;
                lblTeleOpLowAtt.Visible = true;
                lblAutoLowMade.Visible = false;
                lblTeleOpLowMade.Visible = true;
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
                lblAutoMidAtt.Visible = true;
                lblTeleOpMidAtt.Visible = false;
                lblAutoMidMade.Visible = true;
                lblTeleOpMidMade.Visible = false;
                lblAutoLowAtt.Visible = true;
                lblTeleOpLowAtt.Visible = false;
                lblAutoLowMade.Visible = true;
                lblTeleOpLowMade.Visible = false;
                lblChallengeScale.Visible = false;
            }
            //TODO
            //Defense Rating
            //lblDefense.Text = displayDefenseRating.ToString();

            //// Pyramid Goals
            //lblTeleOpD1Cross.Text = displayDefense1Cross.ToString();
            //lblTeleOpD1Att.Text = displayDefense1Att.ToString();
            //lblAutoD1Cross.Text = autoDisplayDefense1Cross.ToString();
            //lblAutoD1Reach.Text = autoDisplayDefense1Reach.ToString();

            //// High Goals
            //lblTeleOpD2Cross.Text = displayDefense2Cross.ToString();
            //lblTeleOpD2Att.Text = displayDefense2Att.ToString();
            //lblAutoD2Cross.Text = autoDisplayDefense2Cross.ToString();
            //lblAutoD2Reach.Text = autoDisplayDefense2Reach.ToString();

            //// Mid Goals
            //lblTeleOpMidMade.Text = displayMidFrisbeesMade.ToString();
            //lblTeleOpMidAtt.Text = displayMidFrisbeesAtt.ToString();
            //lblAutoMidMade.Text = autoDisplayMidFrisbeesMade.ToString();
            //lblAutoMidAtt.Text = autoDisplayMidFrisbeesAtt.ToString();

            //// Low Goals
            //lblTeleOpLowMade.Text = displayLowFrisbeesMade.ToString();
            //lblTeleOpLowAtt.Text = displayLowFrisbeesAtt.ToString();
            //lblAutoLowMade.Text = autoDisplayLowFrisbeesMade.ToString();
            //lblAutoLowAtt.Text = autoDisplayLowFrisbeesAtt.ToString();

            //// Robot Climb
            //lblChallengeScale.Text = challengeScale.ToString();

            //lblTeleOpTotalPoints.Text = teleOpTotalPoints.ToString();
            //lblAutoTotalPoints.Text = autoTotalPoints.ToString();
            //lblTotalPoints.Text = (autoTotalPoints + teleOpTotalPoints + challengeScale).ToString();
            if (FinshedScoring)
                lblTeleOp.ForeColor = Color.DarkGreen;
            else
                lblTeleOp.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
        }

        private void btnScouter1_Click(object sender, EventArgs e)
        {
            lblScouter1.Text = textBoxScout1.Text;
            textBoxScout1.Visible = false;
            btnScouter1.Visible = false;
            lblScouter1.Visible = true;
        }
    }
}
