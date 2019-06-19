using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using static Sprint0.CollisionDetection;

namespace Sprint0
{
    internal static class MarioLuigiCollisionHandler
    {
        public static void HandleCollision(Mario player1, Mario player2)
        {
            Rectangle player1Rectangle = player1.GetSizeRectangle();
            Rectangle player2Rectangle = player2.GetSizeRectangle();
            CollisionDirection direction = DetectCollisionDirection(player1Rectangle, player2Rectangle);
            if (!(direction is CollisionDirection.NoCollision))
            {
                if (direction is CollisionDirection.Top)
                {
                    player2.GetInjured();
                    player1.Bounce();
                }
                else if (direction is CollisionDirection.Left)
                {
                    player1.Position = new Vector2(player2.GetSizeRectangle().X - player1.GetSizeRectangle().Width, player1.Position.Y);
                }
                else if (direction is CollisionDirection.Right)
                {
                    player1.Position = new Vector2(player2.GetSizeRectangle().X + player1.GetSizeRectangle().Width, player1.Position.Y);
                }
            }
        }
    }
}
