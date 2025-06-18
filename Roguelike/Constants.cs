using SadRogue.Primitives;

namespace Roguelike
{
    /// <summary>
    /// Easy access to all const game information
    /// </summary>
    internal static class Constants
    {
        public const string GameTitle = "Roguelike";
        public const string Font = "Fonts/Curses.font";
        public const string TileConfiguration = "World/Configuration/tiles.json";
        public const int PlayerFieldOfViewRadius = 6;
    }

    internal static class MyColors
    {
        public static readonly Color lightestBlue = new Color(133, 218, 235);
        public static readonly Color lighterBlue = new Color(95, 201, 231);
        public static readonly Color lightBlue = new Color(95, 161, 231);
        public static readonly Color darkBlue = new Color(95, 110, 231);
        public static readonly Color darkerBlue = new Color(76, 96, 170);
        public static readonly Color darkestBlue = new Color(68, 71, 116);

        public static readonly Color grayBlack = new Color(50, 49, 59);
        public static readonly Color darkerGray = new Color(25, 24, 29);

        public static readonly Color darkerPurple = new Color(70, 60, 94);
        public static readonly Color darkPurple = new Color(93, 71, 118);
        public static readonly Color medPurple = new Color(133, 83, 149);
        public static readonly Color lightPurple = new Color(171, 88, 168);
        public static readonly Color lighterPurple = new Color(202, 96, 174);

        public static readonly Color orange = new Color(243, 167, 135);
        public static readonly Color lightOrange = new Color(245, 218, 167);

        public static readonly Color lightGreen = new Color(141, 216, 148);
        public static readonly Color green = new Color(93, 193, 144);
        public static readonly Color cyan = new Color(74, 185, 163);
        public static readonly Color DarkCyan = new Color(69, 147, 165);

        public static readonly Color brightCyan = new Color(94, 253, 247);
        public static readonly Color brightMagenta = new Color(255, 93, 204);
        public static readonly Color brightYellow = new Color(253, 254, 137);
        public static readonly Color brightWhite = new Color(255, 255, 255);
    }
}
