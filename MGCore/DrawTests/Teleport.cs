using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class Teleport : IDrawTest
    {
        float TotalSeconds;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectTeleport;
        private Rectangle deskRect;
        private float _amount = 1;
        private float _dir = -1;

        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            texture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(dev);
            _effectTeleport=cm.Load<Effect>("Teleport");


            deskRect.Width=500;
            deskRect.Height=500;

        }


        public void Update(GameTime gt, ContentManager cm)
        {
            TotalSeconds=(float)gt.ElapsedGameTime.TotalSeconds;
            _amount+=TotalSeconds*_dir;
            _effectTeleport.Parameters["amount"].SetValue(_amount);
        }

        public void Draw(GameTime time)
        {
            //Draw a teleport effect image (Need the Update method to be run)

            spriteBatch.Begin(effect: _effectTeleport);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

    }

}
