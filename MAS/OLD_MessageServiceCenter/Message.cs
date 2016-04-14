using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Messaging;

namespace MAS.OLD_MessageServiceCenter
{
    public class Message
    {
        private String SenderID;
        private String RecieverID;
        //public Somestructure Content;

        public Message(String SednerID, String RecieverID) //Somestructure Content
        {
            this.SenderID = SenderID;
            this.RecieverID = RecieverID;
        }

        public String GetSenderID { get { return SenderID; } }
        public String GetRecieverID { get { return RecieverID; } }
    }
}
