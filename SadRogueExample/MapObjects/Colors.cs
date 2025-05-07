using SadRogue.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadRogueExample.MapObjects
{
    public static class Colors
    {
        public static Color DoorBackground = Color.Black;
        public static Color Door = Swatch.RockDarkest;
        public static Color DoorBackgroundFov = Color.Black;
        public static Color DoorFov = Swatch.SandDarkest;

        public static Color FloorBackground = Color.Black;
        public static Color Floor = Swatch.RockDarkest;
        public static Color FloorBackgroundFov = Color.Black;
        public static Color FloorFov = Swatch.RockMid;

        public static Color WallBackground = Color.Black;
        public static Color Wall = Swatch.RockDark;
        public static Color WallBackgroundFov = Color.Black;
        public static Color WallFov = Swatch.RockMid;

        public static Color PlayerColor = Swatch.IceLightest;

        public static Color SkeletonColor = Swatch.IceLight;
        public static Color GoblinColor = Swatch.MossLight;
        public static Color OozeColor = Swatch.ForestLight;
        public static Color MimicColor = Swatch.SandDark;
        public static Color SpiderColor = Swatch.RockDark;
        public static Color RatsColor = Swatch.SandMid;
        public static Color HellhoundColor = Swatch.FlameDark;
        public static Color ConstructColor = Swatch.ObsidianMid;
    }

    public static class Swatch
    {
        public static Color RockDarkest = new Color(46, 34, 47);
        public static Color RockDark = new Color(62, 53, 70);
        public static Color RockMid = new Color(98, 85, 101);
        public static Color RockLight = new Color(150, 108, 108);
        public static Color RockLightest = new Color(171, 148, 122);

        public static Color IceDarkest = new Color(105, 79, 98);
        public static Color IceDark = new Color(127, 112, 138);
        public static Color IceMid = new Color(155, 171, 178);
        public static Color IceLight = new Color(199, 220, 208);
        public static Color IceLightest = new Color(255, 255, 255);

        public static Color CopperDarkest = new Color(110, 39, 39);
        public static Color CopperDark = new Color(179, 56, 49);
        public static Color CopperLight = new Color(234, 79, 54);
        public static Color CopperLightest = new Color(245, 125, 74);

        public static Color FlameDarkest = new Color(174, 35, 52);
        public static Color FlameDark = new Color(232, 59, 59);
        public static Color FlameMid = new Color(251, 107, 29);
        public static Color FlameLight = new Color(247, 150, 23);
        public static Color FlameLightest = new Color(249, 194, 43);

        public static Color SandDarkest = new Color(122, 48, 69);
        public static Color SandDark = new Color(158, 69, 57);
        public static Color SandMid = new Color(205, 104, 61);
        public static Color SandLight = new Color(230, 144, 78);
        public static Color SandLightest = new Color(251, 185, 84);

        public static Color ForestDarkest = new Color(76, 62, 36);
        public static Color ForestDark = new Color(103, 102, 51);
        public static Color ForestMid = new Color(162, 169, 71);
        public static Color ForestLight = new Color(213, 224, 75);
        public static Color ForestLightest = new Color(251, 255, 134);

        public static Color LagoonDarkest = new Color(22, 90, 76);
        public static Color LagoonDark = new Color(35, 144, 99);
        public static Color LagoonMid = new Color(30, 188, 115);
        public static Color LagoonLight = new Color(145, 219, 105);
        public static Color LagoonLightest = new Color(205, 223, 108);

        public static Color MossDarkest = new Color(49, 54, 56);
        public static Color MossDark = new Color(55, 78, 74);
        public static Color MossMid = new Color(84, 126, 100);
        public static Color MossLight = new Color(146, 169, 132);
        public static Color MossLightest = new Color(178, 186, 144);

        public static Color RiverDarkest = new Color(11, 94, 101);
        public static Color RiverDark = new Color(11, 138, 143);
        public static Color RiverMid = new Color(14, 175, 155);
        public static Color RiverLight = new Color(48, 225, 185);
        public static Color RiverLightest = new Color(143, 248, 226);

        public static Color MountainDarkest = new Color(50, 51, 83);
        public static Color MountainDark = new Color(72, 74, 119);
        public static Color MountainMid = new Color(77, 101, 180);
        public static Color MountainLight = new Color(77, 155, 230);
        public static Color MountainLightest = new Color(143, 211, 255);

        public static Color ObsidianDarkest = new Color(69, 41, 63);
        public static Color ObsidianDark = new Color(107, 62, 117);
        public static Color ObsidianMid = new Color(144, 94, 169);
        public static Color ObsidianLight = new Color(168, 132, 243);
        public static Color ObsidianLightest = new Color(234, 173, 237);

        public static Color DustDarkest = new Color(117, 60, 84);
        public static Color DustDark = new Color(162, 75, 111);
        public static Color DustLight = new Color(207, 101, 127);
        public static Color DustLightest = new Color(237, 128, 153);

        public static Color BubblegumDarkest = new Color(131, 28, 93);
        public static Color BubblegumDarker = new Color(195, 36, 84);
        public static Color BubblegumDark = new Color(240, 79, 120);
        public static Color BubblegumLight = new Color(246, 129, 129);
        public static Color BubblegumLighter = new Color(252, 167, 144);
        public static Color BubblegumLightest = new Color(253, 203, 176);
    }
}
