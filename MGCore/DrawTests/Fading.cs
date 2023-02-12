using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class Fading : IDrawTest,IDisposable
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectFading;
        private Rectangle deskRect;

        GraphicsDevice _device;
        private bool disposedValue;

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
            
            _device.Clear(Color.Bisque);

            if (disposedValue) return;
     
            //Draw a fading sprite
           DrawTestBase.SetTargetToRenderSize(_device);
            spriteBatch.Begin(effect: MGGameCore.Instance.UseEffects ? _effectFading : null); 
            spriteBatch.Draw(texture, deskRect, Color.White);
            spriteBatch.End(); 
        }

        protected virtual void Dispose(bool disposing)
        {
             if (!disposedValue)
            {
                if (disposing)
                {

                    this._effectFading.Dispose();
                    
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue=true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Fading()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
