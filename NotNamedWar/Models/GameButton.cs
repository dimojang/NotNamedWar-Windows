using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    public enum GameButtonState
    {
        Default,
        MouseMove,
        MouseDown
    }
    public delegate void Trigger();

    class GameButton
    {
        public GameLabel Content { get; set; } = new GameLabel();

        public bool Visibility { get; set; } = true;

        public string Tag { get; set; } = "";

        private Rectangle position = new Rectangle();
        public Rectangle Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Content.Position = new Vector2(value.X, value.Y + value.Height / 2);
            }
        }

        public bool isClicked = false;
        private GameButtonState buttonState = GameButtonState.Default;
        public GameButtonState ButtonState
        {
            get
            {
                return buttonState;
            }
            set
            {
                isClicked = buttonState == GameButtonState.MouseDown && value == GameButtonState.MouseMove;
                buttonState = value;
                Content.FontColor = FontColors[(int)value];
            }
        }

        public List<Texture2D> ButtonTextures { get; set; }

        public List<Color> FontColors { get; set; }

        public Trigger ButtonClick { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Visibility) return;

            spriteBatch.Draw(ButtonTextures[(int)ButtonState], Position, Color.White);

            Content.Draw(spriteBatch);
                
        }
    }
}
