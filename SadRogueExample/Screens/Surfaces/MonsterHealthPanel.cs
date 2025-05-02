using SadConsole;
using SadConsole.UI;
using SadRogue.Primitives;
using SadRogueExample.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadRogueExample.Screens.Surfaces
{
    internal class MonsterHealthPanel : ControlsConsole
    {
        public MonsterHealthPanel(int width, int height)
        : base(width, height)
        {
            this.DrawBox(new Rectangle(0, 0, width, height), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Swatch.ObsidianDark, Color.Black)));
            this.Print(8, 0, "Monsters");
        }
    }
}
