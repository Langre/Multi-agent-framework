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
        void AddClient(AbstractAgent NewCustomer);
        /// <summary>
        /// Добавить пользователей(агентов).
        /// </summary>
        /// <param name="NewCustomers">Список новых пользователей.</param>
        void AddClients(IEnumerable<AbstractAgent> NewCustomers);
        /// <summary>
        /// Удаление пользователя(агента).
        /// </summary>
        /// <param name="AgentID"></param>
        void RemoveCustomer(string AgentID);
        /// <summary>
        /// Удаление пользоваталей(агентов)
        /// </summary>
        /// <param name="AgentsIDs">Список идентификаторов удаялемых агентов.</param>
        void RemoveCustomers(IEnumerable<string> AgentsIDs);
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
