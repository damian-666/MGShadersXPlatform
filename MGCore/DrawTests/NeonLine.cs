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
        public float Thickness { get; set; } = 2;
        #endregion

        public override void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            base.Initialize(cm, dev, gm);


            spriteBatch=new SpriteBatch(device);

         //   glowingPixel=cm.Load<Texture2D>("Glow"); //tOdo this is what neon shooer used, why did you do the transparent?????  QUESTIOn

   glowingPixel = cm.Load<Texture2D>("GlowTransparent");
            Pixel=new Texture2D(device, 1, 1);
            Pixel.SetData(new[] { Color.Magenta });

            startLine=Vector2.Zero;
            endLine=new Vector2(Width, Height);


        }




        public override void Draw(GameTime time)
        {

//NOTE i batched this...
         //   Vector2 Offset = new Vector2(20+Thickness, 20+Thickness);


   Vector2 Offset = new Vector2(20, 20);
            //Draw a the glow sprite and stretch it across the window
            spriteBatch.Begin();
            DrawLine(spriteBatch, glowingPixel, startLine, endLine, Color.Magenta, Thickness);
          
            //Draw a pixel line slightly down to avoid overlap
          
            DrawLine(spriteBatch, Pixel, startLine+Offset, endLine+Offset, Color.Blue);
            spriteBatch.End();

        }

        //DrawLine funcion to take a pixel an strech it from start point to end point and color
        private void DrawLine(SpriteBatch spriteBatch, Texture2D pixelToDraw, Vector2 start, Vector2 end, Color color, float thickness = 1f)
        {
            Vector2 delta = end-start;
            spriteBatch.Draw(pixelToDraw, start, null, color, delta.ToAngle(), new Vector2(0, 0.5f), new Vector2(delta.Length(), thickness), SpriteEffects.None, 0f);
        }


    }
}
