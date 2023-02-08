using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class GrayScale : IDrawTest
    {
        float TotalSeconds;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectGrayscale;
        private Rectangle deskRect;

        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            texture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(dev);
            _effectGrayscale=cm.Load<Effect>("Grayscale");
            deskRect.Width=500;
            deskRect.Height=500;
        }

        public void Draw(GameTime time)
        {
            //Draw Grayscale image

            spriteBatch.Begin(effect: _effectGrayscale);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }

    }

}
