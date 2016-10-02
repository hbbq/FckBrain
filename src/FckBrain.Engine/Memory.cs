using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{
    class Memory : IMemory
    {

        private byte[] _heap;
        private const ulong _size = 30000;
        
        public Memory()
        {
            _heap = new byte[_size];
            for(ulong address = 0; address < _size; address++)
            {
                _heap[address] = 0;
            }
            
        }

        ulong IMemory.Size => _size;

        byte IMemory.Peek(ulong address)
        {
            if (address >= _size) throw new ArgumentOutOfRangeException();
            return _heap[address];
        }

        void IMemory.Poke(ulong address, byte value)
        {
            if (address >= _size) throw new ArgumentOutOfRangeException();
            _heap[address] = value;
        }

        string IMemory.GetHexString(ulong start, ulong length)
        {
            if (start + length - 1 >= _size) throw new ArgumentOutOfRangeException();
            return BitConverter.ToString(_heap, (int)start, (int)length).Replace("-", "");
        }
    }
}
