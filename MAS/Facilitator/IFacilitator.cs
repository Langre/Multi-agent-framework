using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;
using MAS.LocalMSC;

namespace MAS.Facilitator
{
    interface IFacilitator
    {
        void RegistrateAgent(AbstractAgent NewAgent);
        void RemoveAgent(DeadAgentArgs SoonDeadAgent);
        List<String> ProvideInfo(QueryAgentArgs QueryParams);
    }
}
