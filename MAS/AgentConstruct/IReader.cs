using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    interface IReader
    {
        void Parse(String Content);
        dynamic ReturnInstructions();
    }
}
