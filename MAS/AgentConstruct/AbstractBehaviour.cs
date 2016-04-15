using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.AgentConstruct
{
    public abstract class AbstractBehaviour
    {        
        private String Name;

        /// <summary>
        /// Название поведения.
        /// </summary>
        public String GetName { get { return Name; } }
        public List<AbstractBehaviour> poolOfBehaviours;
        /// <summary>
        /// Агент-хозяин.
        /// </summary>
        public AbstractAgent Host;

        /// <summary>
        /// Возвращает агента-хозяина.
        /// </summary>
        public AbstractAgent GetHost { get { return Host; } }
        
        public AbstractBehaviour(String Name, AbstractAgent Host)
        {
            this.Name = Name;
            this.Host = Host;
            poolOfBehaviours = new List<AbstractBehaviour>();
        }

        /// <summary>
        /// Добавляет поведение в дерево поведений.
        /// </summary>
        /// <param name="NewB">Поведение.</param>
        public void AddBehaviour(AbstractBehaviour NewB)
        {
            try
            {
                if (poolOfBehaviours.FindAll(b => b.GetName == NewB.GetName).Count > 0)
                    poolOfBehaviours.Add(NewB);
            }
            catch
            {
                // сделать обработку  
            }
        }

        /// <summary>
        /// Алгоритм поведения.
        /// </summary>
        /// <returns>Результат выполнения поведения.</returns>
        public abstract void DoJob(); 
    }
}

