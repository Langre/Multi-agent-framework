using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MAS.AgentConstruct;

namespace MAS
{
    class OntologyReaderFactory : IAgentFactory
    {
        public AbstractAgent NewAgent(String ID) 
        {             
            OntologyReader Broker = new OntologyReader(ID);
            return Broker;
        }

        public AbstractAgent NewAgent(String ID, AbstractBehaviour NewB)
        {
            OntologyReader Broker = new OntologyReader(ID, NewB);
            return Broker;
        }
    }
}
