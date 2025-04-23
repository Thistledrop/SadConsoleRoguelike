using SadRogue.Primitives;
using SadRogueExample.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadRogueExample.Screens
{
    //TODO: Make singelton
    class MapManager
    {
        private Dictionary<int, GameMap> dungeon;

        public MapManager()
        {
            dungeon = new Dictionary<int, GameMap>();
        }

        public GameMap getLevelMap(int level)
        {
            GameMap? levelMap;
            dungeon.TryGetValue(level, out levelMap);

            if(levelMap != null)
            {
                levelMap.AddPlayerAtPosition(levelMap.stairsDownLocation.Subtract(Direction.Up));
                return levelMap; 
            }

            else
            {
                return createNewLevel(level);
            }
        }

        private GameMap createNewLevel(int level)
        {
            GameMap newMap = Maps.Factory.Dungeon(new(50, 30, 2, 3, 8, 12, 0, 0));
            newMap.AddPlayerAtPosition(newMap.stairsDownLocation);

            dungeon.Add(level, newMap);

            return newMap;
        }
    }
}
