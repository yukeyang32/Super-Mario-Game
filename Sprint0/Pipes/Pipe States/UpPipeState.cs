using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal class UpPipeState : IPipeState
    {
        private Pipe pipe;
        private ISprite pipeSprite;

        public UpPipeState(Pipe pipe)
        {
            this.pipe = pipe;
            pipeSprite = PipeSpriteFactory.Instance.CreatePipe();
        }


        public void Update()
        {
            pipeSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            pipeSprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetSizeRectangle()
        {
            return new Rectangle((int)pipe.position.X, (int)pipe.position.Y, ConstantNumber.PIPE_WIDTH, ConstantNumber.PIPE_HEIGHT);
        }

    }
}