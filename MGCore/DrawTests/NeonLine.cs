using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class NeonLine : DrawTestBase
    {




        Vector2 startLine;
        Vector2 endLine;



        Texture2D glowingPixel;


        Texture2D Pixel;

        #region properties
        public float Thickness { get; set; } = 3;
        #endregion

        public override void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            base.Initialize(cm, dev, gm);


            spriteBatch=new SpriteBatch(device);

         //   glowingPixel=cm.Load<Texture2D>("Glow"); //tOdo this is what neon shooer used, why did you do the transparent?????  QUESTIOn

  /// glowingPixel = cm.Load<Texture2D>("Glow");


glowingPixel= cm.Load<Texture2D>("GlowTransparent");  //TODO whats the key core
            
     Pixel=new Texture2D(device, 1, 1);

             Pixel.SetData(new[] { Color.Blue });//why thsi.. i set key color to red... 

       
            startLine=Vector2.Zero;
            endLine=new Vector2(Width, Height);


        }




        public override void   Draw(GameTime time, bool useEffect)
        {
   //      device.SetRenderTarget(null);
            //NOTE i batched this...
            //   Vector2 Offset = new Vector2(20+Thickness, 20+Thickness);
//device.Clear(color: Color.LightCyan);

   Vector2 Offset = new Vector2(20, 20);
            //NOTE this s all used by the partlce.. if we can apply bloom or something ot the line... 

//device.Clear(Color.Azure);
            //not sure what surfave the use or hwat the maek coloor is nt alpa

            //doenst matter...   we do need to add particles..

            //they dont have to be like this.. be nice to unstand it tho..


        //    GraphicsDevice.DiscardColor=Color;  ///TODO what is the key color for..
            //TOD shis shouod be batched as one 
            //Draw a the glow sprite and stretch it across the window
          spriteBatch.Begin( SpriteSortMode.Deferred, blendState: BlendState.NonPremultiplied);
            float alpha = 0.7f;

            Color sideColor = new Color(200, 38, 9);    // deep red
            Color midColor = new Color(255, 187, 30);   // orange-yellow

            midColor.A=(byte)(255*alpha);



            DrawLine(spriteBatch,
                glowingPixel, startLine, endLine,
                sideColor*alpha, Thickness, blendstate: BlendState.NonPremultiplied);


            //spriteBatch.Begin();
            DrawLine(spriteBatch, Pixel, startLine+Offset, endLine+Offset, Color.Blue, 6,blendstate: BlendState.NonPremultiplied);
            spriteBatch.End();

        }

        //DrawLine funcion to take a pixel an strech it from start point to end point and color
        private void DrawLine(SpriteBatch spriteBatch, Texture2D pixelToDraw, Vector2 start, Vector2 end, Color color, float thickness = 1f, BlendState blendstate = null)
        {
            Vector2 delta = end-start;
             spriteBatch.Draw(pixelToDraw, start, null, color, delta.ToAngle(), new Vector2(0, 0.5f), new Vector2(delta.Length(), thickness), SpriteEffects.None, 0f);
        }


    }
}
