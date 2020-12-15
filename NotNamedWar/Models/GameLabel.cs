using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameLabel
    {
        public SpriteFont Font { get; set; }

        public bool Visibility { get; set; } = true;

        public string Tag { get; set; } = "";

        public string Content { get; set; } = "";

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Color FontColor { get; set; } = Color.Black;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visibility) return;
            spriteBatch.DrawString(Font, Content, Position, FontColor);
        }
    }
}
