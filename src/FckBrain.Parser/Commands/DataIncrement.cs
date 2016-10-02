using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class DataIncrement : CommandBase
    {
        
        public override string Description => "Increments the data at the data pointer by 1";
        public override char Symbol => '+';

    }

}
