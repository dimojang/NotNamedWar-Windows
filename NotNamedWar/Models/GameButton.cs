using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotNamedWar.GameMethod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NotNamedWar.Models
{
    class GameButton : GameControl
    {
        public GameLabel Content { get; set; } = new GameLabel();

        public List<Texture2D> ButtonTextures { get; set; }

        public List<System.Drawing.Color> FontColors { get; set; }

        public void Update(Point MousePosition, ButtonState MouseButtonState)
        {
            if (GameMath.Contain(Position, MousePosition))
                if (MouseButtonState == ButtonState.Pressed)
                    State = ControlState.MouseDown;
                else
                {
                    //Click event detect
                    if (State == ControlState.MouseDown)
                        Click();
                    State = ControlState.MouseMove;
                }
            else
                State = ControlState.None;

            Content.Location = new Point(Position.X + (Size.X - Content.PrintedSize.X) / 2, Position.Y + (Size.Y - Content.PrintedSize.Y) / 2);
            Content.FontColor = FontColors[(int)State];
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (!Visibility) return;

            spriteBatch.Draw(ButtonTextures[(int)State], Position, Color.White);

            Content.Draw(spriteBatch, graphicsDevice);
        }
    }
}
