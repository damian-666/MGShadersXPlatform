#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

#define SAMPLES 15
#define BLOOM_THRESHOLD 0.25
#define BLOOM_INTENSITY 2.0
#define BLOOM_SATURATION 0.8

SamplerState TextureSampler
{
    magfilter = LINEAR;
    minfilter = LINEAR;
    mipfilter = LINEAR;
    AddressU = clamp;
    AddressV = clamp;
};
Texture2D  Texture;

sampler2D BloomSampler : register(s0);
float GlowIntensity;
float GlowSize;

float4 main(  float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(BloomSampler , uv);

    float4 sum = 0;
    int samples  = 5;
    float delta = GlowSize / samples;
    float intensity = GlowIntensity / samples;
    for (int i = 0; i < samples; i++)
    {
        sum += Texture.Sample(  TextureSampler,   uv + float2(delta * i, 0)) * intensity;
        sum += Texture.Sample(TextureSampler, uv - float2(delta * i, 0)) * intensity;
        sum += Texture.Sample(TextureSampler, uv + float2(0, delta * i)) * intensity;
        sum += Texture.Sample(TextureSampler , uv - float2(0, delta * i)) * intensity;
    }

    return color + sum * GlowIntensity;
   
}

technique Glow
{
    pass Pass1
    {
        PixelShader = compile PS_SHADERMODEL main();
    }
}