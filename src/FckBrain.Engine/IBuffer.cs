using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{
    interface IBuffer
    {

        void Clear();
        void Restart();
        void Append(byte value);
        byte Read();

    }
}
