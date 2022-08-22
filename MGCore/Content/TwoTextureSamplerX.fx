float4x4 xView;
float4x4 xProjection;

SamplerState TextureSampler { magfilter = LINEAR; minfilter = LINEAR; mipfilter = LINEAR; AddressU = wrap; AddressV = wrap; };
Texture2D xTexture0;
Texture2D xTexture1;

struct VertexShaderInput
{
	float3 Position : POSITION0;
	float2 TextureCoordinate : TEXCOORD0;
	float Type : TEXCOORD1;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float2 TextureCoordinate : TEXCOORD0;
	float Type : TEXCOORD1;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;
	output.Position = mul(mul(float4(input.Position, 1), xView), xProjection);
	output.TextureCoordinate = input.TextureCoordinate;
	output.Type = input.Type;
	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : SV_Target
{
	float4 color = float4(0, 0, 0, 1);
	int textureNo = round(input.Type);
    if (textureNo == 0)
	    color = xTexture0.Sample(TextureSampler, input.TextureCoordinate);
    if (textureNo == 1)
	    color = xTexture1.Sample(TextureSampler, input.TextureCoordinate);
	return color;
}

technique ExRender
{
	pass Pass0
	{
#ifdef SM4
		VertexShader = compile vs_4_0 VertexShaderFunction();
		PixelShader = compile ps_4_0 PixelShaderFunction();
#else
		VertexShader = compile vs_3_0 VertexShaderFunction();
		PixelShader = compile ps_3_0 PixelShaderFunction();
#endif
	}
}