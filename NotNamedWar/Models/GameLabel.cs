using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

using Color = System.Drawing.Color;
using Point = Microsoft.Xna.Framework.Point;

namespace NotNamedWar.Models
{
    class GameLabel : GameControl
    {
        public Font Font { get; set; }

        public string Content { get; set; } = "";

        public Color FontColor { get; set; } = Color.Black;

        public Point PrintedSize
        {
            get
            {
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                SizeF realSzie = g.MeasureString(Content, Font);
                return (new Point((int)realSzie.Width, (int)realSzie.Height));
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (!Visibility) return;

            Texture2D texture2dContent;
            Brush brush = new SolidBrush(FontColor);
            
            Bitmap img = new Bitmap(PrintedSize.X, PrintedSize.Y);
            Graphics.FromImage(img).DrawString(Content, Font, brush, new PointF(0, 0));
            
            //Convert string to textture2d
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            texture2dContent = Texture2D.FromStream(graphicsDevice, ms);

            spriteBatch.Draw(texture2dContent, new Vector2(Location.X, Location.Y), Microsoft.Xna.Framework.Color.White);
        }
    }
}
