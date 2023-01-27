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
        float TotalSeconds;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectGrayscale, _effectFading, _effectPixelated, _effectTeleport, _effectInvert;
        private Vector2 _pos00, _pos01, _pos02, _pos03, _pos04, _pos05;
        private float _amount = 1;
        private float _dir = -1;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectGrayscale = cm.Load<Effect>("EffectGrayscale");
            _effectFading = cm.Load<Effect>("EffectFading");
            _effectPixelated = cm.Load<Effect>("EffectPixelated");
            _effectTeleport = cm.Load<Effect>("EffectTeleport");
            _effectInvert = cm.Load<Effect>("EffectInvert");

         
            _pos00 = new(100, 100);
            _pos01 = new(200, 100);
            _pos02 = new(300, 100);
            _pos03 = new(400, 100);
            _pos04 = new(500, 100);
            _pos05 = new(600, 100);
        }


        public void Update(GameTime gt, ContentManager cm)
        {
            TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
            _amount += TotalSeconds * _dir;
            _effectTeleport.Parameters["amount"].SetValue(_amount);
        }

        public void Draw(GameTime time)
        {
            //todo
            DrawInverted();
        }


        private void DrawInverted()
        {
           
          //Draw default image
            spriteBatch.Begin();
            spriteBatch.Draw(texture, _pos00, Color.White);
            spriteBatch.End();
          //Draw Grayscale image

            spriteBatch.Begin(effect: _effectGrayscale);
            spriteBatch.Draw(texture, _pos01, Color.White);
            spriteBatch.End();

            //Draw a fading image

            spriteBatch.Begin(effect: _effectFading);
            spriteBatch.Draw(texture, _pos02, Color.White);
            spriteBatch.End();

            //Draw a pixelated image

            spriteBatch.Begin(effect: _effectPixelated);
            spriteBatch.Draw(texture, _pos03, Color.White);
            spriteBatch.End();

            //Draw a teleport effect image

            spriteBatch.Begin(effect: _effectTeleport);
            spriteBatch.Draw(texture, _pos04, Color.White);
            spriteBatch.End();

            //Draw an image with colors inverted

            spriteBatch.Begin(effect: _effectInvert);
            spriteBatch.Draw(texture, _pos05, Color.White);
            spriteBatch.End();

        }
    }

}
