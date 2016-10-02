using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class Input : CommandBase
    {
        
        public override string Description => "Reads a byte from the input to the byte at the data pointer";
        public override char Symbol => ',';

    }

}
