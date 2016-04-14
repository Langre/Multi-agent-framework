using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MAS.AgentConstruct;

namespace MAS
{
    class SpacemanFactory : IAgentFactory
    {
        public AbstractAgent NewAgent(String ID)
        {
            SpacemanAgent Agent = new SpacemanAgent(ID);
            return Agent;
        }

        public AbstractAgent NewAgent(String ID, AbstractBehaviour NewB)
        {
            SpacemanAgent Agent = new SpacemanAgent(ID, NewB);
            return Agent;
        }
    }
}
