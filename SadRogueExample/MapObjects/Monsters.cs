using SadRogue.Integration;
using SadRogueExample.MapObjects.Components.AI;
using SadRogueExample.MapObjects.Components;
using SadRogueExample.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadRogueExample.MapObjects
{
    internal static class Monsters
    {
        public static RogueLikeEntity Skeleton()
        {
            var enemy = new RogueLikeEntity(Colors.SkeletonColor, 's', false, layer: (int)GameMap.Layer.Monsters)
            {
                Name = "Skeleton"
            };

            // Add AI component to bump action toward the player if the player is in view
            enemy.AllComponents.Add(new HostileAI());
            enemy.AllComponents.Add(new Combatant(10, 0, 3));

            return enemy;
        }

        public static RogueLikeEntity Goblin()
        {
            var enemy = new RogueLikeEntity(Colors.GoblinColor, 'g', false, layer: (int)GameMap.Layer.Monsters)
            {
                Name = "Goblin"
            };

            // Add AI component to bump action toward the player if the player is in view
            enemy.AllComponents.Add(new HostileAI());
            enemy.AllComponents.Add(new Combatant(10, 1, 4));

            return enemy;
        }
    }
}
