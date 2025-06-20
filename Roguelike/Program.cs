using Roguelike.Screens;
using SadConsole;
using SadConsole.Configuration;

namespace Roguelike
{
    /// <summary>
    /// Process startup
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Settings.WindowTitle = Constants.GameTitle;
            Settings.ResizeMode = Settings.WindowResizeOptions.Stretch;

            Builder gameStartup = new Builder()
                .SetScreenSize(80, 50)
                .SetStartingScreen<ScreenContainer>() //ScreenContainer is a custom Screen
                .OnStart(GameStart)
                .IsStartingScreenFocused(true)
                .ConfigureFonts((fontConfig, game) =>
                {
                    fontConfig.UseCustomFont(Constants.Font);
                });

            Game.Create(gameStartup);
            Game.Instance.Run();
            Game.Instance.Dispose();
        }

        private static void GameStart(object sender, GameHost e)
        {
            var world = ScreenContainer.Instance.World;
            world.Generate();
        }
    }
}
