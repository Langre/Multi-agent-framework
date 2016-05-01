using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using MAS.LocalMSC;
using MAS.Facilitator;

namespace MAS.AgentConstruct
{
    public delegate List<String> QueryToFacilitator<QueryAgentArgs>(QueryAgentArgs QAArg);
    public delegate void DeathSignal<DeadAgentArgs>(DeadAgentArgs DAArgs);
    public abstract class AbstractAgent
    {
        private string ID;
        /// <summary>
        /// ID агента в системе. 
        /// </summary>   
        public String GetID { get { return ID; } }

        /// <summary>
        /// Список поведений.
        /// </summary>
        private List<AbstractBehaviour> poolOfBehaviours;

        #region Данные_об_агенте
        /// <summary>
        /// Список онтологий, с которыми работает агент.
        /// </summary>
        public List<String> Ontologies { get; set; }
        /// <summary>
        /// Список протоколов, при помощи которых общается агент.
        /// </summary>
        public List<String> Protocols { get; set; }
        /// <summary>
        /// Список услуг, которые предоставляет агент.
        /// </summary>
        public List<String> Services { get; set; }
        /// <summary>
        /// Список языков, которые знает агент.
        /// </summary>
        public List<String> Languages { get; set; }        
        #endregion

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman PersonalPostman;

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman GetPostman { get { return PersonalPostman; } }       

        /// <summary>
        /// Для отправление запросов на получение информации о нужных агентах посреднику.
        /// </summary>
        public event QueryToFacilitator<QueryAgentArgs> SendQuery;
        /// <summary>
        /// Для того, чтобы сообщить об удалении агента
        /// </summary>
        public event DeathSignal<DeadAgentArgs> TellAboutDeath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">Идентификатор агента.</param>
        public AbstractAgent(String ID) 
        {
            this.ID = ID;
            poolOfBehaviours = new List<AbstractBehaviour>();
            Ontologies = new List<String>();
            Protocols = new List<String>();
            Services = new List<String>();
            Languages = new List<String>();
        }

        /// <summary>
        /// Вызов события о запросе к посреднику.
        /// </summary>
        protected virtual List<string> SiganlLookForAgent(List<String> Services)
        {
            return this.SendQuery(new QueryAgentArgs(this.ID, Services, this.Ontologies, this.Languages));
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID">Идентификатор агента.</param>
        /// <param name="Postman">Служба доставки сообщений.</param>
        /// <param name="DS">Компоненты, которые нужно уведомить при удалении.</param>
        /// <param name="Behaviours">Список поведений.</param>
        public AbstractAgent(String ID, List<AbstractBehaviour> Behaviours)
        {
            this.ID = ID;
            poolOfBehaviours = new List<AbstractBehaviour>(Behaviours);
            Ontologies = new List<String>();
            Protocols = new List<String>();
            Services = new List<String>();
            Languages = new List<String>();           
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
                if (poolOfBehaviours.FindAll(b => b.GetName == NewB.GetName).Count == 0)
                    poolOfBehaviours.Add(NewB);
                else throw new Exception();
            }
            catch
            {                
                 // сделать обработку  
            }
        }

        /// <summary>
        /// Удаляет поведение из дерева поведений.
        /// </summary>
        /// <param name="Name">Идентефикатор поведения.</param>
        public void DeleteBehaviour(String Name) 
        {
            poolOfBehaviours.Remove(poolOfBehaviours.Where(b => b.GetName == Name).First());
        }

        /// <summary>
        /// Главный цикл агента.
        /// </summary>
        public abstract void Execute();
        /// <summary>
        /// Остановка работы компонента и удаление его из памяти.
        /// </summary>
        public void Suicide()
        {
            TellAboutDeath(new DeadAgentArgs(this.GetID));
        }
    }
}
