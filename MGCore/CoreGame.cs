#define RENDERTARGETTEST

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace MGCore
{


    /// <summary>
    /// Basic UI and core app level functions for YOUR  game .  for mobile and desktop platforms, built over the general purpose   XNA Game based code
    /// The platfrom dependent parts over this are designed to be as thin as possible, with all shared functionality and game asssets in here
    /// </summary>
    public class CoreGame : MGGameCore
    {

        //global settings

        internal const int MsaaSampleLimit = 32;


        public static new CoreGame Instance;

        public CoreGame()
        {
            Instance=this;
        }


        static public bool IsDirectX = false;



        protected override void Initialize()
        {
            base.Initialize();
        }


        Texture2D spritetoClip;



        SpriteBatch spriteBatch;


        Texture2D striteClipMask;
        protected override void LoadContent()
        {


            base.LoadContent();


            //we always have a Device by here
            GraphicsDevice.PresentationParameters.MultiSampleCount           // set to windows limit, if gpu doesn't support it, monogame will autom. scale it down to the next supported level
            =GraphicsDeviceManager.PreferMultiSampling ? MsaaSampleLimit : 0;



            Window.Title="MG Cross Platform Shaders "+(IsDirectX ? "DirectX" : "OpenGL");


            Window.AllowUserResizing=true;

#if RENDERTARGETTEST
            Window.Title+=" Render Target";
#endif

            spriteBatch=new SpriteBatch(GraphicsDevice);


            //       shader = Content.Load<Effect>("Invert");

            spritetoClip=Content.Load<Texture2D>("surge");

            clip=Content.Load<Effect>("ClipShader");

            striteClipMask=Content.Load<Texture2D>("surgeclip");
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

            //TODO put this on the callback from the GameLoop, it call poll faster on the bk thread that can be faster than 60 hhz , works ok . occasiona touch exceptio colection modified but doesnt seem an issue
            base.Update(gt); //updates the Input keys

        }




        Texture2D clippedTex = null;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);


#if RENDERTARGETTEST
            if (clippedTex==null)
            {
                clippedTex=Rasterizer.GetClippedTexture(GraphicsDevice, spritetoClip, striteClipMask, clip);

            }

            UInt32[] color = new UInt32[spritetoClip.Width*spritetoClip.Height];
            clippedTex.GetData<UInt32>(color);

            //    GraphicsDevice.Clear(Color.Transparent);


            BasicEffect var = new BasicEffect(GraphicsDevice);
       

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

        
        }


    }

}
