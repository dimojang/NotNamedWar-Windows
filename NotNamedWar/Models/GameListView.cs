using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    class GameListView
    {
        public List<GameListViewItem> ListViewItems { get; set; } = new List<GameListViewItem>();

        public Vector2 ListViewItemSize { get; set; } = new Vector2(200, 50);

        private int deflect = 0;

        private Rectangle position = Rectangle.Empty;
        public Rectangle Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                int index = 0;
                foreach(GameListViewItem listViewItem in ListViewItems)
                {
                    listViewItem.Position = getAbsPosition(index);
                    index++;
                }
            }
        }

        public Texture2D DefaultBackground { get; set; }

        public SpriteFont DefaultFont { get; set; }

        public void AddListViewItem(Texture2D Background, SpriteFont Font, string Content, string Tag)
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

        public void Rolling()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameListViewItem listViewItem in ListViewItems)
                listViewItem.Draw(spriteBatch);
        }

        private Rectangle getAbsPosition(int index)
        {
            Rectangle result = new Rectangle(
                Position.X,
                (int)(Position.Y + index * ListViewItemSize.Y),
                (int)ListViewItemSize.X,
                (int)ListViewItemSize.Y);

            return result;
        }
    }
}
