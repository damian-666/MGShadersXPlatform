
#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif
sampler s0;



extern Texture2D ClipTexture;

sampler ClipTextureSampler = sampler_state
{
    Texture = <ClipTexture>;
};



//extern Texture2D DrawTexture;

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


 // float4 color = tex2D(s0, input.TextureCoordinates);


    float4 mask = tex2D(ClipTextureSampler, input.TextureCoordinates);


 float4 color = tex2D(DrawTexSampler, input.TextureCoordinates);
    
  

  if ( all(mask) != all(float4(1, 1, 1, 1)))
  {
    clip(-1);
   }

 


    return color;
}


technique Technique1
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
    
}




 