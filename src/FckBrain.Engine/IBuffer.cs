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
