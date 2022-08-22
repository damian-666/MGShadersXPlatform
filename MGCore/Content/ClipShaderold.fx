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
 
technique PassThrough
{
    pass Pass1
    {

#ifdef SM4
        PixelShader = compile ps_4_0 PixelShaderFunction();
#else

        PixelShader = compile ps_3_0 PixelShaderFunction();
#endif
    }
}