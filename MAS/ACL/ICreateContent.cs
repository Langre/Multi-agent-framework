using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.ACL
{
    interface ICreateContent
    {
        String ChooseContent(String protocol);
        String ChooseTerm(String OntologyTerm);
        String FillContentWithData();
    }
}
