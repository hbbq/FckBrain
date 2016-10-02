using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public class PointerDecrement : CommandBase
    {
        
        public override string Description => "Decrements the pointer by 1";
        public override char Symbol => '<';

    }

}
