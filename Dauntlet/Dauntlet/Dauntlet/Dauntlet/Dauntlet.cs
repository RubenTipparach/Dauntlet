using System.Collections.Generic;
using Dauntlet.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dauntlet
{
    public enum Screen
    {
        SplashScreen,
        GameplayScreen,
        PauseScreen,
        TitleScreen,
        LoadingScreen,
    }

    public class Dauntlet : Game
    {
        private readonly Dictionary<Screen, GameScreen> _screens = new Dictionary<Screen, GameScreen>();
        private readonly GraphicsDeviceManager _graphics;
        private Screen _currentScreenType;
        private GameScreen CurrentScreen { get { return _screens[_currentScreenType]; } }

        public GraphicsDevice Graphics { get { return _graphics.GraphicsDevice; } }
        public SpriteFont Font { get; set; }
        public InputState Input;

        public Dauntlet()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _currentScreenType = Screen.TitleScreen;
            Input = new InputState();
        }

        protected override void LoadContent()
        {
            Font = Content.Load<SpriteFont>("loadingFont");

            SoundManager.LoadContent(Content);
            //_screens.Add(Screen.SplashScreen, new SplashScreen(this));
            _screens.Add(Screen.GameplayScreen, new GameplayScreen(this));
            _screens.Add(Screen.TitleScreen, new MainMenuScreen(this));
            _screens.Add(Screen.LoadingScreen, new LoadScreen(this));
            _screens.Add(Screen.PauseScreen, new PauseScreen(this));
            
            // The Loading screen is always loaded
            _screens[Screen.LoadingScreen].LoadContent();
            _screens[Screen.PauseScreen].LoadContent();
            
            CurrentScreen.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            CurrentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            CurrentScreen.Draw(gameTime);
            base.Draw(gameTime);
        }

        public GameScreen GetScreen(Screen screenType)
        {
            return _screens[screenType];
        }

        // Load a new primary screen without unloading the previous
        public void OverlayScreen(Screen screenType)
        {
            _currentScreenType = screenType;
        }

        // Load a new primary screen by first unloading the previous
        public void ChangeScreen(Screen screenType)
        {
            CurrentScreen.UnloadContent();

            if (!_screens[screenType].IsLoaded)
            {
                ((LoadScreen)_screens[Screen.LoadingScreen]).BeginLoadingScreen(screenType);
                _currentScreenType = Screen.LoadingScreen;
            }
            else
                _currentScreenType = screenType;
        }

    }
}
