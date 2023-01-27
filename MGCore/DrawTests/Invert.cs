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
        private Vector2 _pos00;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectInvert = cm.Load<Effect>("EffectInvert");
            _pos00 = new(100, 100);
        }

        public void Draw(GameTime time)
        {
            //todo
            DrawInverted();
        }


        private void DrawInverted()
        {
          
            //Draw an image with colors inverted

            spriteBatch.Begin(effect: _effectInvert);
            spriteBatch.Draw(texture, _pos00, Color.White);
            spriteBatch.End();

        }
    }

}
