using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.Facilitator;
using MAS.LocalMSC;

namespace MAS.AgentConstruct
{
    class AgentsDeathSignal : IDeathSignal
    {
        private IMessageService Post;
        private IFacilitator Shelf;

        public AgentsDeathSignal(IMessageService Post, IFacilitator Shelf)
        {
            this.Post = Post;
            this.Shelf = Shelf;
        }

        public void SignalAboutDeleting(String DeadAgent)
        {
            Post.RemoveClient(DeadAgent);
            Shelf.RemoveAgent(DeadAgent);
        }
    }
}
