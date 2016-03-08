using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleJoysticks
{
    class GamePad
    {
        bool AutonomousMode = true;
        bool TeleOp = false;
        bool FinshedScoring = false;

        // Robot Climbing
        int climb = 0;
        int challengeScale = 0;

        // Total Points
        int teleOpTotalPoints = 0;
        int autoTotalPoints = 0;

        // Defense Ratings
        int defenseRating = 0;
        int displayDefenseRating = 0;
    }
}
