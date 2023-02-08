using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    public class Pixelated : IDrawTest
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        Effect _effectPixelated;
        protected Rectangle deskRect;

        GraphicsDevice _device;


        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {

            texture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(dev);
            _effectPixelated=cm.Load<Effect>("Pixelated");
            _device=dev;
            deskRect=DrawTestBase.SetTargetToRenderSize(dev);
        }



        public void Draw(GameTime time)
        {

            //       _device.Clear(ClearOptions.Target, Color.BlanchedAlmond, 0, 0);//what are this options?

            //what is stencil and target and such?

            _device.Clear(Color.Aqua);
            ///        if (_device.GraphicsDeviceStatus!=GraphicsDeviceStatus.Normal)
            //         return;


            //Draw a pixelated image
            deskRect=DrawTestBase.SetTargetToRenderSize(_device);

            //       GraphicsDevice.DiscardColor=Color.Aqua;// TODO  what is this for


            spriteBatch.Begin( /*samplerState:  SamplerState.PointClamp,*/  effect: _effectPixelated);//TDODO why dont i have to point clamp.. i guess shader takes care of it..

            ///       otherwise when resampled or stretched require that..

            spriteBatch.Draw(texture, deskRect, Color.White);  //TOO what does tis color do?
            spriteBatch.End();
        }

    }

}
