using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    interface IFacilitator
    {
        void RegistrateAgent(AgentInfo NewAgent);
        void RegistrateAgents(IEnumerable<AgentInfo> NewAgents);
        void RemoveAgent(string AgentID);
        void ProvideInfo();
    }
}
