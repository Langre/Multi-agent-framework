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
        private IAddAgentSignal addASignal;

        public Shelf(IAddAgentSignal addASignal)
        {
            Catalog = new List<AgentInfoCard>();
            this.addASignal = addASignal;
        }
        public void RegistrateAgent(AbstractAgent NewAgent)
        {
            try
            {
                if (NewAgent.GetID != String.Empty && !Catalog.Exists(agent => agent.GetAgentsID == NewAgent.GetID))
                {
                    Catalog.Add(new AgentInfoCard(NewAgent));
                    addASignal.AddNewAgentToAll(NewAgent);                    
                }
                else
                    throw new Exception();
            }
            catch
            {
                //сделать обработку
            }
        }

        public void RemoveAgent(String DeadAgent)
        {
            try
            {
                if (DeadAgent != String.Empty && Catalog.Exists(agent => agent.GetAgentsID == DeadAgent))
                    Catalog.RemoveAll(card => card.GetAgentsID == DeadAgent);
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
        public List<String> ProvideInfo(String IDofAskedAgent, List<String> ServicesQuery)
        {
           AgentInfoCard agentWhoAsked = Catalog.SingleOrDefault(agent => agent.GetAgentsID == IDofAskedAgent);
           List<String> suitableAgents = new List<String>();
           foreach(var agentCard in Catalog)
           {
               if (agentCard != agentWhoAsked)
               {
                   if(agentCard.GetServices.All(service => ServicesQuery.Contains(service)) && agentCard.GetLanguages.Intersect(agentWhoAsked.GetLanguages).Any())
                       suitableAgents.Add(agentCard.GetAgentsID); 
               }
           }
                     
            return suitableAgents;
        }    
    }
}
