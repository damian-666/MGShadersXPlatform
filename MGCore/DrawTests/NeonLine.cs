using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCore.DrawTests
{
    public class NeonLine : IDrawTest
    {

        GraphicsDeviceManager graphics;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        Vector2 startLine;
        Vector2 endLine;
        float _thickness;
        Texture2D glowingPixel;
        

        Texture2D Pixel;

       
        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            graphics = gm;

            graphics.PreferredDepthStencilFormat = DepthFormat.None;
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
            graphicsDevice = dev;
            spriteBatch = new SpriteBatch(dev);

            glowingPixel = cm.Load<Texture2D>("GlowTransparent");
            Pixel = new Texture2D(dev, 1,1);
            Pixel.SetData(new[] { Color.Magenta });

            startLine = new Vector2(0, 500);
            endLine = new Vector2(500, 00);
            _thickness = 1f;

        }
        public void Draw(GameTime time)
        {
            Vector2 Offset = new Vector2(20, 20);
            //Draw a the glow sprite and stretch it across the window
            spriteBatch.Begin(); 
            DrawLine(spriteBatch,glowingPixel, startLine, endLine, Color.Magenta, _thickness);
            spriteBatch.End();

            //Draw a pixel line slightly down to avoid overlap
            spriteBatch.Begin();
            DrawLine(spriteBatch,Pixel, startLine + Offset, endLine + Offset, Color.Blue);
            spriteBatch.End();
            
        }

        //DrawLine funcion to take a pixel an strech it from start point to end point and color
        private void DrawLine(SpriteBatch spriteBatch,Texture2D pixelToDraw, Vector2 start, Vector2 end, Color color, float thickness = 1f)
        {
            Vector2 delta = end - start;
            spriteBatch.Draw(pixelToDraw, start, null, color, delta.ToAngle(), new Vector2(0, 0.5f), new Vector2(delta.Length(), thickness), SpriteEffects.None, 0f);
        }
        

    }
}
