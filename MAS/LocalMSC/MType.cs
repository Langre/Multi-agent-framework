using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MAS.LocalMSC
{
    public sealed class MType
    {
        private readonly String Name;
        private readonly int Value;

        public static MType QUERY = new MType(1, "QUERY");
        public static MType INFO = new MType(2, "INFO");
        public static MType ACCEPTJOB = new MType(3, "ACCEPTJOB");
        public static MType JOBDONE = new MType(4, "JOBDONE");

        private MType(int Value, String Name)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
