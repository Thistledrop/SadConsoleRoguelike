using SadRogue.Integration.Components;
using SadRogue.Integration;
using SadRogueExample.Screens.MainGameMenus;
using SadRogueExample.Screens.MainGameStates;

namespace SadRogueExample.MapObjects.Components
{
    internal class Stair : RogueLikeComponentBase<RogueLikeEntity>, IBumpable
    {
        public bool _isUp;

        public Stair(bool isUp)
            : base (false, false, false, false)
        {
            _isUp = isUp;
        }

        public bool OnBumped(RogueLikeEntity source)
        {
            if (Engine.GameScreen != null)
            {
                Engine.GameScreen.DisplayStairConfirmation(_isUp);
                return true;
            }
            else
                return false;
        }
    }
}
