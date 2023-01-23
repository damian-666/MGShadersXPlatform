#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0
	#define PS_SHADERMODEL ps_4_0
#endif

#define SAMPLES 15

Texture2D SpriteTexture;

sampler2D TextureSampler : register(s0)
{
	Texture = <SpriteTexture>;
};

sampler2D BloomSampler : register(s1)
{
	Texture = <BloomTexture>; //Make sure set value in CS
	filter = Linear;
};

float BloomThreshold;
float2 SampleOffsets[SAMPLES];
float SampleWeights[SAMPLES];

// bloom combine parameters:
float BloomIntensity;
float BaseIntensity;
float BloomSaturation;
float BaseSaturation;

struct VSOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 texCoord : TEXCOORD0;
};

//--------------------------------------------- B L O O M  E X T R A C T O R ---------------------------------------------
float4 BloomExtractor(VSOutput input) : COLOR
{
	float4 c = tex2D(TextureSampler, input.texCoord); 
	return saturate((c - BloomThreshold) / (1 - BloomThreshold)); // Adjust it to keep only values brighter than specified threshold.
};


//--------------------------------------------- G A U S S I A N B L U R  ---------------------------------------------
float4 GaussianBlur(VSOutput input) : COLOR
	{
		float4 c = tex2D(TextureSampler, input.texCoord); // Look up the original image color.
		for (int i = 0; i < SAMPLES; i++)   // Combine a number of surrounding weighted pixel colors to incluence final color (blur it)
		{
			c += tex2D(TextureSampler, input.texCoord + SampleOffsets[i]) * SampleWeights[i];
		}

		return c;
	}


	//Helper for modigying the saturation of a color
	float4 AdjustSaturation(float4 color, float saturation)
	{
		//The constants 0.3, 0.59, and 0.11 are chosen because the human eye is more sensitive to green light and less to blue.
		float grey = dot(color, float3(0.3, 0.59, 0.11));
		return lerp(grey, color, saturation);
	}

	// B L O O M C O M B I N E 
	float4 BloomCombine(VSOutput input) : COLOR0
	{
	//Look up the bloom and original base image colors.
	float4 base = tex2D(TextureSampler, input.texCoord);
	float4 bloom = tex2D(BloomSampler, input.texCoord);

	//Adjust color saturation and intensity.
	base = AdjustSaturation(base, BaseSaturation) * BaseIntensity;
	bloom = AdjustSaturation(bloom, BloomSaturation) * BloomIntensity;

	// Darken down the base image in areas where there is a lot of bloom, to prevent things looking excessively burned/out;
	base *= (1 - saturate(bloom));

	//Combine the two images.
	return base + bloom;

}



//M A I N   P S
float4 MainPS(VSOutput input) : COLOR
{
	return tex2D(TextureSampler, input.texCoord) * input.Color;
};

#define TECHNIQUE(name, psname) technique name {pass { PixelShader = compile PS_SHADERMODEL psname();}}

TECHNIQUE (DefaultTec, MainPS);
TECHNIQUE(BloomExtract, BloomExtractor);
TECHNIQUE (Blur, GaussianBlur);
TECHNIQUE (Combine, BloomCombine);



