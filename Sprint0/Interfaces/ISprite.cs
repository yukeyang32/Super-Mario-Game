using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    internal interface ISprite
    {
        Texture2D Texture { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);

        
    }
}