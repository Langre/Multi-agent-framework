using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;
using com.hp.hpl.jena.query;
using com.hp.hpl.jena.util.iterator;
using com.hp.hpl.jena.datatypes;

namespace MAS.OntologyReader
{
    public class OntReader
    {
        private OntModel Ontology;
        private OntDocumentManager File;
        private String Source;
        private List<String> Classes;
        private List<Individual> Ret;

        public OntReader(String Source) { this.Source = Source; GetOntology(); }

        public void GetOntology()
        {
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM);
            File = Ontology.getDocumentManager();
            File.addAltEntry(Source, "file:" + "C:/Users/Serega/Desktop/MAS/SpaceWorld.owl");
            Ontology.read(Source, "RDF/XML");
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM_MICRO_RULE_INF, Ontology);

            Classes = new List<String>();
            ExtendedIterator i = Ontology.listClasses();
            while (i.hasNext())
            {
                OntClass temp = (OntClass)i.next();
                Classes.Add(temp.getURI());
            }
        }      

        public void Provide(String TypeName)
        {
            Ret = new List<Individual>(); 

            String sparqlQuery = "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                                 "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                                 "PREFIX owl: <http://www.w3.org/2002/07/owl#> " + 
                                 "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
                                 "SELECT ?ind " +
                                 "WHERE { ?ind a " + TypeName + " }";
            Query demand = QueryFactory.create(sparqlQuery);
            QueryExecution d0 = QueryExecutionFactory.create(demand, Ontology);
            ResultSet done = d0.execSelect();
            while (done.hasNext())
            {
                QuerySolution row = done.next();
                Resource R = row.getResource("?ind");
                if (R.isURIResource())
                    Ret.Add(Ontology.getIndividual(R.toString()));
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
