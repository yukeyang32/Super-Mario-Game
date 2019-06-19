using System;
using System.Collections;
using System.Collections.Generic;
//For immutable array
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    internal class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings = new Dictionary<Keys, ICommand>();
        private Keys[] previousKeys;
        public event EventHandler<Keys> OnKeyReleased;

        public KeyboardController()
        {
            previousKeys = Keyboard.GetState().GetPressedKeys();
        }

        public void BindKey(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void ClearCommand()
        {
            controllerMappings.Clear();
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            foreach(Keys key in previousKeys)
            {
                if (!pressedKeys.Contains(key))
                    OnKeyReleased.Invoke(this, key);
            }


            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    if (key == Keys.Up || key==Keys.W || key==Keys.Down)
                    {
                        if (!previousKeys.Contains(key))
                        {
                            controllerMappings[key].Execute();
                        }
                    }
                    else
                    {
                        controllerMappings[key].Execute();
                    }
                    
                }

            }
            previousKeys = pressedKeys;
        }

    }
}