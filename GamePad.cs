using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleJoysticks
{
    public class GamePad
    {
        public bool AutonomousMode = true;
        public bool TeleOp = false;
        public bool FinshedScoring = false;

        // Robot Climbing
        public int Climb = 0;
        public int ChallengeScale = 0;

        // Total Points
        public int TeleOpTotalPoints = 0;
        public int AutoTotalPoints = 0;

        // Defense Ratings
        public int DefenseRating = 0;
        public int DisplayDefenseRating = 0;
    }
}
