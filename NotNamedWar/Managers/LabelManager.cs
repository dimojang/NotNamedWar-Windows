using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotNamedWar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Managers
{
    class LabelManager
    {
        public List<GameLabel> Labels { get; set; } = new List<GameLabel>();

        public System.Drawing.Font DefaultFont { get; set; }

        public System.Drawing.Color DefaultFontColor { get; set; } = System.Drawing.Color.White;

        public GameLabel LabelTag(string Tag)
        {
            foreach (GameLabel label in Labels)
                if (label.Tag == Tag) return label;
            return null;
        }

        public void AddLabel(string Content, string Tag, Point Location)
        {
            Labels.Add(new GameLabel() 
            { 
                Content = Content,
                Tag = Tag,
                Location = Location,
                Font = DefaultFont,
                FontColor = DefaultFontColor
            });
        }
        public void AddLabel(string Content, string Tag, Point Location, System.Drawing.Font Font)
        {
            Labels.Add(new GameLabel()
            {
                Content = Content,
                Tag = Tag,
                Location = Location,
                Font = Font,
                FontColor = DefaultFontColor
            });
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            foreach (GameLabel label in Labels)
                label.Draw(spriteBatch, graphicsDevice);
        }
    }
}
