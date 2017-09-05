using FckBrain.Parser;
using FckBrain.Parser.Commands;

namespace FckBrain.Engine
{

    public interface IRunner
    {

        bool EndOfProgram { get; }
        IBuffer Input { get; }
        int InstructionPointer { get; }
        IBuffer Output { get; }
        ICodeParser Parser { get; }
        IState State { get; }

        void RunProgram();
        void ExecuteCommad(ICommand command);
        void ExecuteNextCommand();
        void Setup(string sourceCode);
        void Reset();

    }

}