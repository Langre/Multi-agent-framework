using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MAS.AgentConstruct;

namespace MAS.Facilitator
{
    class AgentInfoCard
    {
        private String AgentsID;
        private List<String> Ontologies;
        private List<String> Protocols;
        private List<String> Services;
        private List<String> Languages;

        public String GetAgentsID { get { return AgentsID; } }
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
        /// Языки, которые знает агент.
        /// </summary>
        public ReadOnlyCollection<String> GetLanguages { get { return Languages.AsReadOnly(); } }

        /// <summary>
        /// Конструкторс агентом.
        /// </summary>
        /// <param name="Agent">Агент, которому нужно сделать карточку.</param>
        public AgentInfoCard(AbstractAgent Agent)
        {
            this.AgentsID = Agent.GetID;
            this.Languages = new List<String>(Agent.GetLanguages);
            this.Ontologies = new List<String>(Agent.GetOntologies);
            this.Protocols = new List<String>(Agent.GetProtocols);
            this.Services = new List<String>(Agent.GetServices);
        }
    }
}
