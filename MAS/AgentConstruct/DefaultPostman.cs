using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.LocalMSC;

namespace MAS.AgentConstruct
{
    class DefaultPostman : IServicePost
    {
        private AbstractAgent Host;
        private Message CurrentPackage;
        public event ToPost<MessageArgs> SendLetter;    //для обмена сообщениями с почтой
        public event CheckPost<AdressArgs> SendQuery; //для обмена сообщениями с почтой

        public AbstractAgent GetHost { get { return Host;} }

        public DefaultPostman(AbstractAgent Host)
        {
            this.Host = Host;
        }

        public Message RecieveMessage()
        {
            return SendQuery(Host, new AdressArgs(Host.GetID));
        }

        public void SendToPost(Message Letter)
        {
            SendLetter(Host, new MessageArgs(CurrentPackage));
        }

        public void PackMessage(MType Goal, String Sender, String Reciever, String OntologyName, String MessageText)
        {
            String Content = "(" + Goal.ToString() +
                      " :sender " + Sender +
                      " :ontology " + OntologyName +
                      " :content " + MessageText + " )";
            CurrentPackage = new Message(Sender, Reciever, Content);
        }
    }
}
