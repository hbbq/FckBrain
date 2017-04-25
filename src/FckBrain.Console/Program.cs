using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Console
{
    static class Program
    {
        static void Main(string[] args)
        {

            var code = FckBrain.Examples.Sources.Fibonacci; 

            var runner = new Engine.Runner(
                new Engine.State(
                    new Engine.Memory()
                ),
                new Parser.CodeParser(),
                new Engine.Buffer(),
                new consoleOut()
            );

            runner.Parser.SourceCode = code;
            runner.Parser.Parse();
            runner.Reset();

            while (!runner.EndOfProgram)
            {
                runner.ExecuteNextCommand();
            }

            System.Console.ReadKey();
            
        }

        private class consoleOut : FckBrain.Engine.Buffer
        {
            public override void Append(byte value)
            {
                System.Console.Write(System.Text.Encoding.ASCII.GetString(new[] { value }));
                base.Append(value);
            }
        }
    }
}
