using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FckBrain.Parser;

namespace FckBrain.Engine
{

    public class State : IState
    {

        private readonly IMemory _memory;
        public IMemory Memory => _memory;

        public int DataPointer { get; set; } = 0;

        public State(IMemory memory)
        {
            _memory = memory;
        }

        public void Clear()
        {
            Memory.Clear();
            DataPointer = 0;
        }

        public byte GetData()
        {
            return Memory.Peek(DataPointer);
        }

        public void SetData(byte value)
        {
            Memory.Poke(DataPointer, value);
        }
        
    }

}
