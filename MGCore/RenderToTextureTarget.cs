

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MGCore
{

    public class Rasterizer
    {
        public static Texture2D GetClippedTexture(GraphicsDevice gr, Texture2D tex, Texture2D mask, Effect clip)// SpriteBatch spriteBatch)
        {

            var renderTargetViewport = gr.RenderTargetCount == 0 ? null : gr.GetRenderTargets()[0].RenderTarget;


            RenderTarget2D currentRenderTarget;



            Texture2D clippedTex = null;


            var w = tex.Width;
            var h = tex.Height;

            Debug.Assert(w == mask.Width && h == mask.Height); //can use xforms or whatever... if needed on this



            SetNewRenderTarget(gr, w, h, out currentRenderTarget);

            SpriteBatch spriteBatch = new SpriteBatch(gr);  //lests make a new sprite bach just in case something mixes up


            gr.Clear(Color.Transparent);  //this is needed if we discard contents which seems like the simplest way..


            clip.Parameters[0].SetValue(mask);
            clip.Parameters[1].SetValue(tex); ;

            //   spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,null,null,null,null);
            //
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, clip);
            spriteBatch.Draw(mask, Vector2.Zero, Color.Transparent); ;

            //    spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            //no because we really wann just draw whats in the mask , it will skip alpha so it wont work the other way...   
            //sending blend mode sourcealpha might work but this is fine
            spriteBatch.End();



            clippedTex = currentRenderTarget;

            gr.SetRenderTarget(renderTargetViewport as RenderTarget2D);//th TODOus is only needed to keep setting back since.. size we take the size 



            return clippedTex;



            //      SetNewRenderTarget(gr, w, h, out currentRenderTarget);




        }



        private static string GetEffectParamName(string samplerName, string textureName)
        {
            string effectnamebase = "";

            if (!CoreGame.IsDirectX && !string.IsNullOrEmpty(samplerName))  //in open gl samplers and textures are coupled together so names are combined
            {
                effectnamebase = samplerName + "+";
            }


            string effectName = effectnamebase + textureName;
            return effectName;
        }



        private static void SetNewRenderTarget(GraphicsDevice gr, int width, int height, out RenderTarget2D renderTarget)
        {
            //mip maps work this way also.. alspah channel doesnt
            renderTarget = new RenderTarget2D(gr, width, height,
               //     false,


               CoreGame.IsDirectX,  ///use mip maps in dx tho.. in gl for andord stll mg38.1  not working, alos cant  antialialis line w mipmap on


               CoreGame.IsDirectX//    
               ? SurfaceFormat.Bgra32

                :
               SurfaceFormat.Color,//TODO chek


                  DepthFormat.Depth24Stencil8, //TODO check
              //  DepthFormat.None,
           
           0,  //4 or muitpsampe coun stll doesnt work in android, works in desktop Gl tho, 
                RenderTargetUsage.DiscardContents, true); ;
            ;

            gr.SetRenderTarget(renderTarget);
        }
    }
}