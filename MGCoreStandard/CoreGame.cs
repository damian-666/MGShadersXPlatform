﻿//#define TWOPASSDRAW
//#define CLIPTEST

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

using System.Diagnostics;


namespace MGStandard
{


    /// <summary>
    /// Basic UI and core app level functions for 2DOword for mobile and desktop platforms, built over the general purpose MGCore over XNA Game, Tool doesnt use this.
    /// The platfrom dependent parts over this are designed to be as thin as possible, with all shared functionality in here
    /// </summary>
    public class CoreGame : MGCore
    {

        public delegate string FileOpenDelegate(); //TOD get this working for window testing
        public static FileOpenDelegate OpenFileDlg;

        //global settings

        internal const int MsaaSampleLimit = 32;

        public static bool IsAndroid = false;

        public static bool ShowDebugInfo = true;

        public static bool ParallelDecodeJpg = true;

        public static bool ShowFPSTitle = true;

        public static bool IsUIMouseVisible = true;

 
        public static new CoreGame Instance;

        public CoreGame()
        {

            Instance = this;
            IsUIMouseVisible = true;
        }



        static public bool IsDirectX = false;



        protected override void Initialize()
        {
            base.Initialize();



        }




        Texture2D spriteCat;

        Effect shader;


        SpriteBatch spriteBatch;


        Texture2D catClipMask;
        protected override void LoadContent()
        {


            base.LoadContent();


            //we always have a Device by here
            GraphicsDevice.PresentationParameters.MultiSampleCount           // set to windows limit, if gpu doesn't support it, monogame will autom. scale it down to the next supported level
            = GraphicsDeviceManager.PreferMultiSampling ? MsaaSampleLimit : 0; 


    
        Window.Title = "MG Cross Platform Shaders " + (IsDirectX ? "DirectX" : "OpenGL");

      spriteBatch = new SpriteBatch(GraphicsDevice);


            shader = Content.Load<Effect>("Invert");

            spriteCat = Content.Load<Texture2D>("surge");

            clip = Content.Load<Effect>("ClipShader");

            catClipMask = Content.Load<Texture2D>("surgeclip");
        }


        Effect clip;


        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
        }



        protected override void BeginRun()
        {

        }



        protected override void Update(GameTime gt)
        {

            //TODO put this on the callback from the GameLoop
            base.Update(gt); //updates the Input keys

        }

    
      


        protected override void Draw(GameTime gameTime)
        {




            try
            {


                GraphicsDevice.Clear(Color.Yellow);

        
              clip.Parameters[0].SetValue(catClipMask);
                clip.Parameters[1].SetValue(spriteCat); ;

             //   spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null);
//
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, clip);
                

               spriteBatch.Draw(catClipMask, new Vector2(100,100), Color.White); ;

           //    spriteBatch.Draw(spriteCat, Vector2.Zero, Color.White);
           //no because we really wann just draw whats in the mask , it will skip alpha so it wond work the other way...   
           //sending blend mode sourcealpha might work but this is fine
                spriteBatch.End();

                base.Draw(gameTime);



            }



            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            finally
            {


            }


        }







    }
}
