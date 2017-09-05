using System;
using System.Text;

namespace FckBrain.Engine
{
    public class Memory : IMemory
    {

        private readonly byte[] _heap;

        private readonly long _size = 30000;
        
        public Memory()
        {
            _heap = new byte[_size];
            Clear();
        }

        public void Clear()
        {
            for (long address = 0; address < _size; address++)
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

        public string GetAsciiString(long start, long length)
        {
            if (start + length - 1 >= _size || length < 1) throw new ArgumentOutOfRangeException();
            return Encoding.ASCII.GetString(_heap, (int)start, (int)length);
        }

    }

}
