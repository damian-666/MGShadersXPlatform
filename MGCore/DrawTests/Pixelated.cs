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
    public class Pixelated : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectPixelated;
        private Rectangle deskRect;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectPixelated = cm.Load<Effect>("Pixelated");
            deskRect.Width = 500;
            deskRect.Height = 500;
        }
      
        public void Draw(GameTime time)
        {
            //Draw a pixelated image

            spriteBatch.Begin(effect: _effectPixelated);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

    }

}
