using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAS.AgentConstruct;

namespace MAS.LocalMSC
{
    public class LocalPost : IMessageService
    {
        /// <summary>
        /// Список подключеннных агентов.
        /// </summary>
        private Dictionary<String, AbstractAgent> Users;
        /// <summary>
        /// Почтовые ящики агентов.
        /// </summary>
        private Dictionary<String, Queue<Message>> Boxes;
        private static LocalPost instance; //для синглтона

        private LocalPost()
        {
            Users = new Dictionary<string, AbstractAgent>();
            Boxes = new Dictionary<string, Queue<Message>>();
        }

        /// <summary>
        /// Инициализация почты.
        /// </summary>
        /// <returns>Экземпляр почты.</returns>
        public static LocalPost GetInstance()
        {
            if (instance == null)
                lock (typeof(LocalPost)) // обязательность выполнения блока для исключения создание блока при многопоточности
                    instance = new LocalPost();
            return instance;
        }
        
        /// <summary>
        /// Добавление агента.
        /// </summary>
        /// <param name="NewCustomer">Экземпляр агента.</param>
        public void AddClients(AbstractAgent NewCustomer)
        {
            Users.Add(NewCustomer.GetID, NewCustomer); 
            NewCustomer.GetPostman.SendLetter += new ToPost<MessageArgs>(IntoBox);
            NewCustomer.GetPostman.SendQuery += new CheckPost<AdressArgs>(GiveMessage);
            Boxes.Add(NewCustomer.GetID, new Queue<Message>());
        }

        /// <summary>
        /// Помещает сообщение в очередь сообщений для агента-адресата.
        /// </summary>
        /// <param name="Customer">Кто отправил сообщение.</param>
        /// <param name="Adressee">Кто получил сообщение.</param>
        public void IntoBox(AbstractAgent Customer, MessageArgs Adressee) //помещает сообщения в стек сообщений для конкретного агента
        {
            if (Users.ContainsKey(Adressee.TheLetter.GetReciever))
                {
                    Boxes[Adressee.TheLetter.GetReciever].Enqueue(Adressee.TheLetter);
                }
            else
                Console.WriteLine("No such agent {0}", Adressee);
        }

        /// <summary>
        /// Отправляет агенту первое сообщение в очереди.
        /// </summary>
        /// <param name="Customer">Агент, который послал запрос.</param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Message GiveMessage(AdressArgs ID) //отправляет сообщение, когда агент проверяет почту
        {
            if (Users.ContainsKey(ID.GetID))
            {
                if (Boxes[ID.GetID].Count != 0)
                    return Boxes[ID.GetID].Dequeue();
                else
                {
                    Console.WriteLine("Box is empty");
                    return new Message();
                }
            }
            else
            {
                Console.WriteLine("No such agent");
                return new Message();
            }
        }
    }
}
