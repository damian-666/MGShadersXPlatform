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
    public class Invert : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect  _effectInvert;
        private Rectangle deskRect;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectInvert = cm.Load<Effect>("Invert");
            deskRect.Width = 500;
            deskRect.Height = 500;
        }

        public void Draw(GameTime time)
        {
            //Draw an image with colors inverted

            spriteBatch.Begin(effect: _effectInvert);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

      
    }

}
