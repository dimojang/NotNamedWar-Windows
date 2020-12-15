using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameListViewItem
    {
        public GameImage Image { get; set; } = new GameImage();

        public GameLabel Label { get; set; } = new GameLabel();
    }
}
