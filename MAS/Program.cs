using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using MAS.AgentConstruct;
using MAS.LocalMSC;
using MAS.Facilitator;

namespace MAS
{
    class AgentA : AbstractAgent
    {
        public AgentA (String ID, IDeathSignal DS, List<AbstractBehaviour> B) 
            : base(ID, DS, B)
        { }

        public override void Execute()
        {
             PersonalPostman.SendToPost(new Message(this.GetID, "AgentB", "param pam"));
             this.Suicide();            
        }
    }

    class AgentB : AbstractAgent
    {
        public AgentB(String ID, IDeathSignal DS, List<AbstractBehaviour> B)
            : base(ID, DS, B)
        { }

        public override void Execute()
        {
             String r = PersonalPostman.RecieveMessage().GetContent;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {            
            IMessageService Post = LocalPost.GetInstance();
            IFacilitator Shelf = new Shelf(new AddAgentSignal(Post));

            AbstractAgent aA = new AgentA("AgentA", new AgentsDeathSignal(Post, Shelf), new List<AbstractBehaviour>());
            AbstractAgent aB = new AgentB("AgentB", new AgentsDeathSignal(Post, Shelf), new List<AbstractBehaviour>());
            aA.SetPostman(new DefaultPostman(aA));
            aB.SetPostman(new DefaultPostman(aB));
            Shelf.RegistrateAgent(aA);
            Shelf.RegistrateAgent(aB);

            aA.Execute();
            aB.Execute();
        }
    }
}
