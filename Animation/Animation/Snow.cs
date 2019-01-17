using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation
{
    class Snow
    {
        int speed;
        int raduis, x, y;
        public Snow() { }
        public Snow(int Speed,int Raduis,int X,int Y)
        {
            speed = Speed;raduis = Raduis;x = X;y = Y;
        }
        public int X
        {
            set { x = value; }
            get { return x; }
        }
        public int Y
        {
            set { y = value; }
            get { return (y); }
        }
        public int Raduis
        {
            set { raduis = value; }
            get { return raduis; }
        }
        public int Speed
        {
            set { speed = value; }
            get { return speed; }
        }
    }
}
