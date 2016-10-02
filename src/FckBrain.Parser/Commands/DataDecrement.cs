using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class DataDecrement : CommandBase
    {
        
        public override string Description => "Decrements the data at the data pointer by 1";
        public override bool IsNoOp => false;
        public override char Symbol => '-';

    }

}
