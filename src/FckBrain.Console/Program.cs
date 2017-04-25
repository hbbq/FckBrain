﻿using System;
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

            var code = FckBrain.Examples.Sources.HelloWorld; 

            var runner = new Engine.Runner(
                new Engine.State(
                    new Engine.Memory()
                ),
                new Parser.CodeParser(),
                new Engine.Buffer(),
                new Engine.Buffer()
            );

            runner.Parser.SourceCode = code;
            runner.Parser.Parse();
            runner.Reset();

            while (!runner.EndOfProgram)
            {
                runner.ExecuteNextCommand();
                System.Diagnostics.Trace.WriteLine(runner.ToString());
            }

            var x = runner.Output.GetAsciiString();
            
        }
    }
}
