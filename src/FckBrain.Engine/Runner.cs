using System;
using FckBrain.Parser;
using FckBrain.Parser.Commands;

namespace FckBrain.Engine
{

    public class Runner : IRunner
    {

        private readonly IState _state;
        public IState State => _state;

        private readonly ICodeParser _parser;
        public ICodeParser Parser => _parser;

        private int _instructionPointer;
        public int InstructionPointer => _instructionPointer;
        
        private readonly IBuffer _input;
        public IBuffer Input => _input;

        private readonly IBuffer _output;
        public IBuffer Output => _output;

        public Runner(IState state, ICodeParser parser, IBuffer input, IBuffer output)
        {
            _state = state;
            _parser = parser;
            _input = input;
            _output = output;
        }

        public void Reset()
        {
            State.Clear();
            _instructionPointer = 0;
            Input.Restart();
            Output.Clear();
        }

        public void ExecuteNextCommand()
        {
            var c = _parser.GetCommandAt(_instructionPointer);
            ExecuteCommad(c);
            _instructionPointer++;
        }

        public bool EndOfProgram => _instructionPointer >= _parser.NumberOfCommands;

        public void ExecuteCommad(ICommand command)
        {
            
            switch (command)
            {
                case PointerIncrement _:
                    if (State.DataPointer > State.Memory.Size - 2) throw new OutOfMemoryException();
                    State.DataPointer++;
                    break;
                case PointerDecrement _:
                    if (State.DataPointer <= 0) throw new OutOfMemoryException();
                    State.DataPointer--;
                    break;
                case DataIncrement _:
                    State.SetData((byte)((State.GetData() + 1) % 256));
                    break;
                case DataDecrement _:
                    State.SetData((byte)((State.GetData() + 255) % 256));
                    break;
                case Output _:
                    Output.Append(State.GetData());
                    break;
                case Input _:
                    State.SetData(Input.Read());
                    break;
                case BlockStart _:
                    if (State.GetData() == 0) _instructionPointer = _parser.GetPositionOfMatchingBlockEnd(_instructionPointer);
                    break;
                case BlockEnd _:
                    if (State.GetData() != 0) _instructionPointer = _parser.GetPositionOfMatchingBlockStart(_instructionPointer);
                    break;
            }

        }

        public override string ToString() => $"{State.Memory.GetHexString(0, 20)} {_instructionPointer}/{_parser.NumberOfCommands} {_output.GetAsciiString()}";

        public void RunProgram()
        {
            while (!EndOfProgram)
            {
                ExecuteNextCommand();
            }
        }

        public void Setup(string sourceCode)
        {
            _parser.SourceCode = sourceCode;
            _parser.Parse();
            Reset();
        }

    }

}
