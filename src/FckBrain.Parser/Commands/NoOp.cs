using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class NoOp : CommandBase
    {

        private char _symbol;

        public override char Symbol => _symbol;

        public NoOp(char symbol) : base()
        {
            _symbol = symbol;
        }

        public override string Description => "NoOp command";
        public override bool IsNoOp => true;

    }

}
