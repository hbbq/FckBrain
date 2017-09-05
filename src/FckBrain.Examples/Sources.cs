using System;

namespace FckBrain.Examples
{

    public static class Sources
    {

        private static string GetEmbeddedFile(string filename)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            using (var sr = new System.IO.StreamReader(asm.GetManifestResourceStream($"FckBrain.Examples.{filename}") ?? throw new InvalidOperationException()))
            {
                return sr.ReadToEnd();
            }
        }

        public static string HelloWorld => GetEmbeddedFile("HelloWorld.bf");

        public static string Fibonacci => GetEmbeddedFile("Fibonacci.bf");
       

    }

}
