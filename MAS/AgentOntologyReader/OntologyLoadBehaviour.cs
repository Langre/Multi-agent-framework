using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;

using MAS.AgentConstruct;

namespace MAS
{
    class OntologyLoadBehavior : AbstractBehaviour
    {        
        private OntDocumentManager File;
        private OntModel Ontology;
        private String Source;

        public OntologyLoadBehavior(String ID, String Source, AbstractAgent HostAgent) 
            : base(ID, HostAgent)
        {
            this.Source = Source;
        }

        public override void Do()
        {            
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM);
            File = Ontology.getDocumentManager();
            File.addAltEntry(Source, "file:" + "C:/Users/Serega/Desktop/MAS/SpaceWorld.owl");
            Ontology.read(Source, "RDF/XML");
            OntModel Reasoner = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM_MICRO_RULE_INF, Ontology);
        }

        public override dynamic SendData()
        {
            return Ontology;
        }
    }
}
