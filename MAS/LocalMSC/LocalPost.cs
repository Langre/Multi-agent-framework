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
        /// Почтовые ящики агентов.
        /// </summary>
        private Dictionary<String, Queue<Message>> Boxes;
        private static LocalPost instance; //для синглтона

        private LocalPost()
        {
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

        public void AddClient(AbstractAgent NewCustomer)
        {
            try
            {
                if (!Boxes.ContainsKey(NewCustomer.GetID))
                {
                    Boxes.Add(NewCustomer.GetID, new Queue<Message>());
                    NewCustomer.GetPostman.SendLetter += new ToPost<MessageArgs>(IntoBox);
                    NewCustomer.GetPostman.SendQuery += new CheckPost<AdressArgs>(GiveMessage);
                }
                else
                    throw new Exception(); //доработать исключение
            }
            catch
            {
                //сделать обработку
            }
        }

        public void RemoveClient(string AgentID)
        {
            Boxes.Remove(AgentID);
        }

        /// <summary>
        /// Помещает сообщение в очередь сообщений для агента-адресата.
        /// </summary>
        /// <param name="Customer">Кто отправил сообщение.</param>
        /// <param name="Adressee">Кто получил сообщение.</param>
        public void IntoBox(MessageArgs Adressee) //помещает сообщения в очередь сообщений для конкретного агента
        {
            try
            {
                if (Boxes.ContainsKey(Adressee.TheLetter.GetReciever))
                    Boxes[Adressee.TheLetter.GetReciever].Enqueue(Adressee.TheLetter);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        /// <summary>
        /// Отправляет агенту первое сообщение в очереди.
        /// </summary>
        /// <param name="Customer">Агент, который послал запрос.</param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Message GiveMessage(AdressArgs ID) //отправляет сообщение, когда агент проверяет почту
        {
            if (Boxes[ID.GetID].Count != 0)
                return Boxes[ID.GetID].Dequeue();
            else
                return new Message();
        }
    }
}
