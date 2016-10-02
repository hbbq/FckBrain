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

    }

}
