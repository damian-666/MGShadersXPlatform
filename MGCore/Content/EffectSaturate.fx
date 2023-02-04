#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0
#define PS_SHADERMODEL ps_4_0
#endif

#define SAMPLES 15
#define BLOOM_THRESHOLD 0.25
#define BLOOM_INTENSITY 2.0
#define BLOOM_SATURATION 0.8

float4 BloomThreshold;
float BloomIntensity;
float BloomSaturation;

sampler TextureSampler : register(s0);

float4 BloomPass(float2 texCoord : TEXCOORD) : COLOR
{
    float4 color = tex2D(TextureSampler, texCoord);
    color = saturate(color - BloomThreshold) * BloomIntensity + color;
    color = saturate(color);
    color = lerp(color, color.rgba + color.rgba * BloomSaturation, BloomSaturation);
    return color;
}



technique Bloom
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 BloomPass();
    }

}
