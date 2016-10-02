using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FckBrain.Parser.Commands;

namespace FckBrain.Parser
{
    public class CodeParser : ICodeParser
    {

        private List<Commands.CommandBase> _commands;

        public int NumberOfCommands => _commands?.Count() ?? 0;

        public string SourceCode { get; set; }

        public IEnumerable<ICommand> GetAllCommands()
        {
            return _commands;
        }

        public ICommand GetCommandAt(int position)
        {
            if (position < 0 || position >= NumberOfCommands) throw new ArgumentOutOfRangeException();
            return _commands[position];
        }

        public void Parse()
        {
            _commands = SourceCode.ToCharArray().Select(symbol => SymbolToCommand(symbol)).ToList();
        }

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
