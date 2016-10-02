using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{

    public interface IMemory
    {
        byte Peek(long address);
        void Poke(long address, byte value);
        string GetHexString(long start, long length);
        long Size { get; }
        void Clear();
    }

}
