
using MGCore.DrawTests;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace MGCore
{


    /// <summary>
    /// Basic UI and core app level functions for YOUR  game .  for mobile and desktop platforms, built over the general purpose   XNA Game based code
    /// The platfrom dependent parts over this are designed to be as thin as possible, with all shared functionality and game asssets in here
    /// </summary>
    public class GraphicsTestRig : MGGameCore
    {



        public static new GraphicsTestRig Instance;



        IDrawTest CurrentDrawTest;

        public GraphicsTestRig()
        {
            Instance=this;
        }




        protected override void Initialize()
        {
            base.Initialize();
        }


        public static bool IsDirectX = true;


        protected override void LoadContent()
        {

            base.LoadContent();   //mabye dont do this.. conetn get load in each test.. and w em might unlaod it too... or IDispose it...  //TODO
            

            CurrentDrawTest=new NeonLine();
            
            CurrentDrawTest.Initialize(GraphicsDevice, GraphicsDeviceManager, Content);
            
            //todo move this to eahch test... 

            ////we always have a Device by here
            //GraphicsDevice.PresentationParameters.MultiSampleCount           // set to windows limit, if gpu doesn't support it, monogame will autom. scale it down to the next supported level
            //=GraphicsDeviceManager.PreferMultiSampling ? MsaaSampleLimit : 0;


            Window.Title="MG Cross Platform Shaders "+(IsDirectX ? "DirectX" : "OpenGL"+CurrentDrawTest.GetType().Name);


            Window.AllowUserResizing=true;



        }
        protected override void OnActivated(object sender, EventArgs args)
        {
            base.OnActivated(sender, args);
        }



        protected override void BeginRun()
        {

            //either use ui or just run thoug all the tests with one sec deal or somehting .. or if next button presseed.. or scfeen touched .. 

        }

        /// <summary>
        /// TODO run a specific test form adrod or something
        /// </summary>
        /// <param name="i"></param>
        public bool RunTest(int i)
        {

            bool success = true;
            try
            {

            }

            catch (Exception ex)
            {
                Debug.Write(" test   "+i+" failed "+ex.Message);
                success=false;

            }
            return success;

        }

        /// <summary>
        /// todo use reflection or sometihgin to make a menu for droid to pick a rest..then put the code to just build a menu or set of buttson.. then call this.. 
        /// </summary>
        /// <param name="className"></param>
        public bool RunTest(string className)
        {//todo relfect?

            //so its eash just add a class and it will add ui and test
            return false;

        }



        protected override void Update(GameTime gt)
        {

            //TODO put this on the callback from the GameLoop, it call poll faster on the bk thread that can be faster than 60 hhz , works ok . occasiona touch exceptio colection modified but doesnt seem an issue
            base.Update(gt); //updates the Input keys

            //tOOD maeybe if free 1, 2 three on space to next test..ccyle back

        }



        protected override void Draw(GameTime gameTime)
        {

            CurrentDrawTest.Draw(gameTime);

#if MOVE

#if RENDERTARGETTEST
            if (clippedTex==null)
            {
                clippedTex=Rasterizer.GetClippedTexture(GraphicsDevice, spritetoClip, striteClipMask, clip);

            }

          //  UInt32[] color = new UInt32[spritetoClip.Width*spritetoClip.Height];
        //    clippedTex.GetData<UInt32>(color);

            //    GraphicsDevice.Clear(Color.Transparent);


   //         BasicEffect var = new BasicEffect(GraphicsDevice);
       

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null);


            Rectangle rct = GraphicsDevice.Viewport.Bounds;
         
            spriteBatch.Draw(clippedTex,   rct, null,  Color.White);
            //no because we really wann just draw whats in the mask , it will skip alpha so it wond work the other way...   
            //sending blend mode sourcealpha might work but this is fine
            spriteBatch.End();


#else
//TODO try clipping directly using advice from link in task about masks from community, t1,t2 registers , pass just the clip mask. draw through the efffect, no rendertarget needed
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

#endif

#endif
        }


    }

}
