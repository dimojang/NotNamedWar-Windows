using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameImage
    {
        public Rectangle Position { get; set; } = Rectangle.Empty;

        public Texture2D Image { get; set; }

        public bool Visibility { get; set; } = true;

        public string Tag { get; set; } = "";

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visibility) return;
            spriteBatch.Draw(Image, Position, Color.White);
        }
    }
}
