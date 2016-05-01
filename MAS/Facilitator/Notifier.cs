using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    public class Notifier : IAgentStateObserver
    {
        public event AddAgent<NewAgentArgs> NewAgentEvent;
        public event DeadAgent<DeadAgentArgs> DeadAgentEvent;

        public void AddObserverComponent(IObserverAgentComponent Observer)
        {
            NewAgentEvent += Observer.GotSignalNewAgent;
            DeadAgentEvent += Observer.GotSignalDeadAgent;
        }

        public void ThrowNewAgentSignal(AbstractAgent NewA) 
        {
            NewAgentEvent(new NewAgentArgs(NewA));
        }
        public void ThrowDeadAgentSignal(DeadAgentArgs IDOfDeadAgent)
        {
            DeadAgentEvent(IDOfDeadAgent);
        }
    }
}
