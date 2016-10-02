using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser
{
    public interface ICodeParser
    {

        string SourceCode { get; set; }
        void Parse();
        Commands.CommandBase SymbolToCommand(char symbol);

    }
}
