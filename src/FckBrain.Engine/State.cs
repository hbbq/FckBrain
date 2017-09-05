namespace FckBrain.Engine
{

    public class State : IState
    {

        private readonly IMemory _memory;
        public IMemory Memory => _memory;

        public int DataPointer { get; set; }

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
