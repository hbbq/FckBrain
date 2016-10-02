using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{
    public class Memory : IMemory
    {

        private readonly byte[] _heap;
        private const long _size = 30000;
        
        public Memory()
        {
            _heap = new byte[_size];
            Clear();
        }

        public void Clear()
        {
            for (ulong address = 0; address < _size; address++)
            {
                _heap[address] = 0;
            }
        }

        public long Size => _size;

        public byte Peek(long address)
        {
            if (address >= _size) throw new ArgumentOutOfRangeException();
            return _heap[address];
        }

        public void Poke(long address, byte value)
        {
            if (address >= _size) throw new ArgumentOutOfRangeException();
            _heap[address] = value;
        }

        public string GetHexString(long start, long length)
        {
            if (start + length - 1 >= _size || length < 1) throw new ArgumentOutOfRangeException();
            return BitConverter.ToString(_heap, (int)start, (int)length).Replace("-", "");
        }
    }
}
