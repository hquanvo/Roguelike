﻿using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.Core
{
    internal class Colors
    {
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Pallete.AlternateDarkest;
        public static RLColor FloorBackgroundFov = Pallete.DbDark;
        public static RLColor FloorFov = Pallete.Alternate;

        public static RLColor WallBackground = Pallete.SecondaryDarkest;
        public static RLColor Wall = Pallete.Secondary;
        public static RLColor WallBackgroundFov = Pallete.SecondaryDarker;
        public static RLColor WallFov = Pallete.SecondaryLighter;

        public static RLColor TextHeading = Pallete.DbLight;

        public static RLColor Player = Pallete.DbLight;
        public static RLColor Text = Pallete.DbLight;
        public static RLColor Gold = Pallete.DbSun;
        public static RLColor Exp = Pallete.DbSky;

        public static RLColor KoboldColor = Pallete.DbBlood;

        public static RLColor DoorBackground = Pallete.ComplimentDarkest;
        public static RLColor Door = Pallete.ComplimentLighter;
        public static RLColor DoorBackgroundFov = Pallete.ComplimentDarker;
        public static RLColor DoorFov = Pallete.ComplimentLightest;

    }
}
