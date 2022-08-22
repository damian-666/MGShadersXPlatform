sampler s0;

float _attenuation; // 800.0
float _linesFactor; // 0.04


float4 mainPS(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
	float4 color = tex2D( s0, texCoord );
	float scanline = sin( texCoord.y * _linesFactor ) * _attenuation;
	color.rgb -= scanline;

	return color;
}



technique Scanlines
{
	pass P0
	{
		PixelShader = compile ps_4_0 mainPS();
	}
};
