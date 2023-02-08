/*
// Generalized stuff fronm Mg samp;e neon shooter for shader fx rig , but easier to maintina
//ass a test class and then touch fx file and see if it works on 5 platfroms.... adding the class shold via free reflection add a menu item to the ui
//AS IS..  this is MIT public doman to tst MG fx files in all platorms as just above the leve o/a  unit tests.. test on all mobile and pc tarforms with JIT  is the goal.. trimming and AOT is not ye supported
// Find the full tutorial at: http://gamedev.tutsplus.com/series/vector-shooter-xna/
*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{
    static public class CommonAssets
    {

        public static Texture2D Pointer { get; private set; }

        public static Texture2D LineParticle { get; private set; }
        public static Texture2D Glow { get; private set; }
        public static Texture2D Pixel { get; private set; }     // a single white pixel

        public static SpriteFont Font { get; private set; }

        public static void Load(ContentManager content, GraphicsDevice gr)
        {


            Pointer=content.Load<Texture2D>("Pointer");


            LineParticle=content.Load<Texture2D>("Laser");
            Glow=content.Load<Texture2D>("Glow");

            Pixel.SetData(new[] { Color.White });

            Font=content.Load<SpriteFont>("Font");
        }

    }
}