using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using NotNamedWar.Models;
using NotNamedWar.Managers;
using System.Collections.Generic;
using System.Drawing;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace NotNamedWar
{
    enum GameState
    {
        start,
        suspend,
        running
    }

    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private UIManager StartPage = new UIManager();
        private GameState GameState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GameState = GameState.start;

            _graphics.PreferredBackBufferWidth = 1366;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            #region Start page
            //### Static resources ###
            StartPage.DefaultFont = new Font("微软雅黑", 20);
            StartPage.ButtonManager.DefaultTextures = new List<Texture2D>() 
            {
                Content.Load<Texture2D>("ButtonTextures/Default"),
                Content.Load<Texture2D>("ButtonTextures/MouseMove"),
                Content.Load<Texture2D>("ButtonTextures/MouseDown")
            };
            StartPage.ListViewManager.DefaultBackground = Content.Load<Texture2D>("test");
            //### Add controls ###
            StartPage.ButtonManager.AddButton("单击任意处开始", "start_button", new Rectangle(150, 150, 200, 50), 
                () => 
                {
                    StartPage.ButtonManager.ButtonTag("start_button").Visibility = false;
                    StartPage.LabelManager.LabelTag("title").Location = new Point(50, 50);
                });
            StartPage.LabelManager.AddLabel("NOT NAMED WAR", "title", new Point(100,100), new Font("微软雅黑", 80));
            StartPage.ImageManager.AddImage(Content.Load<Texture2D>("test"), new Rectangle(0, 0, 1366, 680), "test");
            //StartPage.ListViewManager.AddListView(new Rectangle(100, 5, 200, 300), new Point(200, 50), "test");
            //StartPage.ListViewManager.ListViewTag("test").AddListViewItem("aaaaaaaa");
            //StartPage.ListViewManager.ListViewTag("test").AddListViewItem("bbbbbbbb");
            //StartPage.ListViewManager.ListViewTag("test").AddListViewItem("aaaaacccccaaa");
            //StartPage.ListViewManager.ListViewTag("test").AddListViewItem("aaaaaccccdaaa");

            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (GameState)
            {
                case GameState.start:
                    StartPage.Update(Mouse.GetState());
                    break;
                case GameState.suspend:
                    break;
                case GameState.running:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            switch (GameState)
            {
                case GameState.start:
                    StartPage.Draw(_spriteBatch, GraphicsDevice);
                    break;
                case GameState.suspend:
                    break;
                case GameState.running:
                    break;
                default:
                    break;
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
