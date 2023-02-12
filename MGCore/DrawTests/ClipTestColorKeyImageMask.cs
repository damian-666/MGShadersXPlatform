using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace MGCore.DrawTests
{
    /// <summary>
    /// draw using clip mask  wiht key color
    /// </summary>
    public class ClipMaskDirect : DrawTestBase
    {
        public override void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm = null)
        {
            base.Initialize(cm, dev, gm);
            spriteBatch=new SpriteBatch(device);
            //TODO load the effect
            //TODO load the textures

                spritetoClip=cm.Load<Texture2D>("surge");//tdoo use sometihng elese

            clip=cm.Load<Effect>("ClipShaderNew");
            //todo put a dksik make with key red or comseth else
            striteClipMask=cm.Load<Texture2D>("surgeclip");

            clip.Parameters["Mask"].SetValue(striteClipMask);
            spriteBatch=new SpriteBatch(dev);

  


            // toso move this stuff to each test.. 

            //       shader = Content.Load<Effect>("Invert");



        }




 
        Texture2D spritetoClip;


        Texture2D striteClipMask;
        Effect clip;
        public override void Draw(GameTime time)
        {

            //  UInt32[] color = new UInt32[spritetoClip.Width*spritetoClip.Height];
            //    clippedTex.GetData<UInt32>(color);

                device.Clear(Color.Beige);


            //         BasicEffect var = new BasicEffect(GraphicsDevice);


            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, effect:clip);


            Rectangle rct = device.Viewport.Bounds;



            spriteBatch.Draw(spritetoClip, rct, null, Color.White);
            //no because we really wann just draw whats in the mask , it will skip alpha so it wond work the other way...   
            //sending blend mode sourcealpha might work but this is fine
            spriteBatch.End();


#if NORENDERTARG
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

        public void Update(GameTime gt, ContentManager cm)
        {

        }
    }
}
