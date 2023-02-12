using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGCore.DrawTests
{
    public class Invert : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectInvert;
        private Rectangle deskRect;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            texture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(dev);
            _effectInvert=cm.Load<Effect>("Invert");
            deskRect.Width=500;
            deskRect.Height=500;
        }


      
        public void Draw(GameTime time)
        {
            //Draw an image with colors inverted

            spriteBatch.Begin(effect: GraphicsTestRig.Instance.UseEffects ? _effectInvert : null, blendState: BlendState.NonPremultiplied);
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End();
        }
        
        public void Update(GameTime gameTime)
        {
          
        }
    }

}
