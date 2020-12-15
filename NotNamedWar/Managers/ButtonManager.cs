using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotNamedWar.Models;

namespace NotNamedWar.Managers
{
    class ButtonManager
    {
        public List<GameButton> Buttons { get; set; } = new List<GameButton>();

        public List<Texture2D> DefaultTextures { get; set; }

        public List<Color> DefaultColors { get; set; } = new List<Color>() { Color.White, Color.Black, Color.Green };

        public SpriteFont DefaultFont { get; set; }

        public void RemoveButton(string Tag)
        {
            bool isSucess = false;
            foreach (GameButton button in Buttons)
                if (button.Tag == Tag) isSucess = Buttons.Remove(button);
            if (!isSucess) throw new Exception("Failed to find button with tag: " + Tag + ".");
        }

        public void ChangeButtonVisibility(string Tag, bool Visibility)
        {
            bool isSucess = false;
            foreach (GameButton button in Buttons)
                if (button.Tag == Tag)
                {
                    button.Visibility = Visibility;
                    isSucess = true;
                }
            if (!isSucess) throw new Exception("Failed to find button with tag: " + Tag + ".");
        }

        public void AddButton(string Content, string Tag, Rectangle Position, Trigger Click)
        {
            Buttons.Add(new GameButton() 
            { 
                Content = new GameLabel() 
                {
                    Content = Content, 
                    Font = DefaultFont 
                }, 
                Tag = Tag,
                Position = Position, 
                ButtonClick = Click,
                ButtonTextures = DefaultTextures,
                FontColors = DefaultColors
            });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameButton button in Buttons)
                button.Draw(spriteBatch);
        }

        public void Update(Point MousePosition, ButtonState MouseButtonState)
        {
            //Click detection
            foreach (GameButton button in Buttons)
            {
                int verticalMax = button.Position.Y + button.Position.Height;
                int horizontalMax = button.Position.X + button.Position.Width;

                if (MousePosition.X < horizontalMax && 
                    MousePosition.Y < verticalMax && 
                    MousePosition.X > button.Position.X && 
                    MousePosition.Y > button.Position.Y)
                {
                    button.ButtonState = (MouseButtonState == ButtonState.Pressed) ? 
                        GameButtonState.MouseDown : 
                        GameButtonState.MouseMove;

                    if (MouseButtonState == ButtonState.Released && 
                        button.isClicked && 
                        button.Visibility) 
                        button.ButtonClick();
                }
                else 
                    button.ButtonState = GameButtonState.Default;
            }
        }
    }
}
