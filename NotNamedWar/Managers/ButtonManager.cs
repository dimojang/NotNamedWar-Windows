using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotNamedWar.Models;
using NotNamedWar.GameMethod;
using static NotNamedWar.Models.GameControl;
using System.Drawing;

using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace NotNamedWar.Managers
{
    class ButtonManager
    {
        private List<GameButton> buttons { get; set; } = new List<GameButton>();

        public List<Texture2D> DefaultTextures { get; set; }

        public List<System.Drawing.Color> DefaultColors { get; set; } = new List<System.Drawing.Color>() 
        { System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Wheat };

        public Font DefaultFont { get; set; }

        public void RemoveButton(string Tag)
        {
            foreach (GameButton button in buttons)
                if (button.Tag == Tag) buttons.Remove(button);
        }

        public GameButton ButtonTag(string Tag)
        {
            foreach (GameButton button in buttons)
                if (button.Tag == Tag)
                    return button;
            return null;
        }

        public void AddButton(string Content, string Tag, Rectangle Position, Trigger Click)
        {
            buttons.Add(new GameButton()
            {
                Content = new GameLabel()
                {
                    Content = Content,
                    Font = DefaultFont
                },
                Tag = Tag,
                Position = Position,
                Click = Click,
                ButtonTextures = DefaultTextures,
                FontColors = DefaultColors
            });
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            foreach (GameButton button in buttons)
                button.Draw(spriteBatch, graphicsDevice);
        }

        public void Update(Point MousePosition, ButtonState MouseButtonState)
        {
            foreach (GameButton button in buttons)
                button.Update(MousePosition, MouseButtonState);
        }
    }
}
