using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using MAS.AgentConstruct;
using MAS.LocalMSC;

namespace MAS
{
    class Spaceman : AbstractAgent
    {
        [AgentAttribute("IDMan")]
        private String ID;
        public override string GetID { get { return ID; } }
        public Spaceman() { }
        public override void Execute()
        {
            PersonalPostman.SendToPost(new Message(this.ID, "1Dinner", ""));
        }
    }
}
