using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MGCore.DrawTests
{



    public class BloomRT: IDrawTest
    {

        int width = 800;
        int height = 600;
        public void Initialize(ContentManager cm, GraphicsDevice dev, GraphicsDeviceManager gm)
        {


               gpu=dev;
         

            BloomThreshold=0.25f;
            BlurAmount=4;
            BloomIntensity=2;
            BaseIntensity=1f;
            BloomSaturation=1;
            BaseSaturation=1;    
            PresentationParameters pp = gpu.PresentationParameters;
       
            SurfaceFormat format = pp.BackBufferFormat;
               sourceimage=cm.Load<Texture2D>("orb-red");
            glow_fx=cm.Load<Effect>("BloomCombine");

            spriteBatch=new SpriteBatch(gpu);

            //Create 2 rendertargets for bloom processing, there are half size of backbuffer in order to minimize fillrate costs
            //Reducing the solution this way doesn't hurt the quality becausewe will be blur the images anyway.
            width/=2;
            height/=2;

            renderTarget1=new RenderTarget2D(gpu, width, height, false, format, DepthFormat.None);
            renderTarget2=new RenderTarget2D(gpu, width, height, false, format, DepthFormat.None);




            BloomThreshold=0.25f;
            BlurAmount=4;
            BloomIntensity=2;
            BaseIntensity=1f;
            BloomSaturation=1;
            BaseSaturation=1;


        }

        GraphicsDevice gpu;
       
        Effect glow_fx;

        SpriteBatch spriteBatch;
        RenderTarget2D renderTarget1;
        RenderTarget2D renderTarget2;

        public float BloomThreshold; //Brightness of pixel needed. 0 blooms all equally. High values = brighter colors 0.25 & 0.5 are good
        public float BlurAmount;    // Controls the blur amount applied to bloom image. Range is about 1 to 10.
        public float BloomIntensity; //Amount of bloom mixed into the final scene. Range 0 to 1.
        public float BaseIntensity; //Amount of base mixed into the final scene. Range 0 to 1.
        public float BloomSaturation; //Color saturation of bloom image (0 = desaturated [ie: gray], 1 normal, higher value = boost color
        public float BaseSaturation; //Color saturation of base image (0 = desaturated [ie: gray], 1 normal, higher value = boost color



        public void UnloadContent()
        {
            renderTarget1.Dispose();
            renderTarget2.Dispose();
        }

        Texture2D sourceimage;

    public  void
            Draw(GameTime time)
    {

            DrawFullScreenQuad(sourceimage, width, height);
    }



        // D R A W
        // ( you can pass a RenderTargetr layer into a "Source" also )
        public void Draw(Texture2D source, RenderTarget2D destRT)
        {
            //Draw Brighest Parts
            glow_fx.CurrentTechnique=glow_fx.Techniques["BloomExtract"];
            glow_fx.Parameters["BloomThreshold"].SetValue(BloomThreshold);
            DrawToTarget(renderTarget1, renderTarget2);

            //HORIZONTAL BLUR
            glow_fx.CurrentTechnique=glow_fx.Techniques["Blur"];
            SetBlurEffectParameters(1.0f/(float)renderTarget1.Width, 0);
            DrawToTarget(renderTarget2, renderTarget1);

            //VERTICAL BLUR
            SetBlurEffectParameters(1.0f/(float)renderTarget1.Height, 0);
            DrawToTarget(renderTarget2, renderTarget1);

            //COMBINE RESULTS
            gpu.SetRenderTarget(destRT);
            glow_fx.CurrentTechnique=glow_fx.Techniques["Combine"];
            glow_fx.Parameters["BloomIntensity"].SetValue(BloomIntensity);
            glow_fx.Parameters["BaseIntensity"].SetValue(BaseIntensity);
            glow_fx.Parameters["BloomSaturation"].SetValue(BloomSaturation);
            glow_fx.Parameters["BaseSaturation"].SetValue(BaseSaturation);
            glow_fx.Parameters["BloomTexture"].SetValue(renderTarget1);
            Viewport viewPort = gpu.Viewport;
            DrawFullScreenQuad(source, viewPort.Width, viewPort.Height); // now desRT is renderer an dready to be used.

        }

        //DRAW FULL SCREEN QUAD 1
        void DrawToTarget(Texture2D texture, RenderTarget2D renderTarget)
        {
            gpu.SetRenderTarget(renderTarget);
            DrawFullScreenQuad(texture, renderTarget.Width, renderTarget.Height);
        }

        //DRAW FULL SCREEN QUAD 2
        void DrawFullScreenQuad(Texture2D texture, int width, int height)
        {
            gpu.Clear(Color.Transparent); // <-- Must do this for each target if using transparent target.
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,  effect :glow_fx);
            spriteBatch.Draw(texture, new Rectangle(0, 0, width, height), Color.White);
            spriteBatch.End();
        }

        //SET BLUT EFFECT PARAMETERS
        void SetBlurEffectParameters(float dx, float dy)
        {
            EffectParameter weightsParameter, offsetParameter;
            weightsParameter = glow_fx.Parameters["SampleWeights"]; // Look up the sample weight and offset effect parameters
            offsetParameter = glow_fx.Parameters["SampleOffsets"];
            int sampleCount = weightsParameter.Elements.Count; //Look up how many samples the (blur) effect supports

            float[] sampleWeights = new float[sampleCount];     // Temporary arrays for computing filter settings
            Vector2[] sampleOffsets = new Vector2[sampleCount];

            sampleWeights[0] = ComputeGaussian(0); // First sample alwasy has zero offset
            sampleOffsets[0] = new Vector2(0);

            float totalWeights = sampleWeights[0]; // Maintain a sum of all weighting values

            // Add pairs of additional sample taps, positioned along a line in both directions from the center.
            for (int i = 0; i < sampleCount / 2; i++)
            {
                float weight = ComputeGaussian(i + 1); //Store weights for positive and negative taps
                sampleWeights[i * 2 + 1] = weight;
                sampleWeights[i * 2 + 2] = weight;
                totalWeights += weight * 2;
    #region explanation_comment
                //To get the maximun amount  of blurring from a lmited number of pixel shader samples, we take advantage of the bilinear filtering
                //hardware inside the texture fetch unit. If we position out texture coordinates exactly halfway between two textels, the filtering unit
                // will average them for us, giving two samples for the price of one. This allos us to step in units of two textels per sample, rather
                //that just one  at a time. The 1.5 offset kicks thingsoff by positioning us nicely between to textels.
    #endregion

                float sampOffset = i * 2 + 1.5f;

                Vector2 delta = new Vector2(dx, dy) * sampOffset;

                sampleOffsets[i * 2 + 1] = delta; // Store texture coordinate offsets for the possitive and negative taps.
                sampleOffsets[i * 2 + 2] = -delta;

            }

            //Normalize the list of sample weightings, so they will always sum to one.
            for (int i = 0; i < sampleWeights.Length; i++)
            {
                sampleWeights[i] /= totalWeights;
            }

            weightsParameter.SetValue(sampleWeights); //  Tell the effect about or new filter settings.
            offsetParameter.SetValue(sampleOffsets);
        }


        float ComputeGaussian(float n)
        {
            float theta = BlurAmount;
            return (float)((1.0 / Math.Sqrt(2 * Math.PI * theta)) * Math.Exp(-(n * n) / (2 / theta * theta)));
        }

   
    }

}

