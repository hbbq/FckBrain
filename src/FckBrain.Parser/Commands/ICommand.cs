using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Parser.Commands
{
    public interface ICommand
    {
        
        char Symbol { get; }
        bool IsNoOp { get; }
        string Description { get; }

    }
}
