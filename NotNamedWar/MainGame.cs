using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using NotNamedWar.Models;
using NotNamedWar.Managers;
using System.Collections.Generic;

namespace NotNamedWar
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private UIManager StartPage = new UIManager();
        private GameState GameState = new GameState();

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            #region Start page
            //### Static resources ###
            StartPage.DefaultFont = Content.Load<SpriteFont>("DefaultFont");
            StartPage.ButtonManager.DefaultTextures = new List<Texture2D>() 
            {
                Content.Load<Texture2D>("ButtonTextures/Default"),
                Content.Load<Texture2D>("ButtonTextures/MouseMove"),
                Content.Load<Texture2D>("ButtonTextures/MouseDown")
            };
            //### Add controls ###
            StartPage.ButtonManager.AddButton("CLICK TO START", "start_button", new Rectangle(150, 150, 200, 50), 
                () => 
                {
                    //GameState.RunningState = RunningState.running;
                    StartPage.ButtonManager.ChangeButtonVisibility("start_button", false);
                    StartPage.LabelManager.RepositionLabel("title", new Vector2(50, 50));
                });
            StartPage.LabelManager.AddLabel("NOT NAMED WAR", "title", new Vector2(100,100), Content.Load<SpriteFont>("TitleFont"));
            StartPage.ImageManager.AddImage(Content.Load<Texture2D>("test"), new Rectangle(0, 0, 1366, 680), "test");
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (GameState.RunningState)
            {
                case RunningState.start:
                    StartPage.Update(Mouse.GetState());
                    break;
                case RunningState.suspend:
                    break;
                case RunningState.running:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            switch (GameState.RunningState)
            {
                case RunningState.start:
                    StartPage.Draw(_spriteBatch);
                    break;
                case RunningState.suspend:
                    break;
                case RunningState.running:
                    break;
                default:
                    break;
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
