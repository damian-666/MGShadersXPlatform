using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGCore
{
    public class MGGameCore : Game
    {
        protected GraphicsDeviceManager _graphicsManager;
        protected SpriteBatch _spriteBatch;

        protected SpriteFont _font;


        public static MGGameCore Instance => _instance;

        /// <summary>
        /// facilitates easy access to the global Content instance for internal classes
        /// </summary>
        internal static MGGameCore _instance;



        /// <summary>
        /// enables/disables if we should quit the app when escape is pressed
        /// </summary>
        public static bool ExitOnEscapeKeypress = false;//we handing this in game code for Back



        public GraphicsDeviceManager GraphicsDeviceManager { get => _graphicsManager; }



        public MGGameCore()
        {

            _graphicsManager=new GraphicsDeviceManager(this)
            {
                //   PreferredBackBufferWidth = width,
                //     PreferredBackBufferHeight = height,
                //      IsFullScreen = isFullScreen,   // dont so tis  use the transform and scale
                //  PreferMultiSampling=true,  //donest work on android
                SynchronizeWithVerticalRetrace=true  // use producer consumer.. run bk thread to run physics or whtever, copy viewable data to some kind of display list, draw the last good frame for multithreading..  to avoid locks or wait or semaphores in the draw method, cant generate a view while reading it..
            };

            _graphicsManager.GraphicsProfile=GraphicsProfile.HiDef;

            _graphicsManager.PreferredDepthStencilFormat=DepthFormat.Depth24Stencil8; //

            Content.RootDirectory="Content";
            IsMouseVisible=true;
            _instance=this;
            Window.Title="CrossPlatformCipShaderSample";


        }

        public int Width
        {
            get => _graphicsManager.PreferredBackBufferWidth;
            set => _graphicsManager.PreferredBackBufferWidth=value;
        }

        public bool IsFullScreen { get => _graphicsManager.IsFullScreen; set => _graphicsManager.IsFullScreen=value; }

        /// <summary>
        /// height of the GraphicsDevice back buffer
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get => _graphicsManager.PreferredBackBufferHeight;
            set => _graphicsManager.PreferredBackBufferHeight=value;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch=new SpriteBatch(GraphicsDevice);


            //loading a biggest font and scale by  factor of 2  seemms to work better
            _font=Content.Load<SpriteFont>("Console32");// or arial

        }




        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back==ButtonState.Pressed||Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
        }


        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
        }

    }
}
