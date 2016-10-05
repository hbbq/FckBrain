using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{

    public class Buffer : IBuffer
    {

        private long _pointer = 0;
        private readonly List<byte> _data = new List<byte>();

        public bool EndOfBuffer => Pointer >= Size;

        public long Pointer => _pointer;

        public long Size => _data.Count;

        public void Append(byte value) => _data.Add(value);

        public void Clear()
        {
            _data.Clear();
            _pointer = 0;
        }

        public string GetHexString(long start, long length)
        {
            if (start + length - 1 >= Size || length < 1) throw new ArgumentOutOfRangeException();
            return BitConverter.ToString(_data.ToArray(), (int)start, (int)length).Replace("-", "");
        }

        public byte Peek(long address)
        {
            if (address >= _data.Count) throw new ArgumentOutOfRangeException();
            return _data[(int)address];
        }

        public void Poke(long address, byte value)
        {
            if (address >= _data.Count) throw new ArgumentOutOfRangeException();
            _data[(int)address] = value;
        }

        public byte Read()
        {
            if (EndOfBuffer) throw new EndOfBufferException();
            _pointer++;
            return Peek(_pointer-1);
        }

        public void Restart()
        {
            _pointer = 0;
        }
    }

}
