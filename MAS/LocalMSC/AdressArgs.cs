using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.LocalMSC
{
    /// <summary>
    /// Аргумент события отправки/получения сообщений, который обозначаеь адрес получателя/отправителя.
    /// </summary>
    public class AdressArgs : EventArgs
    {
        /// <summary>
        /// ID агента-адресата.
        /// </summary>
        private String ID;
        public AdressArgs(String ID)
        {
            this.ID = ID;
        }

        /// <summary>
        /// Возвращает ID агента-адресата.
        /// </summary>
        public String GetID { get { return ID; } }
    }
}
