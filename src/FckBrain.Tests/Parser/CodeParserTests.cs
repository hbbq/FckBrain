using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
