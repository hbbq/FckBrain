using System;
using System.Linq;
using FckBrain.Parser;
using Xunit;
using Shouldly;

namespace FckBrain.Tests.Parser
{
    public class CodeParserTests
    {
        
        private static ICodeParser GetCodeParser() => new CodeParser();

        [Theory]
        [InlineData(' ', typeof(FckBrain.Parser.Commands.NoOp))]
        [InlineData('>', typeof(FckBrain.Parser.Commands.PointerIncrement))]
        [InlineData('<', typeof(FckBrain.Parser.Commands.PointerDecrement))]
        [InlineData('+', typeof(FckBrain.Parser.Commands.DataIncrement))]
        [InlineData('-', typeof(FckBrain.Parser.Commands.DataDecrement))]
        [InlineData('.', typeof(FckBrain.Parser.Commands.Output))]
        [InlineData(',', typeof(FckBrain.Parser.Commands.Input))]
        [InlineData('[', typeof(FckBrain.Parser.Commands.BlockStart))]
        [InlineData(']', typeof(FckBrain.Parser.Commands.BlockEnd))]
        public void SymbolToCommand(char symbol, Type expected)
        {
            var parser = GetCodeParser();
            parser.SymbolToCommand(symbol).ShouldBeOfType(expected);
        }

        [Fact]
        public void ParseShouldGetRightNumberOfCommands()
        {
            var parser = GetCodeParser();
            parser.SourceCode = @"test> </+-\\\.,[] #123456798";
            parser.Parse();
            parser.NumberOfCommands.ShouldBe(28);
        }

        [Fact]
        public void ParseShouldGetRightNumberOfOpCommands()
        {
            var parser = GetCodeParser();
            parser.SourceCode = @"test> </+-\\\.,[] #123456798";
            parser.Parse();
            parser.GetAllCommands().Count(command => !command.IsNoOp).ShouldBe(8);
        }

        [Fact]
        public void ParseShouldGetCommandsAtRightPlace()
        {
            var parser = GetCodeParser();
            parser.SourceCode = @"test> </+-\\\.,[] #123456798";
            parser.Parse();
            parser.GetCommandAt(4).ShouldBeOfType<FckBrain.Parser.Commands.PointerIncrement>();
            parser.GetCommandAt(6).ShouldBeOfType<FckBrain.Parser.Commands.PointerDecrement>();
            parser.GetCommandAt(8).ShouldBeOfType<FckBrain.Parser.Commands.DataIncrement>();
            parser.GetCommandAt(9).ShouldBeOfType<FckBrain.Parser.Commands.DataDecrement>();
            parser.GetCommandAt(13).ShouldBeOfType<FckBrain.Parser.Commands.Output>();
            parser.GetCommandAt(14).ShouldBeOfType<FckBrain.Parser.Commands.Input>();
            parser.GetCommandAt(15).ShouldBeOfType<FckBrain.Parser.Commands.BlockStart>();
            parser.GetCommandAt(16).ShouldBeOfType<FckBrain.Parser.Commands.BlockEnd>();
        }

        [Fact]
        public void FindBlockEnd()
        {
            var parser = GetCodeParser();
            parser.SourceCode = @">>[>>[>>[>>]>>[>>[>>]>>]>>]>>]>>";
            parser.Parse();
            parser.GetPositionOfMatchingBlockEnd(5).ShouldBe(26);
        }
        
        [Fact]
        public void FindBlockStart()
        {
            var parser = GetCodeParser();
            parser.SourceCode = @">>[>>[>>[>>]>>[>>[>>]>>]>>]>>]>>";
            parser.Parse();
            parser.GetPositionOfMatchingBlockStart(26).ShouldBe(5);
        }

    }
}
