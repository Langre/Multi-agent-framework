using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.LocalMSC;
using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    class AddAgentSignal : IAddAgentSignal
    {
        private IMessageService Post;
        public AddAgentSignal(IMessageService Post)
        {
            this.Post = Post;
        }
        public void AddNewAgentToAll(AbstractAgent NewAgent)
        {
            Post.AddClient(NewAgent);
        }
    }
}
