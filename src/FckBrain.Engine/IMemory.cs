namespace FckBrain.Engine
{

    public interface IMemory
    {
        byte Peek(long address);
        void Poke(long address, byte value);
        string GetHexString(long start, long length);
        string GetAsciiString(long start, long length);
        long Size { get; }
        void Clear();
    }

}
