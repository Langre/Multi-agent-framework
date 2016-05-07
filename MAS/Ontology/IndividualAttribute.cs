using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Ontology
{
    public class IndividualAttribute : Attribute
    {
        /// <summary>
        /// Название атрибута класса агента в онтологии.
        /// </summary>
        public string Name { get; set; }
        public IndividualAttribute(string Name)
        {
            this.Name = Name;
        }

        public IndividualAttribute() { }
    }
}
