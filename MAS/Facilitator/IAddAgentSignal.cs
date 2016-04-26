using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    interface IAddAgentSignal
    {
        void AddNewAgentToAll(AbstractAgent NewAgent);
    }
}
