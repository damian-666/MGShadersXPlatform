using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using System;
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

            //dont do anything here.   over 2 ms.. its on the UI thread.
            //will try to use this  on key evens, now polling the key state, on a bk thread.. at up to 4000fps..
            //using the Nez core method
            //
            //  TODO look at new MG keyboard events and set if its better.
            //they should come in via interupt.   I personally dont care.  mines fine.  get key pressed and relesed events, and the state of the keys at any time.  virtual game pad on pc and map game pad to keyboard for now.

            //TODO special analog stick events for mobiile, touch to do waht mouse can do, and or analog stick to do what mouse cna do... its now just a 8 way joystick wiht 8 positions, or neutral.  

            //todo shou a producer / consumer pattern, timers and game loop that loads the CPU if needed.
            //threds for physics , AI , other.   

            // i get touch, unfied key handling and gamepad via custom input manager though.
            // TODO show parts of Nez thats are great, lie the input manager and the sheduler thing.

            //TODO use the new Mg Vectors and show some SIMD code and saving models with Vector2 in MG.. but, doing calculations via numerics when they are converted..  to Vector2<float>   then   copy back to Vector2 (MG) for drawig

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //render that last frame the CPU generated and copied to a display list or something,   while  the GPU is still rendering, that CPU game loop can work on the next frame, in parallel  and not block ui thread except in here.  .   the CPU can use total cores -1  ...whout scheduling conflics.   the CPU uses a timer and sleeps to whatever framerate the user or designer wants to cap at.. 
            //TODO show how to settimerresolution  on windows , linxu , osx, android, ios,  to get the most out of the CPU and GPU.  but not waste users time on one thread, or heat and drain the battery when hyou dont need to have a 1 ms thread..  its expensive to have that.. 4 ms is fair.. 16 ms is unless.. that is the defualt on windows....  On windows the timer resolution is NOTGLOBAL annymore.  
            base.Draw(gameTime);
        }


        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
        }

    }
}
