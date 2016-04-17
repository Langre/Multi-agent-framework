using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.LocalMSC
{
    public delegate void ToPost<MessageArgs>(MessageArgs Arg);
    public delegate Message CheckPost<RecieverAdress>(RecieverAdress ID);

    public interface IServicePostman
    {
        /// <summary>
        /// Событие отправки сообщения.
        /// </summary>
        event ToPost<MessageArgs> SendLetter;    //для обмена сообщениями с почтой
        /// <summary>
        /// Запрос на получение сообщения.
        /// </summary>
        event CheckPost<AdressArgs> SendQuery; //для обмена сообщениями с почтой
        /// <summary>
        /// Отправка со сообщения службе обмена сообщениями.
        /// </summary>
        /// <param name="Letter">Отправляемое сообщение.</param>
        void SendToPost(Message Letter);
        /// <summary>
        /// Получение сообщения.
        /// </summary>
        /// <returns>Сообщение.</returns>
        Message RecieveMessage();
        //void PackMessage(MType Goal, String Sender, String Reciever, String OntologyName, String MessageText);
    }
}
