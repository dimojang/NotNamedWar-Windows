using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameListViewItem
    {
        private Rectangle position = Rectangle.Empty;
        public Rectangle Position
        {
            get
            {
                return position;
            }
            set
            {
                Background.Position = value;
                Label.Position = new Vector2(value.X, value.Y);
                position = value;
            }
        }

        public GameImage Background { get; set; } = new GameImage();

        public GameLabel Label { get; set; } = new GameLabel();

        public string Tag { get; set; } = "";

        public void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            Label.Draw(spriteBatch);
        }
    }
}
