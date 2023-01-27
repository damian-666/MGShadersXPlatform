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
        Effect _testEffect, _testEffect2, _testEffect3, _testEffect4, _testEffect5;
        private Vector2 _pos00, _pos01, _pos02, _pos03, _pos04, _pos05;
        private float _amount = 1;
        private float _dir = -1;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _testEffect = cm.Load<Effect>("TestEffect");
            _testEffect2 = cm.Load<Effect>("TestEffect2");
            _testEffect3 = cm.Load<Effect>("TestEffect3");
            _testEffect4 = cm.Load<Effect>("TestEffect4");
            _testEffect5 = cm.Load<Effect>("TestEffect5");

         
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
            _testEffect4.Parameters["amount"].SetValue(_amount);
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

            spriteBatch.Begin(effect: _testEffect);
            spriteBatch.Draw(texture, _pos01, Color.White);
            spriteBatch.End();

            //Draw a fading image

            spriteBatch.Begin(effect: _testEffect2);
            spriteBatch.Draw(texture, _pos02, Color.White);
            spriteBatch.End();

            //Draw a pixelated image

            spriteBatch.Begin(effect: _testEffect3);
            spriteBatch.Draw(texture, _pos03, Color.White);
            spriteBatch.End();

            //Draw a teleport effect image

            spriteBatch.Begin(effect: _testEffect4);
            spriteBatch.Draw(texture, _pos04, Color.White);
            spriteBatch.End();

            //Draw an image with colors inverted

            spriteBatch.Begin(effect: _testEffect5);
            spriteBatch.Draw(texture, _pos05, Color.White);
            spriteBatch.End();

        }
    }

}
