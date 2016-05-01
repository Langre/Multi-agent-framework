using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    public delegate void AddAgent<NewAgentArgs>(NewAgentArgs NAArg);
    public delegate void DeadAgent<DeadAgentArgs>(DeadAgentArgs DAArg);   

    public interface IAgentStateObserver
    {
        event AddAgent<NewAgentArgs> NewAgentEvent;
        event DeadAgent<DeadAgentArgs> DeadAgentEvent;
        void AddObserverComponent(IObserverAgentComponent Observer);
        void ThrowNewAgentSignal(AbstractAgent NewA);
        void ThrowDeadAgentSignal(DeadAgentArgs IDOfDeadAgent);
    }
    
    public interface IObserverAgentComponent 
    {
        void GotSignalNewAgent(NewAgentArgs NAArg);
        void GotSignalDeadAgent(DeadAgentArgs DAArg);
    }

    public class NewAgentArgs : EventArgs
    {
        private AbstractAgent NewAgent;
        public AbstractAgent GetNewAgent { get {return NewAgent; } }
        public NewAgentArgs(AbstractAgent NewAgent)
        {
            this.NewAgent = NewAgent;
        }
    }

    public class DeadAgentArgs : EventArgs
    {
        private string DeadAgent;
        public String GetDeadAgent { get {return DeadAgent; } }
        public DeadAgentArgs(String DeadAgentID)
        {
            this.DeadAgent = DeadAgentID;
        }
    }
}
