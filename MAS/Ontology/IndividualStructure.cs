using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MAS.Ontology
{
    /// <summary>
    /// Хранит данные о сущностях из онтологии
    /// </summary>
    class IndividualStructure
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        string Name;
        /// <summary>
        /// Тип сущности
        /// </summary>
        string Type;
        /// <summary>
        /// Поля сущности.
        /// </summary>
        List<FieldInfo> Fields;  
 
        public IndividualStructure()
        {
            Fields = new List<FieldInfo>();
        }
    }
}
