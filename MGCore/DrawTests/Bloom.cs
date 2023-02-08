using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    /// <summary>
    /// A test put the glowing bloom effect on a sprite
    /// </summary>
    public class Bloom : DrawTestBase
    {
        Texture2D _drawtexture;
        Effect _effectGlow;



        public override void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {
            base.Initialize(cm, dev, gm);

            spriteBatch=new SpriteBatch(device);
            _drawtexture=cm.Load<Texture2D>("orb-red");
            spriteBatch=new SpriteBatch(device);
            _effectGlow=cm.Load<Effect>("Bloom");

            _effectGlow=cm.Load<Effect>("Bloom");

            _effectGlow.Parameters["GlowIntensity"].SetValue(1f);
            _effectGlow.Parameters["GlowSize"].SetValue(0.05f);

        }

        public override void OnResize(EventArgs e)
        {
            base.OnResize(e); //todo soemthing with deskreck...ill help with this 
        }

        public override void Draw(GameTime time)
        {
            device.SetRenderTarget(null);
            spriteBatch.Begin(effect: _effectGlow);
            spriteBatch.Draw(_drawtexture, deskRect, Color.White);
            spriteBatch.End();
        }



    }
}