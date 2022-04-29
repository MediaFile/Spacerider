using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SpaceRider
{
    interface iflyingObject
    {
        Image Image { get; set; }
        int X { get; set; }
        int Y { get; set; }
        bool Showing { get; set; }
        int Horizontal { get; set; }
    }
}
