using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class BlockEnd : CommandBase
    {
        
        public override string Description => "Jumps to the matching block start command if the data at the pointer is not zero";
        public override char Symbol => ']';

    }

}
