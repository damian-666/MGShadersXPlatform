using MGCore.DrawTests;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore
{
    public abstract class DrawTestBase : IDrawTest
    {
        protected Rectangle deskRect;
        protected GraphicsDeviceManager gm;
        protected GraphicsDevice device;
        protected SpriteBatch spriteBatch;

        /// <summary>
        /// the width of the window adn defualt surface in pixels,, TODO shold be resizeable, 
        /// </summary>

        public int Width { get; set; } = 500;
        /// <summary>
        ///  / the height of the window adn defualt surface in pixels, TODO shold be resizeable, 
        /// </summary>
        public int Height { get; set; } = 500;

        public bool UseEffects => GraphicsTestRig.Instance.UseEffects;

        public virtual void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)//todo i think remvie the Graphicsdevice and let the gm make one.
        {
            this.gm=gm;


            if (dev!=null)
            {
                device=dev;
            }
            else
            {
                gm.PreferredDepthStencilFormat=DepthFormat.None;
                gm.PreferredBackBufferWidth=Width;
                this.gm.PreferredBackBufferHeight=Height;
                this.gm.ApplyChanges();

                device=gm.GraphicsDevice;

             
            }

            deskRect=SetTargetToRenderSize(gm);


        }

        public virtual void OnResize(EventArgs e)
        {


            //TODO this is probably the same for most
        }

        public virtual void Update(GameTime time)
        {

        }

        public static Rectangle SetTargetToRenderSize(GraphicsDeviceManager gm)
        {
            return new Rectangle(0, 0, gm.PreferredBackBufferWidth, gm.PreferredBackBufferHeight);
        }


        public static Rectangle SetTargetToRenderSize(GraphicsDevice dev)
        {
            return new Rectangle(0, 0, dev.Viewport.Width, dev.Viewport.Height);
        }

        public void Draw(GameTime gt)
        {
            Draw(gt, UseEffects);
        }
        public abstract void Draw(GameTime time, bool useEffect = true);





    }
}