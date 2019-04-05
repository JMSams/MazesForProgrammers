using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers
{
    public static class ExtensionMethods
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color colour, int width = 1)
        {
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(spriteBatch.CreatePixel(), r, null, colour, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

        public static Texture2D CreatePixel(this SpriteBatch spriteBatch)
        {
            Texture2D tex = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            tex.SetData(new Color[] { Color.White });
            return tex;
        }

        public static void DrawPolyLine(this SpriteBatch spriteBatch, Vector2[] points, Color color, int width = 1, bool closed = false)
        {
            for (int i = 0; i < points.Length - 1; i++)
                spriteBatch.DrawLine(points[i], points[i + 1], color, width);
            if (closed)
                spriteBatch.DrawLine(points[points.Length - 1], points[0], color, width);
        }
    }
}
