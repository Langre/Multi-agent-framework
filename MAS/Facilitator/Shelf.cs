using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.Linq;

using MAS.AgentConstruct;
using MAS.LocalMSC;
using MAS.Ontology;

namespace MAS.Facilitator
{
    class Shelf : IFacilitator
    {
        /// <summary>
        /// Каталог с видами агентов.
        /// </summary>
        private List<AgentInfoCard> Catalog;
        private IAgentStateObserver Notifier;
        private static Shelf instance;

        private Shelf(IAgentStateObserver Notifier)
        {
            Catalog = new List<AgentInfoCard>();
            this.Notifier = Notifier;
        }

        public static Shelf GetInstance(IAgentStateObserver Notifier)
        {
            if (instance == null)
                lock (typeof(Shelf)) // обязательность выполнения блока для исключения создание блока при многопоточности
                    instance = new Shelf(Notifier);
            return instance;
        }

        public IAgentStateObserver GetNotifier { get { return Notifier; } }

        public void RegistrateAgent(AbstractAgent NewAgent)
        {
            try
            {
                if (NewAgent.GetID != String.Empty && !Catalog.Exists(agent => agent.GetAgentsID == NewAgent.GetID))
                {                    
                    Catalog.Add(new AgentInfoCard(NewAgent));                    
                    NewAgent.SendQuery += this.ProvideInfo;
                    NewAgent.TellAboutDeath += RemoveAgent;
                    Notifier.ThrowNewAgentSignal(NewAgent);
                }
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        public void RemoveAgent(DeadAgentArgs DeadAgent)
        {
            try
            {
                if (DeadAgent.GetDeadAgent != String.Empty && Catalog.Exists(agent => agent.GetAgentsID == DeadAgent.GetDeadAgent))
                {
                    Catalog.RemoveAll(card => card.GetAgentsID == DeadAgent.GetDeadAgent);
                    Notifier.ThrowDeadAgentSignal(DeadAgent);
                }
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        /// <summary>
        /// Поиск агентов по заданным параметрам
        /// </summary>
        /// <param name="QueryParameters">Парпметры для поиска</param>
        /// <returns>Список найденных агентов</returns>
        public List<String> ProvideInfo(QueryAgentArgs QueryParams)
        {
           AgentInfoCard agentWhoAsked = Catalog.SingleOrDefault(agent => agent.GetAgentsID == QueryParams.GetIDOfAskedAgent);
           List<String> suitableAgents = new List<String>();
           foreach(var agentCard in Catalog)
           {
               if (agentCard != agentWhoAsked)
               {
                   if (agentCard.GetServices.All(service => QueryParams.GetQueryServices.Contains(service)) && agentCard.GetLanguages.Intersect(agentWhoAsked.GetLanguages).Any()
                                                                                     && agentCard.GetOntologies.All(ontology => QueryParams.GetQueryOntologies.Contains(ontology)))
                       suitableAgents.Add(agentCard.GetAgentsID); 
               }
           }

           return suitableAgents;
        }    
    }
}
