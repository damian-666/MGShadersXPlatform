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


    
    internal interface IDrawTest
    {
        /// <summary>
        /// load Effects from content set up se devise or render target if needed... 
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="gm"></param>
        void Initialize( GraphicsDevice dev, GraphicsDeviceManager    gm, ContentManager cm);// 
        void Draw(GameTime time);


    }
}
