using System.Collections.Generic;
using SadConsole;
using SadRogue.Integration;
using SadRogue.Primitives;
using SadRogueExample.MapObjects.Components;
using SadRogueExample.MapObjects.Components.AI;
using SadRogueExample.Maps;

namespace SadRogueExample.MapObjects;

internal readonly record struct TerrainAppearanceDefinition(ColoredGlyph Light, ColoredGlyph Dark);

/// <summary>
/// Simple class with some static functions for creating map objects.
/// </summary>
internal static class Factory
{
    /// <summary>
    /// Appearance definitions for various types of terrain objects.  It defines both their normal color, and their
    /// "explored but out of FOV" color.
    /// </summary>
    private static readonly Dictionary<string, TerrainAppearanceDefinition> AppearanceDefinitions = new()
    {
        {
            "Floor",
            new TerrainAppearanceDefinition(
                new ColoredGlyph(Colors.FloorFov,Colors.FloorBackgroundFov, '.'),
                new ColoredGlyph(Colors.Floor, Colors.FloorBackground, '.')
            )
        },
        {
            "Wall",
            new TerrainAppearanceDefinition(
                new ColoredGlyph(Colors.WallFov, Colors.WallBackgroundFov, '#'),
                new ColoredGlyph(Colors.Wall, Colors.WallBackground, '#')
            )
        },
        {
            "Door",
            new TerrainAppearanceDefinition(
                new ColoredGlyph(Colors.DoorFov, Colors.DoorBackgroundFov, '+'),
                new ColoredGlyph(Colors.Door, Colors.DoorBackground, '+')
            )
        },
        {
            "StairUp",
            new TerrainAppearanceDefinition(
                new ColoredGlyph(Colors.FloorFov, Colors.FloorBackgroundFov, '^'),
                new ColoredGlyph(Colors.Floor, Colors.FloorBackground, '^')
            )
        },
        {
            "StairDown",
            new TerrainAppearanceDefinition(
                new ColoredGlyph(Colors.FloorFov, Colors.FloorBackgroundFov, 'v'),
                new ColoredGlyph(Colors.Floor, Colors.FloorBackground, 'v')
            )
        },
    };

    public static Terrain Floor(Point position)
        => new(position, AppearanceDefinitions["Floor"], (int)GameMap.Layer.Terrain);

    public static Terrain Wall(Point position)
        => new(position, AppearanceDefinitions["Wall"], (int)GameMap.Layer.Terrain, false, false);

    public static RogueLikeEntity StairUp()
    {
        var stair = new RogueLikeEntity(Colors.Door, '^', false, true, layer:(int)GameMap.Layer.Stairs);

        stair.AllComponents.Add(new Stair(true));

        return stair;
    }

    public static RogueLikeEntity StairDown()
    {
        var stair = new RogueLikeEntity(Colors.Door, 'v', false, true, layer: (int)GameMap.Layer.Stairs);

        stair.AllComponents.Add(new Stair(false));

        return stair;
    }

    public static RogueLikeEntity Player()
    {
        // Create entity with appropriate attributes
        var player = new RogueLikeEntity(Colors.Player, '@', false, layer: (int)GameMap.Layer.Monsters)
        {
            Name = "Player"
        };

        // Add component for updating map's player FOV as they move
        player.AllComponents.Add(new PlayerFOVController { FOVRadius = 8 });

        // Player combatant
        player.AllComponents.Add(new Combatant(30, 2, 5));

        // Player inventory
        player.AllComponents.Add(new Inventory(26));

        return player;
    }

    public static RogueLikeEntity Orc()
    {
        var enemy = new RogueLikeEntity(Colors.OozeColor, 'o', false, layer: (int)GameMap.Layer.Monsters)
        {
            Name = "Orc"
        };

        // Add AI component to bump action toward the player if the player is in view
        enemy.AllComponents.Add(new HostileAI());
        enemy.AllComponents.Add(new Combatant(10, 0, 3));

        return enemy;
    }

    public static RogueLikeEntity Troll()
    {
        var enemy = new RogueLikeEntity(Colors.GoblinColor, 'T', false, layer: (int)GameMap.Layer.Monsters)
        {
            Name = "Troll"
        };

        // Add AI component to bump action toward the player if the player is in view
        enemy.AllComponents.Add(new HostileAI());
        enemy.AllComponents.Add(new Combatant(16, 1, 4));

        return enemy;
    }

    public static RogueLikeEntity Corpse(RogueLikeEntity entity)
        => new(entity.Appearance, layer: (int)GameMap.Layer.Items)
        {
            Name = $"Remains - {entity.Name}",
            Position = entity.Position,
            Appearance =
            {
                Glyph = '%'
            }
        };
}