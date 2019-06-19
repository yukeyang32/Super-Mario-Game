using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class CollisionDetection
    {
        public static CollisionDirection DetectCollisionDirection(Rectangle collidingObject, Rectangle collidedObject)
        {

            Rectangle overlap = Rectangle.Intersect(collidingObject, collidedObject);
            if (!overlap.IsEmpty)
            {
                if (overlap.Width > overlap.Height && collidingObject.Y < collidedObject.Y)
                {
                    return CollisionDirection.Top;
                }
                if (overlap.Height > overlap.Width && collidingObject.X < collidedObject.X)
                {
                    return CollisionDirection.Left;
                }
                if (overlap.Height > overlap.Width && collidingObject.X > collidedObject.X)
                {
                    return CollisionDirection.Right;
                }
                if (overlap.Width > overlap.Height && collidingObject.Y > collidedObject.Y)
                {
                    return CollisionDirection.Bottom;
                }
            }
            return CollisionDirection.NoCollision;
        }
    }
}
