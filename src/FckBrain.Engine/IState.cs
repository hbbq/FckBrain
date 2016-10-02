using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FckBrain.Engine
{
    public interface IState
    {

        IMemory Memory { get; }
        int DataPointer { get; set; }
        void Clear();
        byte GetData();
        void SetData(byte value);

    }
}
