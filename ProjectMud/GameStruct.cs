using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    public struct Vectors
    {
        public int x;
        public int y;

        public Vectors(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator == (Vectors left, Vectors right)
        {
            return left.x == right.x && left.y == right.y;
        }
        public static bool operator !=(Vectors left, Vectors right)
        {
            return left.x != right.x && left.y != right.y;
        }
    }
}
