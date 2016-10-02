using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public abstract class CommandBase : ICommand
    {
        
        public abstract char Symbol { get; }
        public virtual bool IsNoOp => false;
        public abstract string Description { get; }

        public CommandBase()
        {
        }

    }
}
