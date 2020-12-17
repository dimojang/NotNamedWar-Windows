using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameListViewItem : GameControl
    {
        public GameImage Background { get; set; } = new GameImage();

        public GameLabel Label { get; set; } = new GameLabel();

        public void Update()
        {
            Background.Position = Position;
            Label.Location = new Point(Position.X + (Size.X - Label.PrintedSize.X) / 2, Position.Y + (Size.Y - Label.PrintedSize.Y) / 2);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Background.Draw(spriteBatch);
            Label.Draw(spriteBatch, graphicsDevice);
        }
    }
}
