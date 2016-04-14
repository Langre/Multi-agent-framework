using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MAS.AgentConstruct;

namespace MAS
{
    class SpacemanAgent : AbstractAgent
    {
        private string sdkfksdf;
        public SpacemanAgent(String ID) : base(ID) { }
        public SpacemanAgent(String ID, AbstractBehaviour NewB) : base(ID, NewB) { }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
