using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using MAS.AgentConstruct;
using MAS.LocalMSC;
using MAS.Facilitator;
using MAS.Ontology;

namespace MAS
{
    class AgentA : AbstractAgent
    {
        public AgentA(String ID, List<AbstractBehaviour> B)
            : base(ID, B)
        { }

        public override void Execute()
        {
            string gotID = this.SiganlLookForAgent(new List<String>() { "answer" }).First();
            PersonalPostman.SendToPost(new Message(this.GetID, gotID, "param pam"));
            this.Suicide();
        }
    }

    class AgentB : AbstractAgent
    {
        public AgentB(String ID, List<AbstractBehaviour> B)
            : base(ID, B)
        { }

        public override void Execute()
        {
            String r = PersonalPostman.RecieveMessage().GetContent;
        }
    }

    class SpacemanIndiv
    {
        [IndividualAttribute("IDMan")]
        public String ID { get; set; }
        [IndividualAttribute("Name")]
        public String Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Notifier n = new Notifier();
            //IMessageService Post = LocalPost.GetInstance();
            //n.AddObserverComponent(Post as IObserverAgentComponent);
            //IFacilitator Shelf = Shelf.GetInstance(n);

            //AbstractAgent aA = new AgentA("AgentA", new List<AbstractBehaviour>());
            //AbstractAgent aB = new AgentB("AgentB", new List<AbstractBehaviour>());
            //aA.SetPostman(new DefaultPostman(aA));
            //aA.Ontologies.Add("some");
            //aA.Languages.Add("someLang");
            //aA.Services.Add("ask");
            //aB.SetPostman(new DefaultPostman(aB));
            //aB.Ontologies.Add("some");
            //aB.Languages.Add("someLang");
            //aB.Services.Add("answer");
            //Shelf.RegistrateAgent(aA);
            //Shelf.RegistrateAgent(aB);

            //aA.Execute();
            //aB.Execute();

            OntologyReader reader = new OntologyReader();
            reader.Source = @"D:\Multi-agent framework\MAS\SpaceWorld.owl";
            reader.GetOntology(@"D:\Multi-agent framework\MAS\SpaceWorld.owl");
            reader.GetSpecificIndividuals("MAS.SpacemanIndiv", "PREFIX rdfr:<http://www.semanticweb.org/serega/ontologies/2015/6/SpaceWorld#> " +
                                                           "SELECT ?ind " +
                                                           "WHERE { ?ind a rdfr:" + "Spaceman" + " } ");
        }
    }
}
