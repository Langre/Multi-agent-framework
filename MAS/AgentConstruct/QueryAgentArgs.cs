using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    public class QueryAgentArgs : EventArgs
    {
        private String IDOfAskedAgent;
        private List<String> QueryLanguages;
        private List<String> QueryOntologies;
        private List<String> QueryServices;

        public String GetIDOfAskedAgent { get { return IDOfAskedAgent; } }
        public List<String> GetQueryOntologies { get { return QueryOntologies; } }
        public List<String> GetQueryLanguages { get { return QueryLanguages; } }
        public List<String> GetQueryServices { get { return QueryServices; } }
        public QueryAgentArgs(String IDOfAskedAgent, List<String> QueryServices, List<String> QueryOntologies, List<String> QueryLanguages)
        {
            this.IDOfAskedAgent = IDOfAskedAgent;
            this.QueryServices = QueryServices;
            this.QueryOntologies = QueryOntologies;
            this.QueryLanguages = QueryLanguages;
        }
    }
}
