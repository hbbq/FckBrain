using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FckBrain.Parser;

namespace FckBrain.Engine
{

    class Runner
    {

        private readonly IState _state;
        public IState State => _state;

        private readonly ICodeParser _parser;
        public ICodeParser Parser => _parser;

        private int _instructionPointer = 0;
        public int InstructionPointer => _instructionPointer;

        public bool Completed => InstructionPointer >= _parser.NumberOfCommands;

        private readonly IBuffer _input;
        private readonly IBuffer _output;

        public IBuffer Input => _input;
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

        public void ExecuteCommad<T>(T command) where T: Parser.Commands.ICommand
        {

            if(command is Parser.Commands.PointerIncrement)
            {
                if (State.DataPointer > State.Memory.Size - 2) throw new OutOfMemoryException();
                State.DataPointer++;
            }

            if (command is Parser.Commands.PointerDecrement)
            {
                if (State.DataPointer <= 0) throw new OutOfMemoryException();
                State.DataPointer--;
            }

            if (command is Parser.Commands.DataIncrement)
            {
                State.SetData((byte)((State.GetData() + 1) % 256));
            }

            if (command is Parser.Commands.DataDecrement)
            {
                State.SetData((byte)((State.GetData() + 255) % 256));
            }

            if (command is Parser.Commands.Output)
            {
                Output.Append(State.GetData());
            }

            if (command is Parser.Commands.Input)
            {
                State.SetData(Input.Read());
            }

            if (command is Parser.Commands.BlockStart)
            {
                if (State.GetData() == 0) _instructionPointer = _parser.GetPositionOfMatchingBlockEnd(_instructionPointer);
            }

            if (command is Parser.Commands.BlockEnd)
            {
                if (State.GetData() != 0) _instructionPointer = _parser.GetPositionOfMatchingBlockStart(_instructionPointer);
            }

        }

        public override string ToString()
        {
            return $"{State.Memory.GetHexString(0, 20)} {_instructionPointer}/{_parser.NumberOfCommands} {_output.GetAsciiString()}";
        }

    }

}
