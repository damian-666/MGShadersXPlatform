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
    public class Fading : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectFading;
        private Vector2 _pos00;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectFading = cm.Load<Effect>("EffectFading");
            _pos00 = new(100, 100);
        }

        public void Draw(GameTime time)
        {
            //todo
            DrawInverted();
        }

        private void DrawInverted()
        {

            spriteBatch.Begin(effect: _effectFading);
            spriteBatch.Draw(texture, _pos00, Color.White);
            spriteBatch.End();

        }
    }

}
