using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    public abstract class AbstractBehaviour
    {
        /// <summary>
        /// Идентефикатор поведения.
        /// </summary>
        protected String id;
        /// <summary>
        /// Значение идентефикатора поведения.
        /// </summary>
        public String ID { get { return id; } }

        /// <summary>
        /// Агент-хозяин.
        /// </summary>
        public AbstractAgent Host;
        /// <summary>
        /// Возвращает агента-хозяина.
        /// </summary>
        public AbstractAgent GetHost { get { return Host; } }

        protected Task execute; // для параллельнной работы

        public AbstractBehaviour(String ID, AbstractAgent Host)
        {
            this.id = ID;
            this.Host = Host;
            execute = new Task(() => JobDoing(), TaskCreationOptions.AttachedToParent);           
        }
        /// <summary>
        /// Алгоритм поведения.
        /// </summary>
        /// <returns>Результат выполнения поведения.</returns>
        public abstract dynamic JobDoing(); 
    }
}

