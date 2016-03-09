using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleJoysticks
{
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
        public const int MidFrisbeesMadeMinus = 12;
        public const int MidFrisbeesMadePlus = 13;
        public const int MidFrisbeesAttMinus = 14;
        public const int MidFrisbeesAttPlus = 15;
        public const int LowFrisbeesMadeMinus = 16;
        public const int LowFrisbeesMadePlus = 17;
        public const int LowFrisbeesAttMinus = 18;
        public const int LowFrisbeesAttPlus = 19;
        public const int ChallengeScalePlus = 20;
        public const int FinishedScoring = 21;
    }
}
