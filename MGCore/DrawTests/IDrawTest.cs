using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{


    /// <summary>
    /// A test that inverts the colors in the spite
    /// </summary>
    public interface IDrawTest
    {
        /// <summary>
        /// load Effects from content set up se devise or render target if needed... 
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="gm"></param>
        void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm = null);// 
        void Draw(GameTime time);
        virtual void  Update(GameTime time) {  }
        virtual void OnResize(EventArgs e) { }
        virtual bool BlockDraw { get => false; set { } }
        virtual void Unload() { }
   
        }
}
