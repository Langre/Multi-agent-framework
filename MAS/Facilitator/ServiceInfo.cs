using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAS.Facilitator
{
    class ServiceInfo
    {
        private string NameService;       
        private string TypeService;
        private string OwnerService;
        /// <summary>
        /// Название услуги.
        /// </summary>
        public string Name { get { return NameService; } }
        /// <summary>
        /// Тип услуги.
        /// </summary>
        public string Type { get { return Type; } }
        /// <summary>
        /// Идентефикатор "владельца"-агента.
        /// </summary>
        public string Owener { get { return OwnerService; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name">Название услуги.</param>
        /// <param name="Owner">Идентификатор "владельца"-агента.</param>
        /// <param name="Type">Тип услуги.</param>
        public ServiceInfo(string Name, string Owner, string Type)
        {
            NameService = Name;
            TypeService = Type;
            OwnerService = Owner;
        }
    }
}
