using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{
    public interface IBuffer : IMemory
    {
                
        void Restart();
        void Append(byte value);
        byte Read();
        bool EndOfBuffer { get; }
        long Pointer { get; }
        string GetAsciiString();

    }
}
