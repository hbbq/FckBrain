using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{

    public class Buffer : IBuffer
    {
        public bool EndOfBuffer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Pointer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Append(byte value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public string GetHexString(long start, long length)
        {
            throw new NotImplementedException();
        }

        public byte Peek(long address)
        {
            throw new NotImplementedException();
        }

        public void Poke(long address, byte value)
        {
            throw new NotImplementedException();
        }

        public byte Read()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }
    }

}
