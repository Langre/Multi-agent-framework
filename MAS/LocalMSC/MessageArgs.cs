using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.LocalMSC
{
    /// <summary>
    /// Аргумент события для передачи сообщения.
    /// </summary>
    public class MessageArgs : EventArgs
    {
        private Message Letter;
        public MessageArgs(Message Letter)
        {
            this.Letter = Letter;
        }

        public Message TheLetter { get { return Letter; } }
    }
}
