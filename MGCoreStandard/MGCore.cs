
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using System;


namespace MGStandard
{
    public class MGCore : Game
    {
        protected GraphicsDeviceManager _graphicsManager;
        protected SpriteBatch _spriteBatch;

        protected SpriteFont _font;

  
        public static MGCore Instance => _instance;

        /// <summary>
        /// facilitates easy access to the global Content instance for internal classes
        /// </summary>
        internal static MGCore _instance;



        /// <summary>
        /// enables/disables if we should quit the app when escape is pressed
        /// </summary>
        public static bool ExitOnEscapeKeypress = false;//we handing this in game code for Back
        


        public GraphicsDeviceManager GraphicsDeviceManager { get => _graphicsManager; }



        public MGCore()
         {

             _graphicsManager = new GraphicsDeviceManager(this)
            {
             //   PreferredBackBufferWidth = width,
           //     PreferredBackBufferHeight = height,
          //      IsFullScreen = isFullScreen,
                SynchronizeWithVerticalRetrace = true
            };

            _graphicsManager.GraphicsProfile = GraphicsProfile.HiDef;


            _graphicsManager.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;

        //    _graphicsManager.IsFullScreen = isFullScreen;


            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _instance = this;
             Window.Title = "CrossPlatformShaderSample";
       



        }

               public  int Width
        {
            get => _graphicsManager.PreferredBackBufferWidth;
            set => _graphicsManager.PreferredBackBufferWidth= value;
        }

        public bool IsFullScreen { get => _graphicsManager.IsFullScreen; set => _graphicsManager.IsFullScreen = value; }

        /// <summary>
        /// height of the GraphicsDevice back buffer
        /// </summary>
        /// <value>The height.</value>
        public  int Height
        {
            get => _graphicsManager.PreferredBackBufferHeight;
            set => _graphicsManager.PreferredBackBufferHeight = value;
        }



    


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

       
        }




   
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


           
              
            //loading a biggest font and scale by .5 seemms to work better
            _font = Content.Load<SpriteFont>("Console32");// or arial



       }


        bool once = true;


        protected override void Update(GameTime gameTime)
        {

    

                    base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
        

            base.Draw(gameTime);//draws the DrawableComponent
        }


        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
        }

    }
}
