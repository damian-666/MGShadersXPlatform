//#define RENDERTARGETTEST
#define BLOOMTEST  //TODO  ///mabye do this to lines..

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading.Tasks;

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


        //---- Gloom effect variables -------------
        private GraphicsDeviceManager graphics;
        GraphicsDevice gpu;
        private RenderTarget2D mainTarget, renderTarg1;
        private Texture2D _image;
        private Rectangle deskRect;
        private float pulse, pulse_dir = 0.1f; // pulse controls saturation for bloom and pulse_dir control to increase or decreae for pulse (Causng it to pulse).

        Bloom bloom;


        public CoreGame()
        {
            Instance=this;
        }


        static public bool IsDirectX = false;



        protected override void Initialize()
        {
            SetGraphicTarget();
            base.Initialize();
        }


        Texture2D spritetoClip;



        SpriteBatch spriteBatch;


        Texture2D striteClipMask;
        protected override void LoadContent()
        {

            bloom = new Bloom(gpu, spriteBatch);
            bloom.LoadContent(Content);
            _image = Content.Load<Texture2D>("surge");

            base.LoadContent();


            //we always have a Device by here
            GraphicsDevice.PresentationParameters.MultiSampleCount=0;
            // set to windows limit, if gpu doesn't support it,
            // monogame will autom. scale it down to the next supported 
          //      GraphicsDeviceManager.PreferMultiSamplingMsaaSampleLimit : 0;
     //       0,


            Window.Title="MG Cross Platform Shaders "+(IsDirectX ? "DirectX" : "OpenGL");


            Window.AllowUserResizing=true;

#if RENDERTARGETTEST
            Window.Title+=" Render Target";
#endif

            spriteBatch=new SpriteBatch(GraphicsDevice);


            //       shader = Content.Load<Effect>("Invert");

            spritetoClip=Content.Load<Texture2D>("surge");

#if RENDERTARGETTEST

  clip=Content.Load<Effect>("ClipShaderSpriteTarget");
#else
            clip=Content.Load<Effect>("ClipShader");
#endif

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
#if BLOOMTEST
                    SetBloomPulse();
#endif
            //TODO put this on the callback from the GameLoop, it call poll faster on the bk thread that can be faster than 60 hhz , works ok . occasiona touch exceptio colection modified but doesnt seem an issue
            base.Update(gt); //updates the Input keys

        }




        Texture2D clippedTex = null;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Orange);
       


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


#elif (!BLOOMTEST)
            //TODO try clipping directly using advice from link in task about masks from community, t1,t2 registers , pass just the clip mask. draw through the efffect, no
            //rendertarget needed


//            GraphicsDevice.Textures[1]=striteClipMask;
//            GraphicsDevice.SamplerStates[1]=SamplerState.PointClamp;

//            clip.Parameters[0].SetValue(striteClipMask);
//             clip.Parameters[1].SetValue(spriteCat); ;

//             //   spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null);
////
//         spriteBatch.Begin(SpriteSortMode.Deferred, //BlendState.AlphaBlend, null, null, null, clip);


//              spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, null, null, clip);

            Rectangle rct = GraphicsDevice.Viewport.Bounds;

            //            spriteBatch.Draw(spritetoClip,rct, Color.Transparent); ;

            //           //    spriteBatch.Draw(spriteCat, Vector2.Zero, Color.White);
            //           //no because we really wann just draw whats in the mask , it will skip alpha so it wond work the other way...   
            //           //sending blend mode sourcealpha might work but this is fine
            //               spriteBatch.End();


            GraphicsDevice.Clear(Color.Orange);
            GraphicsDevice.SamplerStates[1]=SamplerState.PointWrap;

            GraphicsDevice.SamplerStates[0]=SamplerState.PointClamp;
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, clip);
            clip.Parameters[0].SetValue(striteClipMask);
            spriteBatch.Draw(spritetoClip, rct, Color.White);
            spriteBatch.End();



#else

          DrawWithBloom();

#endif
            

        }


        private void DrawWithBloom()
        {
            gpu.SetRenderTarget(mainTarget);

            bloom.Draw(_image, mainTarget);

            gpu.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
            spriteBatch.Draw(mainTarget, deskRect, new Color (1, 1, 1, 0.5f));
            spriteBatch.End();

        }
        private void SetGraphicTarget()
        {
            graphics = GraphicsDeviceManager;
            graphics.PreferredDepthStencilFormat = DepthFormat.None;
            //deskRect.Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //deskRect.Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            deskRect.Width = 800;
            deskRect.Height = 600;
            graphics.PreferredBackBufferWidth = deskRect.Width;
            graphics.PreferredBackBufferHeight = deskRect.Height;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            gpu = GraphicsDevice;
            //graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            PresentationParameters pp = GraphicsDevice.PresentationParameters;
            spriteBatch = new SpriteBatch(gpu);
            mainTarget = new RenderTarget2D(gpu, 800, 600, false, pp.BackBufferFormat, DepthFormat.Depth24);
        }

        private void SetBloomPulse()
        {
            // Adjust saturation - make it pulse:
            pulse += pulse_dir;
            if (pulse > 4) pulse_dir = -0.1f;
            if (pulse < 2) pulse_dir = 0.1f;
            bloom.BaseIntensity = pulse;
        }
    }

}
