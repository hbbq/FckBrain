using FckBrain.Engine;
using Xunit;
using Shouldly;

namespace FckBrain.Tests.Engine
{
    public class RunnerTests
    {

        private readonly string _helloWorldSource = Examples.Sources.HelloWorld;
        private const string ShortProgramSource = @">>+";


        private IRunner GetRunner()
        {           
            return new Runner(
                new State(
                    new Memory()
                ),
                new FckBrain.Parser.CodeParser(),
                new Buffer(),
                new Buffer()
            );
        }

        private IRunner GetRunnerShortCode()
        {
            var runner = GetRunner();
            runner.Setup(ShortProgramSource);
            return runner;
        }
        private IRunner GetRunnerHelloWorld()
        {
            var runner = GetRunner();
            runner.Setup(_helloWorldSource);
            return runner;
        }

        [Fact]
        public void EndOfProgram()
        {
            var runner = GetRunnerShortCode();
            for(var i = 0; i < 3; i++)
            {
                runner.EndOfProgram.ShouldBe(false);
                runner.ExecuteNextCommand();
            }
            runner.EndOfProgram.ShouldBe(true);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void InstructionPointer(int times)
        {
            var runner = GetRunnerShortCode();
            for(var i = 0; i < times; i++)
            {
                runner.ExecuteNextCommand();
            }
            runner.InstructionPointer.ShouldBe(times);
        }

        [Fact]
        public void ShortProgram()
        {
            var runner = GetRunnerShortCode();
            runner.RunProgram();
            runner.State.Memory.GetHexString(0, 3).ShouldBe(@"000001");
        }

        [Fact]
        public void HelloWorldProgram()
        {
            var runner = GetRunnerHelloWorld();
            runner.RunProgram();
            runner.Output.GetAsciiString().ShouldBe("Hello World!\n");
        }

        [Fact]
        public void Reset()
        {
            var runner = GetRunnerHelloWorld();
            runner.RunProgram();
            runner.Reset();
            runner.RunProgram();
            runner.Output.GetAsciiString().ShouldBe("Hello World!\n");
        }
        
    }

}
