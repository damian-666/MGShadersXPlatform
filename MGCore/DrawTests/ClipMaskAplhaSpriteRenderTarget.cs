using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace MGCore.DrawTests
{
    /// <summary>
    ///  this is the code that use RendertoTextureTarget, i can prolly do this. i the old shader .  it loads one or two textures... and returns a sprite Tueure that has alpha channels intact.. the alpha is eithe draw or not.. it doens't have to blend.   Blending alpha isnt a concern at all its  255 or 0.. its a hole... or nothing for the use case im thinking of.  also consider surfaces with not have full 32 bti rbg not using alpha blend is probably good.   mabye can  clip using key color instead
    /// </summary>
    public class ClipMaskAlphaSpriteRenderTarget : DrawTestBase, IDisposable
    {
        public override void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm = null)
        {
            base.Initialize(cm, dev, gm);
            spriteBatch=new SpriteBatch(device);
            //TODO load the effect
            //TODO load the textures

            spritetoClip=cm.Load<Texture2D>("surge");

            clip=cm.Load<Effect>("ClipShader");

            striteClipMask=cm.Load<Texture2D>("surgeclip");
            spriteBatch=new (dev);

            if (clippedTex==null)
            {
                clippedTex=Rasterizer.GetClippedTexture(dev, spritetoClip, striteClipMask, MGCore.MGGameCore.Instance.UseEffects ? clip:null);

            }
            

            // toso move this stuff to each test.. 

            //       shader = Content.Load<Effect>("Invert");



        }



       
        Texture2D clippedTex = null;



        Texture2D spritetoClip;


        Texture2D striteClipMask;
        Effect clip;
        private bool disposedValue;

        public override void Draw(GameTime time, bool useEffects)
        {

            if (disposedValue)
                return;
                    
            //  UInt32[] color = new UInt32[spritetoClip.Width*spritetoClip.Height];
            //    clippedTex.GetData<UInt32>(color);

            //    GraphicsDevice.Clear(Color.Transparent);


            //         BasicEffect var = new BasicEffect(GraphicsDevice);


            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null);


            Rectangle rct = device.Viewport.Bounds;



             spriteBatch.Draw(clippedTex, rct, null, Color.White);
            //no because we really wann just draw whats in the mask , it will skip alpha so it wond work the other way...   
            //sending blend mode sourcealpha might work but this is fine
            spriteBatch.End();






        }

        public void Update(GameTime gt, ContentManager cm)
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    clippedTex.Dispose();

                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue=true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ClipMaskAlphaSpriteRenderTarget()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
           
        
    
}
