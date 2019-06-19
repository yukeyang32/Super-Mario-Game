using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    internal interface IController
    {
        void Update();

        void BindKey(Keys key, ICommand command);

        void ClearCommand();
    }
}