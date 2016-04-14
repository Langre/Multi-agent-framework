using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.ControlManager
{
    public class FieldAttribute : Attribute 
    {
        public string Name { get; set; }
        public FieldAttribute(string Name)
        {
            this.Name = Name;
        }
    }
}
