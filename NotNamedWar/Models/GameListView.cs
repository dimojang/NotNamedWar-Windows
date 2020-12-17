using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using NotNamedWar.GameMethod;

namespace NotNamedWar.Models
{
    class GameListView : GameControl
    {
        public List<GameListViewItem> ListViewItems { get; set; } = new List<GameListViewItem>();

        public Point ListViewItemSize { get; set; } = new Point(200, 50);

        public ControlState ListViewState { get; set; } = ControlState.None;

        private int lastScrollWheelValue = 0;
        private int deflect = 0;

        public Texture2D DefaultBackground { get; set; }

        public System.Drawing.Font DefaultFont { get; set; }

        public void AddListViewItem(Texture2D Background, System.Drawing.Font Font, string Content, string Tag)
        {
            ListViewItems.Add(
                new GameListViewItem()
                {
                    Background = new GameImage()
                    {
                        Image = Background
                    },
                    Label = new GameLabel()
                    {
                        Font = Font,
                        Content = Content
                    },
                    Tag = Tag,
                    Position = getAbsPosition(ListViewItems.Count)
                });
        }
        public void AddListViewItem(string Content)
        {
            ListViewItems.Add(
                new GameListViewItem()
                {
                    Background = new GameImage()
                    {
                        Image = DefaultBackground
                    },
                    Label = new GameLabel()
                    {
                        Font = DefaultFont,
                        Content = Content
                    },
                    Position = getAbsPosition(ListViewItems.Count)
                });
        }

        public void Update(int ScrollWheelValue, Point MousePosition)
        {
            if (GameMath.Contain(Position, MousePosition))
            {
                if (ListViewState == ControlState.None)
                    lastScrollWheelValue = ScrollWheelValue;
                ListViewState = ControlState.MouseMove;
            }
            else
                ListViewState = ControlState.None;

            if(ListViewState == ControlState.MouseMove)
            {
                deflect += (ScrollWheelValue - lastScrollWheelValue) / 10;
                lastScrollWheelValue = ScrollWheelValue;
            }

            int index = 0;
            foreach (GameListViewItem listViewItem in ListViewItems)
            {
                listViewItem.Position = getAbsPosition(index);
                listViewItem.Update();
                index++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            int[] pixel = { 0xFFFFFF };
            texture.SetData<int>(pixel, 0, texture.Width * texture.Height);

            spriteBatch.Draw(texture, Position, Color.White);

            foreach (GameListViewItem listViewItem in ListViewItems)
                listViewItem.Draw(spriteBatch, graphicsDevice);
        }

        private Rectangle getAbsPosition(int index)
        {
            Rectangle result = new Rectangle(
                Position.X,
                (Position.Y + index * ListViewItemSize.Y + deflect),
                ListViewItemSize.X,
                ListViewItemSize.Y);

            return result;
        }
    }
}
