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

        public SpriteFont DefaultFont { get; set; }

        public Color DefaultFontColor { get; set; } = Color.Black;

        public void RepositionLabel(string Tag, Vector2 Position)
        {
            foreach (GameLabel label in Labels)
                if (label.Tag == Tag) label.Position = Position;
        }

        public void AddLabel(string Content, string Tag, Vector2 Position)
        {
            Labels.Add(new GameLabel() 
            { 
                Content = Content,
                Tag = Tag,
                Position = Position,
                Font = DefaultFont,
                FontColor = DefaultFontColor
            });
        }
        public void AddLabel(string Content, string Tag, Vector2 Position, SpriteFont Font)
        {
            Labels.Add(new GameLabel()
            {
                Content = Content,
                Tag = Tag,
                Position = Position,
                Font = Font,
                FontColor = DefaultFontColor
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameLabel label in Labels)
                label.Draw(spriteBatch);
        }
    }
}
