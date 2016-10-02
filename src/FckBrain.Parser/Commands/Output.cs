using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class Output : CommandBase
    {
        
        public override string Description => "Outputs the byte at the data pointer";
        public override char Symbol => '.';

    }

}
