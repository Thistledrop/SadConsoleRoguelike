﻿using Roguelike.Entities;
using SadConsole;
using SadRogue.Primitives;
using System;

namespace Roguelike.Screens
{
    /// <summary>
    /// Container for all screen objects used by the roguelike game.
    /// </summary>
    internal class ScreenContainer : ScreenObject
    {
        //Singleton code
        private static ScreenContainer _instance;
        public static ScreenContainer Instance => _instance ?? throw new Exception("ScreenContainer is not yet initialized.");

        //Screen Sections
        private ScreenSurface Backdrop;
        public WorldScreen World { get; }
        public PlayerStatsScreen PlayerStats { get; }
        public MessagesScreen Messages { get; }

        public Random Random { get; }

        public ScreenContainer()
        {
            if (_instance != null)
                throw new Exception("Only one ScreenContainer instance can exist.");
            _instance = this;

            Random = new Random();
            Backdrop = new ScreenSurface(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY);
            Backdrop.Surface.Fill(background: MyColors.darkerGray);
            Children.Add(Backdrop);

            // World screen
            World = new WorldScreen(Game.Instance.ScreenCellsX.PercentageOf(70), Game.Instance.ScreenCellsY.PercentageOf(70), Constants.DungeonWidth, Constants.DungeonHeight);
            Children.Add(World);

            // Player stats screen
            PlayerStats = new PlayerStatsScreen(Game.Instance.ScreenCellsX.PercentageOf(30), Game.Instance.ScreenCellsY)
            {
                Position = new Point(World.Position.X + World.Width, World.Position.Y)
            };
            Children.Add(PlayerStats);

            // Messages screen
            Messages = new MessagesScreen(Game.Instance.ScreenCellsX.PercentageOf(70), Game.Instance.ScreenCellsY.PercentageOf(30))
            {
                Position = new Point(World.Position.X, World.Height)
            };
            Children.Add(Messages);
        }
    }
}
