using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading.Tasks;

using MAS.LocalMSC;

namespace MAS.AgentConstruct
{
    
    public abstract class AbstractAgent
    {
        /// <summary>
        /// ID агента в системе. 
        /// </summary>   
        public abstract String GetID { get; }
        public Dictionary<String, AbstractBehaviour> PoolOfBehaviours; // заменить словарь на гребаное ДЕРЕВО
        public Dictionary<String, AbstractBehaviour> Behaviours { get { return PoolOfBehaviours; } }

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman PersonalPostman;
        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman GetPostman { get { return PersonalPostman; } }

        protected Task execute; //для параллеьной работы агента

        public AbstractAgent() 
        {
            PoolOfBehaviours = new Dictionary<string, AbstractBehaviour>();        
        }        

        /// <summary>
        /// Ставит в соответсвие агенту службу обмена сообщениями с почтой. 
        /// </summary>
        /// <param name="PersonalPostman">Служба обмена сообщениями между агентом и почтой.</param>
        public void SetPostman(IServicePostman PersonalPostman)
        {
            this.PersonalPostman = PersonalPostman;
        }

        /// <summary>
        /// Добавляет поведение в дерево поведений.
        /// </summary>
        /// <param name="ID">Идентефикатор поведения.</param>
        /// <param name="NewB">Поведение.</param>
        public void AddBehaviour(String ID, AbstractBehaviour NewB)
        {
            PoolOfBehaviours.Add(ID, NewB);
        }

        /// <summary>
        /// Удаляет поведение из дерева поведений.
        /// </summary>
        /// <param name="ID">Идентефикатор поведения.</param>
        public void DeleteBehaviour(String ID) 
        {
            PoolOfBehaviours.Remove(ID);
        }

        /// <summary>
        /// Главный цикл агента.
        /// </summary>
        public abstract void Execute();
    }
}
