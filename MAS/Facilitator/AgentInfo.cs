using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Facilitator
{
    class AgentInfo
    {
        private string agentName;
        /// <summary>
        /// Идентефикатор зарегистрированного агента.
        /// </summary>
        public string AgentName { get { return agentName; } }
        /// <summary>
        /// Поддерживаемые протоколы взаимодействия.
        /// </summary>
        public List<string> Protocols { get; set; }
        /// <summary>
        /// Онтологии, с которыми может работать агент.
        /// </summary>
        public List<string> Ontologies { get; set; }
        /// <summary>
        /// Языки взаимодействия, которые знает агент.
        /// </summary>
        public List<string> Languages { get; set; }
        /// <summary>
        /// Список услуг, которые может выполнить агент.
        /// </summary>
        public List<ServiceInfo> Services { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AgentName">Идентификатор агента</param>
        public AgentInfo(string AgentName)
        {
            agentName = AgentName;
            Protocols = new List<string>();
            Ontologies = new List<string>();
            Languages = new List<string>();
            Services = new List<ServiceInfo>();
        }
    }
}
