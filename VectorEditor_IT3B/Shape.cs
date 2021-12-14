using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VectorEditor_IT3B
{
    public abstract class Shape
    {
        public abstract void Draw(Graphics graphics);
    }

    public enum Shapes
    {
        None,
        Point,
        Line
    }
}
