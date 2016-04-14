using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.hp.hpl.jena.ontology;
using com.hp.hpl.jena.rdf.model;
using com.hp.hpl.jena.util.iterator;
using com.hp.hpl.jena.query;

using MAS.AgentConstruct;

namespace MAS
{
    class SearchInfo : AbstractBehaviour
    {
        private List<OntClass> List;
        private String Path;
        private OntModel Ontology;
        private String TypeName;

        public SearchInfo(String ID, AbstractAgent Host)
            : base(ID, Host) 
        {
            List = new List<OntClass>();
        }

        public void Provide()
        {
            String SparqlQuery = "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                                 "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                                 "select ?operation " +
                                 "where  { " +
                                 " ?operation rdf:type :" + TypeName + 
                                 " } \n ";
            Query Demand = QueryFactory.create(SparqlQuery);
            QueryExecution Do = QueryExecutionFactory.create(Demand, Ontology);
            ResultSet Done = Do.execSelect();            

        }

        public override dynamic JobDoing()
        {
            Provide();
            return List;
        }
    }
}
