
using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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

        public bool UseEffects { get; set; }


        public static bool IsAndroid = false;

        /// <summary>
        /// enables/disables if we should quit the app when escape is pressed
        /// </summary>
        public static bool ExitOnEscapeKeypress = false;//we handing this in game code for Back



        public GraphicsDeviceManager GraphicsDeviceManager { get => _graphicsManager; }



        /// <summary>
        /// log a trace result
        /// 
        /// </summary>

        public PresentationParameters PresentationParms;
        public MGGameCore()
        {
#if  FINDAMODERNTHREADSAFEFILTERINGLOGGERWITHCATEGORYFILTERSANDUINADTHREADSAFE
            SimpleLogger.Instance.LogTrace(" MonoGame.Framework.Utilities.GraphicsBackend" + MonoGame.Framework.Utilities.PlatformInfo.GraphicsBackend);
            SimpleLogger.Instance.LogTrace().Log( Logger(" MonoGame.Framework.Utilities.GraphicsBackend" + MonoGame.Framework.Utilities.PlatformInfo.GraphicsBackend


#endif

            Trace.WriteLine("MonoGame.Framework.Utilities.GraphicsBackend"+MonoGame.Framework.Utilities.PlatformInfo.MonoGamePlatform.ToString());



            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            Window.ClientSizeChanged+=Window_ClientSizeChanged;
            
              if (!IsAndroid)
            {
            Window.TextInput+=Window_TextInput;


          
                Window.KeyDown+=Window_KeyDown;
                Window.KeyUp+=Window_KeyUp;
            }
            
     
            


            _graphicsManager=new GraphicsDeviceManager(this)
            {


                IsFullScreen = false,
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


            IsFullScreen=false;
        }

        private void Window_KeyUp(object sender, InputKeyEventArgs e)
        {

        //    Trace.WriteLine("windowkeyup"+e.ToString());
        }

        private void Window_KeyDown(object sender, InputKeyEventArgs e)
        {


            if (e.Key==Keys.E)
            {
                UseEffects=!UseEffects;
            }
            //  Trace.WriteLine("windowkeydown"+e.ToString());
        }

        private void Window_TextInput(object sender, TextInputEventArgs e)
        {
           //   Trace.WriteLine("Window_TextInput"+e.ToString());  

        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
             _graphicsManager.ApplyChanges();
            
        }

        public int Width
        {
            get => _graphicsManager.PreferredBackBufferWidth;
            set => _graphicsManager.PreferredBackBufferWidth=value;
        }

        public bool IsFullScreen
        { get => _graphicsManager.IsFullScreen; 
            set => _graphicsManager. IsFullScreen=value; }

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
            PresentationParms=_graphicsManager.GraphicsDevice.PresentationParameters;

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
