using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public enum PrimitivesType { Circle, Rectangle };
    class Primitives
    {
        public int radius;
        public int centerX;
        public int centerY;
        public PrimitivesType PrimitivesType { get; set; }
    }
}
