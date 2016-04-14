using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    public interface IAgentFactory
    {
        AbstractAgent NewAgent(String ID);
        AbstractAgent NewAgent(String ID, AbstractBehaviour NewB);
    }
}
