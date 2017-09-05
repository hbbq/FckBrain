using System.Collections.Generic;

namespace FckBrain.Parser
{

    public interface ICodeParser
    {

        string SourceCode { get; set; }
        void Parse();
        Commands.CommandBase SymbolToCommand(char symbol);
        int NumberOfCommands { get; }
        Commands.ICommand GetCommandAt(int position);
        IEnumerable<Commands.ICommand> GetAllCommands();
        int GetPositionOfMatchingBlockEnd(int position);
        int GetPositionOfMatchingBlockStart(int position);

    }

}
