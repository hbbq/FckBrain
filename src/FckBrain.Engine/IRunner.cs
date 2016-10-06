using FckBrain.Parser;
using FckBrain.Parser.Commands;

namespace FckBrain.Engine
{
    public interface IRunner
    {
        bool Completed { get; }
        bool EndOfProgram { get; }
        IBuffer Input { get; }
        int InstructionPointer { get; }
        IBuffer Output { get; }
        ICodeParser Parser { get; }
        IState State { get; }

        void RunProgram();
        void ExecuteCommad<T>(T command) where T : ICommand;
        void ExecuteNextCommand();
        void Setup(string sourceCode);
        void Reset();
    }
}