using SadConsole.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadRogueExample.Screens.MainGameMenus
{
    class UseStairsConfirmation : MainGameMenu
    {
        private bool _isUp;

        public UseStairsConfirmation(bool isUp)
            : base(29, 6)
        {
            _isUp = isUp;

            Title = "Take the Stairs?";

            PrintTextAtCenter("Will you take the Stairs?", y: 2);

            var yesButton = new Button(13, height: 1)
            {
                Text = "Yes",
                Position = (2, 4),
            };
            yesButton.Click += yesOnClick;

            var noButton = new Button(11, height: 1)
            {
                Text = "No",
                Position = (16, 4),
            };
            noButton.Click += noOnClick;

            Controls.Add(yesButton);
            Controls.Add(noButton);
        }

        private void yesOnClick(object? sender, EventArgs e)
        {
            int level = Engine.GameScreen.currentLevel;

            if (_isUp)
                level--;

            else
                level++;

                Engine.GameScreen.changeLevel(level);
            Hide();
        }

        private void noOnClick(object? sender, EventArgs e)
        {
            Hide();
        }
    }
}
