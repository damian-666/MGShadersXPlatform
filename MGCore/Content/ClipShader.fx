#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif


Texture2D mask : register(t2);

//Texture2D ClipTexture;

sampler maskSampler = sampler_state
{
    Texture = <mask>;
};
 

SamplerState screen : register(s0);

//SamplerState sampler1 : register(s2);

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};


float4 MainPS(VertexShaderOutput input) : COLOR0
{
    float4 color = tex2D(screen, input.TextureCoordinates);
    


  //  float4 colorM = mask.Sample(sampler1, input.TextureCoordinates);
    
    float4 colorM = mask.Sample(maskSampler, input.TextureCoordinates);
  
  //  float4 colorM = tex2D(maskSampler, input.TextureCoordinates);
    
	// test code just to see if I can display both textures.
   //return float4(colorM.rg, colorM.b, 1);

   // return color;  //both these test check out on gl and dx.
   // return colorM;
    
  // if (all(colorM)) //there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times
 //   if (color.argb == 0)//there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times
  
     //if (colorM.b ==1) //there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times
      //  if (all(colorM) == all(float4(1, 1, 1, 1))) //there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times
    //if (colorM.r   == float1(1)) //there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times  
 //   if (all(colorM) == float4(1, 1, 1, 1))//there are  built in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.  the samples are from XNA times
        if (all(colorM) == all(float4(0, 0, 1, 1)))
    
        {
        return color; //use anything as a mask..
    }
    else
    {

   //return float4(1, 0, 1, 0.7);  //this is for testing touch in the  fx by uncommenting this, and build,  works on dx and gl.. and adroid.. you will see a different result.  blending is still tricky.    but holes are ok and 100% parallel.  this effectively creates a single tranparent texture like a PNG at runtime.     the background will show though the channel and anthing drawn before.
   
            
        return float4(1, 0, 0, 1); //    transparent.     
   //     return float4(1, 0, 0, 1); //    transparent.     
    }

}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};



 