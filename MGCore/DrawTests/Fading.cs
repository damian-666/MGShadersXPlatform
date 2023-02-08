using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class Fading : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectFading;
        private Rectangle deskRect;

        GraphicsDevice _device;
        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {

            texture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(dev);
            _effectFading=cm.Load<Effect>("Fading");

            _device=dev;
            deskRect=DrawTestBase.SetTargetToRenderSize(_device);
        }

        public void Draw(GameTime time)
        {
            //Draw a fading sprite
            deskRect=DrawTestBase.SetTargetToRenderSize(_device);
            spriteBatch.Begin(effect: _effectFading);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

    }

}
