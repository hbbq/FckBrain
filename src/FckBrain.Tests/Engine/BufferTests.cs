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

    public class BufferTests
    {

        private IBuffer GetBufferInstance()
        {
            var buffer = new FckBrain.Engine.Buffer();
            for(var i = 0; i < 10; i++) buffer.Append(0);
            return buffer;
        }

        [Fact]
        public void Size()
        {
            var buffer = GetBufferInstance();
            buffer.Size.ShouldBe(10);
        }
        
        [Fact]
        public void PeekOutOfRange()
        {
            var buffer = GetBufferInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => buffer.Peek(buffer.Size));
        }

        [Fact]
        public void PokeOutOfRange()
        {
            var buffer = GetBufferInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => buffer.Poke(buffer.Size, 0));
        }

        [Fact]
        public void GetHexStringOutOfRange()
        {
            var buffer = GetBufferInstance();
            Should.Throw<ArgumentOutOfRangeException>(() => buffer.GetHexString(buffer.Size, 1));
            Should.Throw<ArgumentOutOfRangeException>(() => buffer.GetHexString(buffer.Size, 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(9)]
        public void PeekShouldReturnZero(long address)
        {
            var buffer = GetBufferInstance();
            buffer.Peek(address).ShouldBe<byte>(0);
        }

        [Theory]
        [InlineData(0, 1, "00")]
        [InlineData(3, 3, "000000")]
        [InlineData(1, 8, "0000000000000000")]
        public void GetHexString(long start, long length, string expected)
        {
            var buffer = GetBufferInstance();
            buffer.GetHexString(start, length).ShouldBe(expected);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(3, 10)]
        [InlineData(9, 255)]
        public void PokePeek(long address, byte value)
        {
            var buffer = GetBufferInstance();
            buffer.Poke(address, value);
            buffer.Peek(address).ShouldBe(value);
        }

        [Fact]
        public void GetHexStringAfterPokes()
        {
            var buffer = GetBufferInstance();
            buffer.Poke(1, 16);
            buffer.Poke(3, 255);
            buffer.GetHexString(0, 4).ShouldBe("001000FF");
        }

        [Fact]
        public void ClearAfterPokes()
        {
            var buffer = GetBufferInstance();
            buffer.Poke(1, 16);
            buffer.Poke(3, 255);
            buffer.Clear();
            buffer.Size.ShouldBe(0);
        }

        [Fact]
        public void EndOfBuffer()
        {
            var buffer = GetBufferInstance();
            for (var i = 0; i < 10; i++) buffer.Read();
            buffer.EndOfBuffer.ShouldBe(true);
        }

        [Fact]
        public void NotEndOfBuffer()
        {
            var buffer = GetBufferInstance();
            for (var i = 0; i < 9; i++) buffer.Read();
            buffer.EndOfBuffer.ShouldBe(false);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Pointer(int times)
        {
            var buffer = GetBufferInstance();
            for (var i = 0; i < times; i++) buffer.Read();
            buffer.Pointer.ShouldBe(times);
        }

        [Fact]
        public void Append()
        {
            var buffer = GetBufferInstance();
            buffer.Clear();
            buffer.Append(100);
            buffer.Peek(0).ShouldBe<byte>(100);
        }

        [Fact]
        public void Read()
        {
            var buffer = GetBufferInstance();
            buffer.Append(200);
            for (var i = 0; i < 10; i++) buffer.Read();
            buffer.Read().ShouldBe<byte>(200);
        }

        [Fact]
        public void ReadEndOfBuffer()
        {
            var buffer = GetBufferInstance();
            for (var i = 0; i < 10; i++) buffer.Read();
            Should.Throw<EndOfBufferException>(() => buffer.Read());
        }

    }

}
