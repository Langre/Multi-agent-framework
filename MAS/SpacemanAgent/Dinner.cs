using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS
{
    
    class MundaneOperation : AbstractAgent
    {
        [AgentAttribute("IDOperation")]
        private String ID;
        public override string GetID { get { return ID; } }
        public MundaneOperation() { }
        public override void Execute()
        {
            String r = PersonalPostman.RecieveMessage().GetContent;
        }
    }
}
