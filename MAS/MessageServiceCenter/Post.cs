using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MAS.MessageServiceCenter
{
    class Post
    {
        public Uri Adress { get; set; }
        private BasicHttpBinding Way;
        private Type Contract;
        private ServiceHost Host;

        public Post(Uri Adress)
        {
            this.Adress = Adress;
            Way = new BasicHttpBinding();
            Contract = typeof(IContract);

            Host = new ServiceHost(typeof(MessageService));
            Host.AddServiceEndpoint(Contract, Way, Adress);
        }

        public void Open()
        {
            Host.Open(); // начало ожидания прихода сообщений
        }

        public void Close()
        {
            Host.Close(); //завершение ожидания прихода сообщений
        }
    }
}
