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
        string ICodeParser.SourceCode { get; set; }

        void ICodeParser.Parse()
        {
            throw new NotImplementedException();
        }

        CommandBase ICodeParser.SymbolToCommand(char symbol)
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
