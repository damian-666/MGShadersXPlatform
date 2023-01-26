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
    public class Invert : IDrawTest
    {
        Effect invert;
        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {
            invert=cm.Load<Effect>("Invert");
        }





        public void Draw(GameTime time)
        {
            //todo
        }

    }
    
}
