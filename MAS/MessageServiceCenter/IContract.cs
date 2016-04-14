using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MAS.MessageServiceCenter
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        void GetMessage(Message Input);

        [OperationContract]
        void SendMessage();
    }
}
