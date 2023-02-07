using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MGCore.DrawTests
{
    /// <summary>
    /// A test put the glowing bloom effect on a sprite
    /// </summary>
    public class Bloom : IDrawTest
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectGlow;
        private Rectangle deskRect;


        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            graphics = gm;

            graphics.PreferredDepthStencilFormat = DepthFormat.None;
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
            graphicsDevice = dev;
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectGlow = cm.Load<Effect>("Bloom");
            deskRect.Width = 500;
            deskRect.Height = 500;

            _effectGlow.Parameters["GlowIntensity"].SetValue(1f);
            _effectGlow.Parameters["GlowSize"].SetValue(0.05f);

        }

        public void Draw(GameTime time)
        {
            graphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(effect: _effectGlow);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

       

    }
}