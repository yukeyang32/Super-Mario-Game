using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class FlagPole : IItem
    {
        public Boolean Destroyed { get; set; } = false;
        public Vector2 position;
        public IItemState state;
        public int flagFallTime;

        public FlagPole(Vector2 pos)
        {
            position = pos;
            state = new StandingFlagPoleState(this);
            flagFallTime = ConstantNumber.FLAG_FALLING_TIME;
        }

        public void GetTrigger()
        {
            state.GetTrigger();
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            state.Draw(spriteBatch,position);
        }

        public Rectangle GetSizeRectangle()
        {
            return state.GetSizeRectangle();
        }

        public void Disappear()
        {
            this.Destroyed = true;
        }
    }
}