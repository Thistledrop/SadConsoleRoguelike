using SadConsole;

namespace SadRogueExample.Themes;

/// <summary>
/// Static class which defines <see cref="ColoredString.ColoredGlyphEffect"/> instances which define the colors used for
/// different types of messages.
/// </summary>
internal static class MessageColors
{
    /// <summary>
    /// Initial welcome text printed on dungeon entrance.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect WelcomeTextAppearance = new()
    {
        Foreground = MapObjects.Swatch.LagoonLightest
    };

    /// <summary>
    /// Text indicating the player attacked something.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect PlayerAtkAppearance = new()
    {
        Foreground = MapObjects.Swatch.MossMid
    };

    /// <summary>
    /// Text indicating an enemy attacked the player.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect EnemyAtkAppearance = new()
    {
        Foreground = MapObjects.Swatch.FlameDarkest
    };

    /// <summary>
    /// Text indicating the player died.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect PlayerDiedAppearance = new()
    {
        Foreground = MapObjects.Swatch.FlameDarkest
    };

    /// <summary>
    /// Text indicating an enemy died.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect EnemyDiedAppearance = new()
    {
        Foreground = MapObjects.Swatch.MossMid
    };

    /// <summary>
    /// Text indicating the player tried to take an action which is not possible (ie. moving into a wall).
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect ImpossibleActionAppearance = new()
    {
        Foreground = MapObjects.Swatch.RockLightest
    };

    /// <summary>
    /// Text indicating the player picked up an item.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect ItemPickedUpAppearance = new()
    {
        Foreground = MapObjects.Swatch.IceMid
    };

    /// <summary>
    /// Text indicating the player dropped an item.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect ItemDroppedAppearance = new()
    {
        Foreground = MapObjects.Swatch.IceMid
    };

    /// <summary>
    /// Text indicating the player recovered health.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect HealthRecoveredAppearance = new()
    {
        Foreground = MapObjects.Swatch.MossMid
    };

    /// <summary>
    /// Text indicating that a used item needs a target.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect NeedsTargetAppearance = new()
    {
        Foreground = MapObjects.Swatch.ObsidianMid
    };

    /// <summary>
    /// Text indicating that a status effect was applied.
    /// </summary>
    public static readonly ColoredString.ColoredGlyphEffect StatusEffectAppliedAppearance = new()
    {
        Foreground = MapObjects.Swatch.ObsidianMid
    };
}