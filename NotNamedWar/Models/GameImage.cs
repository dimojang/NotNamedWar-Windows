using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameImage : GameControl
    {
        public Texture2D Image { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visibility) return;
            spriteBatch.Draw(Image, Position, Color.White);
        }
    }
}
