using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MAS.LocalMSC
{
    public class Message
    {
        private String SenderID;
        private String RecieverID;
        String Content;

        private bool IsDummy;

        public Message() 
        { 
            IsDummy = true;
        }
        public Message(String SenderID, String RecieverID, String Content)
        {
            this.SenderID = SenderID;
            this.RecieverID = RecieverID;
            this.IsDummy = false;
            this.Content = Content;
        }

        public bool CheckDummy { get { return IsDummy; } }
        public String GetSender { get { return SenderID; } }
        public String GetReciever { get { return RecieverID; } }
        public String GetContent { get { return Content; } }
    }
}
