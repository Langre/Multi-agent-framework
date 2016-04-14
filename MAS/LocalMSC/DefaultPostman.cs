using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.LocalMSC
{
    class DefaultPostman : IServicePostman
    {
        /// <summary>
        /// "Хозяин" службы-почтальона.
        /// </summary>
        private AbstractAgent Host;
        /// <summary>
        /// Возвращает агента-хозяина службы.
        /// </summary>
        public AbstractAgent GetHost { get { return Host; } }

        /// <summary>
        /// Текущее сообщение для доставки.
        /// </summary>   
        //private Message currentPackage;

        public event ToPost<MessageArgs> SendLetter;    //для обмена сообщениями с почтой
        public event CheckPost<AdressArgs> SendQuery; //для обмена сообщениями с почтой


        public DefaultPostman(AbstractAgent Host)
        {
            this.Host = Host;
        }

        /// <summary>
        /// Получение сообщения от почты
        /// </summary>
        /// <returns></returns>
        public Message RecieveMessage()
        {
            return SendQuery(new AdressArgs(Host.GetID)); //выполнение запроса
        }

        /// <summary>
        /// Отправка сообщения почте.
        /// </summary>
        /// <param name="Letter">Отправляемое сообщение.</param>
        public void SendToPost(Message Letter)
        {
            SendLetter(Host, new MessageArgs(Letter));
        }

       // public void PackMessage(MType Goal, String Sender, String Reciever, String OntologyName, String MessageText)
       // {
       //     String Content = "Hello";
       //     currentPackage = new Message(Sender, Reciever, Content);
       // }
    }
}
