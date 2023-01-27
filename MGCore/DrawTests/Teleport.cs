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
    public class Teleport : IDrawTest
    {
        float TotalSeconds;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect  _effectTeleport;
        private Vector2 _pos00;
        private float _amount = 1;
        private float _dir = -1;

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            texture = cm.Load<Texture2D>("orb-red");
            spriteBatch = new SpriteBatch(dev);
            _effectTeleport = cm.Load<Effect>("EffectTeleport");
           

            _pos00 = new(100, 100);
          
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


            //Draw a teleport effect image

            spriteBatch.Begin(effect: _effectTeleport);
            spriteBatch.Draw(texture, _pos00, Color.White);
            spriteBatch.End();

        }
    }

}
