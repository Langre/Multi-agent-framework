using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    public class AgentAttribute : Attribute 
    {
        /// <summary>
        /// Название атрибута класса агента в онтологии.
        /// </summary>
        public string Name { get; set; }
        public AgentAttribute(string Name)
        {
            this.Name = Name;
        }

        public AgentAttribute() { }
    }
}
