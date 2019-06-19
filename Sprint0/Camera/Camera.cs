using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Camera
    {

        static readonly Camera instance = new Camera();

        private int position;

        public static Camera Instance
        {
            get
            {
                return instance;
            }
        }

        private Camera()
        {
            position = ConstantNumber.CAMERA_START_X;
        }

        public int ComputeCameraLocation(int location)
        {
            return location - position;
        }

        public void ResetCameraLocation()
        {
            position = 0;
        }

        public void Update()
        {
            int marioPosition = (int)Game1.Instance.Mario.Position.X;
            position = marioPosition - ConstantNumber.CAMERA_MARIO_POSITION_X_ADJUST;
            if(marioPosition > ConstantNumber.CAMERA_MARIO_POSITION_X_LIMIT)
            {
                position = ConstantNumber.CAMERA_MARIO_POSITION_X_LIMIT;
            }
        }
    }
}
