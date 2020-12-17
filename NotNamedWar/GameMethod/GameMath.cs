using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.GameMethod
{
    class GameMath
    {
        static public bool Between(double min, double max, double input)
        {
            return input < max && input > min;
        }

        static public bool Contain(Rectangle rectangle, Point point)
        {
            int verticalMax = rectangle.Y + rectangle.Height;
            int horizontalMax = rectangle.X + rectangle.Width;

            if (Between(rectangle.Y, verticalMax, point.Y) && Between(rectangle.X, horizontalMax, point.X))
                return true;
            else
                return false;
        }
    }
}
