using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;

using MAS.AgentConstruct;
using MAS.LocalMSC;

namespace MAS
{
    class OntologyReader : AbstractAgent
    {
        private OntModel Ontology;
        private OntDocumentManager File;
        private String Source;

        public OntologyReader(String ID, String Source) : base(ID) { this.Source = Source; GetOntology(); }
        public OntologyReader(String ID, String Source, AbstractBehaviour NewB) : base(ID, NewB) { this.Source = Source; GetOntology(); }

        public void GetOntology()
        {
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM);
            File = Ontology.getDocumentManager();
            File.addAltEntry(Source, "file:" + "C:/Users/Serega/Desktop/MAS/SpaceWorld.owl");
            Ontology.read(Source, "RDF/XML");
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM_MICRO_RULE_INF, Ontology);
        }

        public override void Execute()
        {                      
            try
            {

            }
            catch
            {
                Console.WriteLine("Ooops");
            }
        }

        private String CutOff(String ShouldBeShorter)
        {
            if (ShouldBeShorter.Contains("^^"))
                ShouldBeShorter = ShouldBeShorter.Remove(ShouldBeShorter.IndexOf("^^"));
            return ShouldBeShorter;
        }        
    }
}
