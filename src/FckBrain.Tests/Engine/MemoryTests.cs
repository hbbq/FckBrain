using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FckBrain.Engine;
using Xunit;
using Shouldly;

namespace FckBrain.Tests.Engine
{

    public class MemoryTests
    {

        private const ulong _heapSize = 30000;

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
            Should.Throw<ArgumentOutOfRangeException>(() => memory.GetHexString(_heapSize, 1));
            Should.Throw<ArgumentOutOfRangeException>(() => memory.GetHexString(_heapSize, 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(_heapSize-1)]
        public void PeekShouldReturnZero(ulong address)
        {
            var memory = GetMemoryInstance();
            memory.Peek(address).ShouldBe<byte>(0);
        }

        [Theory]
        [InlineData(0, 1, "00")]
        [InlineData(100, 3, "000000")]
        [InlineData(10000, 10, "00000000000000000000")]
        public void GetHexString(ulong start, ulong length, string expected)
        {
            var memory = GetMemoryInstance();
            memory.GetHexString(start, length).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1000, 10)]
        [InlineData(_heapSize - 1, 255)]
        public void PokePeek(ulong address, byte value)
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
        
    }

}
