using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MAS.AgentConstruct
{
    public abstract class AbstractBehaviour
    {        
        private String Name;

        /// <summary>
        /// Название поведения.
        /// </summary>
        public String GetName { get { return Name; } }

        /// <summary>
        /// Список подповедений.
        /// </summary>
        private List<AbstractBehaviour> poolOfSubBehaviours;

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
            poolOfSubBehaviours = new List<AbstractBehaviour>();
        }

        /// <summary>
        /// Добавляет поведение в дерево поведений.
        /// </summary>
        /// <param name="NewB">Поведение.</param>
        public void AddSubBehaviour(AbstractBehaviour NewB)
        {
            try
            {
                if (poolOfSubBehaviours.FindAll(b => b.GetName == NewB.GetName).Count == 0)
                    poolOfSubBehaviours.Add(NewB);
                else throw new Exception();
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

