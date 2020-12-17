using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NotNamedWar.Managers
{
    class UIManager
    {
        private Font defaultFont;
        public Font DefaultFont
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
                ListViewManager.DefaultFont = value;
            }
        }

        public ButtonManager ButtonManager { get; set; } = new ButtonManager();

        public LabelManager LabelManager { get; set; } = new LabelManager();

        public ImageManager ImageManager { get; set; } = new ImageManager();

        public ListViewManager ListViewManager { get; set; } = new ListViewManager();

        public void Update(MouseState mouse)
        {
            ButtonManager.Update(mouse.Position, mouse.LeftButton);
            ListViewManager.Update(mouse.ScrollWheelValue, mouse.Position);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            ImageManager.Draw(spriteBatch);
            ButtonManager.Draw(spriteBatch, graphicsDevice);
            LabelManager.Draw(spriteBatch, graphicsDevice);
            ListViewManager.Draw(spriteBatch, graphicsDevice);
        }
    }
}
