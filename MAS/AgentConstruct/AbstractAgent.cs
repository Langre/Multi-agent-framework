using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using MAS.LocalMSC;

namespace MAS.AgentConstruct
{
    
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
        private List<String> Languages;
        private List<String> Ontologies;
        private List<String> Protocols;
        private List<String> Services;

        /// <summary>
        /// Список онтологий, с которыми работает агент.
        /// </summary>
        public ReadOnlyCollection<String> GetOntologies { get { return Ontologies.AsReadOnly(); } }
        /// <summary>
        /// Список протоколов, при помощи которых общается агент.
        /// </summary>
        public ReadOnlyCollection<String> GetProtocols { get { return Protocols.AsReadOnly(); } }
        /// <summary>
        /// Список услуг, которые предоставляет агент.
        /// </summary>
        public ReadOnlyCollection<String> GetServices { get { return Services.AsReadOnly(); } }
        /// <summary>
        /// Список языков, которые знает агент.
        /// </summary>
        public ReadOnlyCollection<String> GetLanguages { get { return Languages.AsReadOnly(); } }

        /// <summary>
        /// Добавляет онтологию к списку онтологий
        /// </summary>
        /// <param name="OntologyCode">Название или адрес онтологии</param>
        public void AddOntology(String OntologyCode)
        {
            try
            {
                if (!Ontologies.Contains(OntologyCode))
                    Ontologies.Add(OntologyCode);
                else
                    throw new Exception();
            }
            catch 
            {
                //сделать обработку
            }
            
        }

        /// <summary>
        /// Добавляет новый протокол общения.
        /// </summary>
        /// <param name="NewProtocol"></param>
        public void AddProtocol(String NewProtocol)
        {
            try
            {
                if (!Protocols.Contains(NewProtocol))
                    Protocols.Add(NewProtocol);
                else
                    throw new Exception();
            }
            catch 
            {
                //сделать обработку
            }
        }

        /// <summary>
        /// Добавить услугу.
        /// </summary>
        /// <param name="NewService">Тип услуги.</param>
        public void AddSecvice(String NewService)
        {
            try
            {
                if (!Services.Contains(NewService))
                    Services.Add(NewService);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }            
        }

        /// <summary>
        /// Добавить язык.
        /// </summary>
        /// <param name="NewLanguage">Название языка.</param>
        public void AddLanguage(String NewLang)
        {
            try
            {
                if (!Languages.Contains(NewLang))
                    Languages.Add(NewLang);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        /// <summary>
        /// Добавить несколько онтологий.
        /// </summary>
        /// <param name="OntologiesCodes">Названия или адреса онтологий</param>
        public void AddOntology(List<String> OntologiesCodes)
        {
            try
            {
                if (Ontologies.Intersect(OntologiesCodes).ToList().Count == 0)
                    Ontologies.Concat(OntologiesCodes);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }           
        }

        /// <summary>
        /// Добавить несколько протоколов общения.
        /// </summary>
        /// <param name="NewProtocols">Список новых протоколов.</param>
        public void AddProtocol(List<String> NewProtocols)
        {
            try
            {
                if (Protocols.Intersect(NewProtocols).ToList().Count == 0)
                    Protocols.Concat(NewProtocols);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        /// <summary>
        /// Добавить несколько услуг.
        /// </summary>
        /// <param name="NewServices">Список типов услуг, которые может осказывать агент.</param>
        public void AddService(List<String> NewServices)
        {
            try
            {
                if (Services.Intersect(NewServices).ToList().Count == 0)
                    Services.Concat(NewServices);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }    
        }

        /// <summary>
        /// Добавить несколько языков.
        /// </summary>
        /// <param name="NewLangs">Названия языков.</param>
        public void AddLanguges(List<String> NewLangs)
        {
            try
            {
                if (Languages.Intersect(NewLangs).ToList().Count == 0)
                    Languages.Concat(NewLangs);
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }
        #endregion

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman PersonalPostman;

        /// <summary>
        /// Служба передачи сообщения между агентом и почтой.
        /// </summary>
        public IServicePostman GetPostman { get { return PersonalPostman; } }

        private IDeathSignal deathSignal;

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
        /// 
        /// </summary>
        /// <param name="ID">Идентификатор агента.</param>
        /// <param name="Postman">Служба доставки сообщений.</param>
        /// <param name="DS">Компоненты, которые нужно уведомить при удалении.</param>
        /// <param name="Behaviours">Список поведений.</param>
        public AbstractAgent(String ID, IDeathSignal DS, List<AbstractBehaviour> Behaviours)
        {
            this.ID = ID;
            poolOfBehaviours = new List<AbstractBehaviour>(Behaviours);
            Ontologies = new List<String>();
            Protocols = new List<String>();
            Services = new List<String>();
            Languages = new List<String>();
            deathSignal = DS;
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
        /// Сообщает агенту о компонентах, которым нужно сообщить при его удалении.
        /// </summary>
        /// <param name="DS">Сигнал об удалении</param>
        public void SetDeathSignal(IDeathSignal DS)
        {
            this.deathSignal = DS;
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

        public void Suicide()
        {
            deathSignal.SignalAboutDeleting(this.ID);            
        }
    }
}
