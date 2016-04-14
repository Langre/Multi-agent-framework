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
        /// Добавить пользователя(агента).
        /// </summary>
        /// <param name="NewCustomer">Новый пользователь.</param>
        void AddClients(AbstractAgent NewCustomer);

        /// <summary>
        /// Помещает сообщения в стек сообщений для конкретного агента.
        /// </summary>
        /// <param name="Customer">Агент??</param>
        /// <param name="Adressee">какая-то фигня?</param>
        void IntoBox(AbstractAgent Customer, MessageArgs Adressee); 

        /// <summary>
        /// Отсылает сообщение агенту, отправившему запрос.
        /// </summary>
        /// <param name="Customer">Агент-получатель</param>
        /// <param name="ID">ID адресата.</param>
        /// <returns></returns>
        Message GiveMessage(AdressArgs ID); 
    }
}
