using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.LocalMSC
{
    /// <summary>
    /// Интерфейс для службы обмена сообщениями.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Помещает сообщения в стек сообщений для конкретного агента.
        /// </summary>
        /// <param name="Adressee">какая-то фигня?</param>
        void IntoBox(MessageArgs Adressee); 
        /// <summary>
        /// Отсылает сообщение агенту, отправившему запрос.
        /// </summary>
        /// <param name="ID">ID адресата.</param>
        /// <returns>Сообщение.</returns>
        Message GiveMessage(AdressArgs ID); 
    }
}
