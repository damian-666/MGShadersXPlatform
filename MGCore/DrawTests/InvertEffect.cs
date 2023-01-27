using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class InvertEffect : Effect
{
    public InvertEffect(GraphicsDevice device) : base(device, GenerateShaderCode())
    {
    }

    private static byte[] GenerateShaderCode()
    {
        return new EffectCompiler().Compile(
            new EffectCompilerInput("", "", "", "ps_4_0"),
            new EffectCompilerOutput(EffectCompilerTarget.PixelShader));
    }

    public override void Apply()
    {
        GraphicsDevice.Textures[0] = Texture;

        base.Apply();
    }
}
