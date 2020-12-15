using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotNamedWar.Models;

namespace NotNamedWar.Managers
{
    class ImageManager
    {
        public List<GameImage> Images { get; set; } = new List<GameImage>();

        public void AddImage(Texture2D Image, Rectangle Position, string Tag)
        {
            Images.Add(new GameImage()
            {
                Image = Image,
                Position = Position,
                Tag = Tag
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameImage image in Images)
                image.Draw(spriteBatch);
        }
    }
}
