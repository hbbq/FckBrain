using System;
using FckBrain.Engine;
using Xunit;
using Shouldly;

namespace FckBrain.Tests.Engine
{

    public class MemoryTests
    {

        private const long HeapSize = 30000;

        private IMemory GetMemoryInstance() => new Memory();
        
        [Fact]
        public void PeekOutOfRange()
        {
            var memory = GetMemoryInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => memory.Peek(memory.Size));
        }

        [Fact]
        public void PokeOutOfRange()
        {
            var memory = GetMemoryInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => memory.Poke(memory.Size, 0));
        }

        [Fact]
        public void GetHexStringOutOfRange()
        {
            var memory = GetMemoryInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => memory.GetHexString(HeapSize, 1));
            Should.Throw<ArgumentOutOfRangeException>(() => memory.GetHexString(HeapSize, 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(HeapSize-1)]
        public void PeekShouldReturnZero(long address)
        {
            var memory = GetMemoryInstance();
            memory.Peek(address).ShouldBe<byte>(0);
        }

        [Theory]
        [InlineData(0, 1, "00")]
        [InlineData(100, 3, "000000")]
        [InlineData(10000, 10, "00000000000000000000")]
        public void GetHexString(long start, long length, string expected)
        {
            var memory = GetMemoryInstance();
            memory.GetHexString(start, length).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1000, 10)]
        [InlineData(HeapSize - 1, 255)]
        public void PokePeek(long address, byte value)
        {
            var memory = GetMemoryInstance();
            memory.Poke(address, value);
            memory.Peek(address).ShouldBe(value);
        }

        [Fact]
        public void GetHexStringAfterPokes()
        {
            var memory = GetMemoryInstance();
            memory.Poke(1, 16);
            memory.Poke(3, 255);
            memory.GetHexString(0, 4).ShouldBe("001000FF");
        }

        [Fact]
        public void ClearAfterPokes()
        {
            var memory = GetMemoryInstance();
            memory.Poke(1, 16);
            memory.Poke(3, 255);
            memory.Clear();
            memory.GetHexString(0, 4).ShouldBe("00000000");
        }

    }

}
