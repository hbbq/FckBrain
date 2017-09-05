using System;
using System.Collections.Generic;
using System.Linq;
using FckBrain.Parser.Commands;

namespace FckBrain.Parser
{

    public class CodeParser : ICodeParser
    {

        private List<CommandBase> _commands;

        public int NumberOfCommands => _commands?.Count() ?? 0;

        public string SourceCode { get; set; }

        public IEnumerable<ICommand> GetAllCommands() => _commands;

        public ICommand GetCommandAt(int position)
        {
            if (position < 0 || position >= NumberOfCommands) throw new ArgumentOutOfRangeException();
            return _commands[position];
        }

        public int GetPositionOfMatchingBlockEnd(int position)
        {
            var lvl = 1;
            var pos = position;
            while(lvl != 0)
            {
                pos++;
                var c = GetCommandAt(pos);
                if (c is BlockStart) lvl++;
                if (c is BlockEnd) lvl--;
            }
            return pos;
        }

        public int GetPositionOfMatchingBlockStart(int position)
        {
            var lvl = 1;
            var pos = position;
            while (lvl != 0)
            {
                pos--;
                var c = GetCommandAt(pos);
                if (c is BlockStart) lvl--;
                if (c is BlockEnd) lvl++;
            }
            return pos;
        }

        public void Parse() => _commands = SourceCode.ToCharArray().Select(SymbolToCommand).ToList();

        public CommandBase SymbolToCommand(char symbol)
        {
            switch (symbol)
            {
                case '>': return new PointerIncrement();
                case '<': return new PointerDecrement();
                case '+': return new DataIncrement();
                case '-': return new DataDecrement();
                case '.': return new Output();
                case ',': return new Input();
                case '[': return new BlockStart();
                case ']': return new BlockEnd();
                default: return new NoOp(symbol);
            }
        }

    }

}
