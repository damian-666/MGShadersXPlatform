/*
// Generalized stuff fronm Mg samp;e neon shooter for shader fx rig , but easier to maintina
//ass a test class and then touch fx file and see if it works on 5 platfroms.... adding the class shold via free reflection add a menu item to the ui
//AS IS..  this is MIT public doman to tst MG fx files in all platorms as just above the level o/a  unit tests.. test on all mobile and pc platfroms with JIT  is the goal.. trimming and AOT is not ye supported   JIT w net 7 can have more potential , consoles not a foucs of these test
// Find the full tutorial at: http://gamedev.tutsplus.com/series/vector-shooter-xna/
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MGCore.DrawTests
{
    static class Extensions
	{
		public static void DrawLine(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float thickness = 2f)
		{
			Vector2 delta = end - start;
			spriteBatch.Draw(CommonAssets.Pixel, start, null, color, delta.ToAngle(), new Vector2(0, 0.5f), new Vector2(delta.Length(), thickness), SpriteEffects.None, 0f);
		}

		public static float ToAngle(this Vector2 vector)
		{
			return (float)Math.Atan2(vector.Y, vector.X);
		}

		public static Vector2 ScaleTo(this Vector2 vector, float length)
		{
			return vector * (length / vector.Length());
		}

		public static Point ToPoint(this Vector2 vector)
		{
			return new Point((int)vector.X, (int)vector.Y);
		}

		public static float NextFloat(this Random rand, float minValue, float maxValue)
		{
			return (float)rand.NextDouble() * (maxValue - minValue) + minValue;
		}

		public static Vector2 NextVector2(this Random rand, float minLength, float maxLength)
		{
			double theta = rand.NextDouble() * 2 * Math.PI;
			float length = rand.NextFloat(minLength, maxLength);
			return new Vector2(length * (float)Math.Cos(theta), length * (float)Math.Sin(theta));
		}
	}
}