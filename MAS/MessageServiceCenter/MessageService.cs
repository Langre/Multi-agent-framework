using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.MessageServiceCenter
{
    class MessageService : IContract
    {
        public void GetMessage(Message Input)
        {
            Input.GOTYA();
        }

        public void SendMessage()
        {            
        }
    }
}
