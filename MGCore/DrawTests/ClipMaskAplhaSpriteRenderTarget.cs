using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MGCore.DrawTests
{
    /// <summary>
    ///  this is the code that use RendertoTextureTarget, i can prolly do this. i the old shader .  it loads one or two textures... and returns a sprite Tueure that has alpha channels intact.. the alpha is eithe draw or not.. it doens't have to blend.   Blending alpha isnt a concern at all its  255 or 0.. its a hole... or nothing for the use case im thinking of.  also consider surfaces with not have full 32 bti rbg not using alpha blend is probably good.   mabye can  clip using key color instead
    /// </summary>
    public class ClipMaskAlphaSpriteRenderTarget : IDrawTest
    {

        SpriteBatch spriteBatch;


        Texture2D clippedTex = null;



        Texture2D spritetoClip;


        Texture2D striteClipMask;

        Effect clip;
        public void Draw(GameTime time)
        {
       
        }

        public void Initialize(GraphicsDevice dev, GraphicsDeviceManager gm, ContentManager cm)
        {

        //TODO   Window.Title+=" Render Target";

            spriteBatch=new SpriteBatch(dev);

            // toso move this stuff to each test.. 

            //       shader = Content.Load<Effect>("Invert");

            spritetoClip=cm.Load<Texture2D>("surge");
            
            clip=cm.Load<Effect>("ClipShader");

            striteClipMask=cm.Load<Texture2D>("surgeclip");
        

    }
}
}
