

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
 
sampler TextureSampler = sampler_state
{
    Texture = <ClipTexture>; 
};
 
Texture2D DrawTexture;

sampler TextureSampler2 = sampler_state
{
    Texture = <DrawTexture>;
};
//this came from a sample from XNA, didnt work..

//Note: Color1 not needed.
float4 PixelShaderFunction(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{

    float4 color = ClipTexture.Sample(TextureSampler, texCoord.xy);

   // float4 color = tex2D(TextureSampler, texCoord.xy);


  if(color.a !=1.0)
  {
      clip(-1);
    
 }
 
 // float4 colorOut = color1;  //notes sample isnt working.. the shader isnt in the piple cause the color isnt the sprite being drawn..
  float4 colorOut=     DrawTexture.Sample(TextureSampler2, texCoord.xy);

 //  float4 colorOut = tex2D(TextureSampler2, texCoord.xy);
   return colorOut;
}
 
    technique technique PassThrough
    {

    {
        pass P0
        {
            PixelShader = compile PS_SHADERMODEL MainPS();
        }

    }
