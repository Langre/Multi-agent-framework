using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.LocalMSC;

namespace MAS.AgentConstruct
{
    public delegate void ToPost<MessageArgs>(AbstractAgent Sender, MessageArgs Arg);
    public delegate Message CheckPost<RecieverAdress>(AbstractAgent Sender, RecieverAdress ID);

    public interface IServicePost
    {
        event ToPost<MessageArgs> SendLetter;    //для обмена сообщениями с почтой
        event CheckPost<AdressArgs> SendQuery; //для обмена сообщениями с почтой
        void SendToPost(Message Letter);
        Message RecieveMessage();
        void PackMessage(MType Goal, String Sender, String Reciever, String OntologyName, String MessageText);
    }
}
