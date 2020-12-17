using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NotNamedWar.Models;

namespace NotNamedWar.Managers
{
    class ListViewManager
    {
        public List<GameListView> listViews { get; set; } = new List<GameListView>();

        public Texture2D DefaultBackground { get; set; }

        public System.Drawing.Font DefaultFont { get; set; }

        public GameListView ListViewTag(string Tag)
        {
            foreach (GameListView listView in listViews)
                if (listView.Tag == Tag) return listView;
            return null;
        }

        public void AddListView(Rectangle Position, Point ItemSize, string Tag)
        {
            listViews.Add(new GameListView() 
            { 
                DefaultBackground = DefaultBackground, 
                DefaultFont = DefaultFont, 
                Position = Position,
                ListViewItemSize = ItemSize, 
                Tag = Tag 
            });
        }

        public void Update(int ScrollWheelValue, Point MousePosition)
        {
            foreach (GameListView listView in listViews)
                listView.Update(ScrollWheelValue, MousePosition);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            foreach (GameListView listView in listViews)
                listView.Draw(spriteBatch, graphicsDevice);
        }
    }
}
