
#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif
sampler s0;


Texture2D ClipTexture;

sampler ClipTextureSampler = sampler_state
{
    Texture = <ClipTexture>;
};



Texture2D DrawTexture;

sampler DrawTexSampler = sampler_state
{
    Texture = <DrawTexture>;
};



struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};


float4 MainPS(VertexShaderOutput input) : COLOR
{


 // float4 color = tex2D(s0, input.TextureCoordinates);t   //didnt work on al platfroms, REVISIT

    float4 mask = tex2D(ClipTextureSampler, input.TextureCoordinates);

    float4 color = tex2D(DrawTexSampler, input.TextureCoordinates);
    

  if ( all(mask) == all(float4(1, 1, 1, 1))) //there are  build in stencis, and other clipping stuff in Basic effect but I couldnt get them to work.
  {
   return color;
  }
  else {

    //  return float4(1, 0, .1f, 0.7);  //thus is for testing touch fx and buid  works on dx and gl.. had to add it as embedded resouce, the one fx file to work with it.. not sure if this bloats package or what
      return float4(0, 0, 0, 0);
  }

 
  
}


technique Technique1
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
    
}




 