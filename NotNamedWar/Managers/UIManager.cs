using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Managers
{
    class UIManager
    {
        private SpriteFont defaultFont;
        public SpriteFont DefaultFont
        {
            get
            {
                return defaultFont;
            }
            set
            {
                defaultFont = value;
                ButtonManager.DefaultFont = value;
                LabelManager.DefaultFont = value;
            }
        }

        public ButtonManager ButtonManager { get; set; } = new ButtonManager();

        public LabelManager LabelManager { get; set; } = new LabelManager();

        public ImageManager ImageManager { get; set; } = new ImageManager();

        public void Update(MouseState mouse)
        {
            ButtonManager.Update(mouse.Position, mouse.LeftButton);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ImageManager.Draw(spriteBatch);
            ButtonManager.Draw(spriteBatch);
            LabelManager.Draw(spriteBatch);
        }
    }
}
