using SadConsole.UI;
using SadConsole.UI.Themes;

namespace SadRogueExample.Themes;

/// <summary>
/// Colors/themes related to the Screens.Surfaces.StatusPanel.
/// </summary>
internal static class StatusPanel
{
    public static readonly Colors HPBarColors = GetHPBarColors();

    private static Colors GetHPBarColors()
    {
        var colors = Library.Default.Colors.Clone();
        colors.Appearance_ControlNormal.Foreground = MapObjects.Swatch.ForestDark;
        colors.Appearance_ControlNormal.Background = MapObjects.Swatch.ForestDarkest;

        return colors;
    }
}