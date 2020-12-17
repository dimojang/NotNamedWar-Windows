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
        running,
        battle,
        story,
        battle_prepare,
        battle_teach_p1,
        battle_develop_p1,
        battle_teamup_p1,
        battle_teach_p2,
        battle_develop_p2,
        battle_teamup_p2
    }

    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private UIManager StartPage = new UIManager();
        private UIManager BattlePreparePage = new UIManager();
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
            //### Add controls ###
            StartPage.ButtonManager.AddButton("对抗模式", "story_start", new Rectangle(573, 359, 220, 50), 
                () => { GameState = GameState.battle_prepare; });
            StartPage.ButtonManager.AddButton("战役模式", "battle_start", new Rectangle(573, 409, 220, 50), () => { });
            StartPage.LabelManager.AddLabel("NOT NAMED WAR", "title", new Point(100,100), new Font("微软雅黑", 80));
            #endregion

            #region Battle prepare page
            BattlePreparePage.DefaultFont = new Font("微软雅黑", 20);
            BattlePreparePage.ButtonManager.DefaultTextures = new List<Texture2D>()
            {
                Content.Load<Texture2D>("ButtonTextures/Default"),
                Content.Load<Texture2D>("ButtonTextures/MouseMove"),
                Content.Load<Texture2D>("ButtonTextures/MouseDown")
            };
            BattlePreparePage.ListViewManager.DefaultBackground = Content.Load<Texture2D>("test");

            BattlePreparePage.ListViewManager.AddListView(new Rectangle(0, 0, 200, 698), new Point(200, 80), "player_list");
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
                case GameState.battle:
                    break;
                case GameState.story:
                    break;
                case GameState.battle_prepare:
                    BattlePreparePage.Update(Mouse.GetState());
                    break;
                case GameState.battle_teach_p1:
                    break;
                case GameState.battle_develop_p1:
                    break;
                case GameState.battle_teamup_p1:
                    break;
                case GameState.battle_teach_p2:
                    break;
                case GameState.battle_develop_p2:
                    break;
                case GameState.battle_teamup_p2:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

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
                case GameState.battle:
                    break;
                case GameState.story:
                    break;
                case GameState.battle_prepare:
                    BattlePreparePage.Draw(_spriteBatch, GraphicsDevice);
                    break;
                case GameState.battle_teach_p1:
                    break;
                case GameState.battle_develop_p1:
                    break;
                case GameState.battle_teamup_p1:
                    break;
                case GameState.battle_teach_p2:
                    break;
                case GameState.battle_develop_p2:
                    break;
                case GameState.battle_teamup_p2:
                    break;
                default:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
