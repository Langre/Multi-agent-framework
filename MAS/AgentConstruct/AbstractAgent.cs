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
        public string ID;
        /// <summary>
        /// ID агента в системе. 
        /// </summary>   
        public String GetID { get { return ID; } }
        private List<AbstractBehaviour> poolOfBehaviours; // заменить словарь на гребаное ДЕРЕВО
        public List<AbstractBehaviour> Behaviours { get { return poolOfBehaviours; } }

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman PersonalPostman;
        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman GetPostman { get { return PersonalPostman; } }

        public AbstractAgent(string ID) 
        {
            this.ID = ID;
            poolOfBehaviours = new List<AbstractBehaviour>;        
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
        /// <param name="NewB">Поведение.</param>
        public void AddBehaviour(AbstractBehaviour NewB)
        {
            try
            {
                if (poolOfBehaviours.FindAll(b => b.GetName == NewB.GetName).Count > 0)
                    poolOfBehaviours.Add(NewB);
            }
            catch
            {                
                 // сделать обработку  
            }
        }

        /// <summary>
        /// Удаляет поведение из дерева поведений.
        /// </summary>
        /// <param name="ID">Идентефикатор поведения.</param>
        public void DeleteBehaviour(String Name) 
        {
            poolOfBehaviours.Remove(poolOfBehaviours.Where(b => b.GetName == Name).First());
        }

        /// <summary>
        /// Главный цикл агента.
        /// </summary>
        public abstract void Execute();
    }
}
