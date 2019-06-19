using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class PipeSpriteFactory
    {
        private Texture2D pipeSpritesheet;

        static private PipeSpriteFactory instance = new PipeSpriteFactory();

        public static PipeSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PipeSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            pipeSpritesheet = content.Load<Texture2D>("pipe");
        }

        public ISprite CreatePipe()
        {
            return new StaticMarioBlockPipeSprite(ConstantNumber.PIPE_HEIGHT, ConstantNumber.PIPE_WIDTH,pipeSpritesheet, new Rectangle(0, 0, ConstantNumber.PIPE_HEIGHT, ConstantNumber.PIPE_WIDTH));
        }

    }
}
