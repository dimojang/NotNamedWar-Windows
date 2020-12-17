using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    public delegate void Trigger();

    /// <summary>
    /// None = 0, MouseMove = 1, MouseDown = 2
    /// </summary>
    public enum ControlState
    {
        None,
        MouseMove,
        MouseDown
    }

    class GameControl
    {
        public bool Visibility { get; set; } = true;

        public string Tag { get; set; } = "";

        public Trigger Click { get; set; }

        public ControlState State { get; set; } = ControlState.None;

        public Rectangle Position
        {
            get { return new Rectangle(Location, Size); }
            set 
            { 
                Location = value.Location;
                Size = value.Size; 
            }
        }

        public Point Location { get; set; } = Point.Zero;

        public Point Size { get; set; } = Point.Zero;

        public int Width
        {
            get { return Size.X; }
            set { Size = new Point(value, Size.Y); }
        }

        public int Height
        {
            get { return Size.Y; }
            set { Size = new Point(Size.X, value); }
        }
    }
}
