using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{

    public interface IMemory
    {
        byte Peek(ulong address);
        void Poke(ulong address, byte value);
        string GetHexString(ulong start, ulong length);
        ulong Size { get; }
    }

}
