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

namespace MAS.Ontology
{
    public class OntologyReader // стандартный считыватель онтологии, использующий фраймворк jena.net
    {
        /// <summary>
        /// Онтология на языке OWL.
        /// </summary>
        private OntModel Ontology;

        /// <summary>
        /// Открывает файл OWL.
        /// </summary>
        private OntDocumentManager File;  

        /// <summary>
        /// Путь к файлу онтологии.
        /// </summary>
        private String Source; 

        /// <summary>
        /// Классы онтологии в формате разметки OWL.
        /// </summary>
        private List<String> Classes;
        /// <summary>
        /// Классы онтологии в формате разметки OWL.
        /// </summary>
        public List<String> GetClasses { get { return Classes; } }

        /// <summary>
        /// Сущности классов в онтологии.
        /// </summary>
        private List<Individual> Ret;

        public OntologyReader(String Source) { this.Source = Source; GetOntology(); }

        public List<String> GetOntologyClasses { get { return Classes; } }

        /// <summary>
        /// Считывает файл онтологии.
        /// </summary>
        public void GetOntology() 
        {
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM);
            File = Ontology.getDocumentManager();
            File.addAltEntry(Source, "file:" + Source);
  
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

        /// <summary>
        /// Считывает сущности, принадлежащие определенному классу.
        /// </summary>
        /// <param name="TypeName">Имя класса.</param>
        /// <returns></returns>
        public List<Individual> ProvideSpecificClass(String TypeName)
        {
            Ret = new List<Individual>(); 

            //запрос SPARQL к онтологии
            String sparqlQuery = "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                                 "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                                 "PREFIX owl: <http://www.w3.org/2002/07/owl#> " + 
                                 "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
                                 "SELECT ?ind " +
                                 "WHERE { ?ind a " + TypeName + " }";
            Query demand = QueryFactory.create(sparqlQuery);
            QueryExecution d0 = QueryExecutionFactory.create(demand, Ontology); // выполнение запроса
            ResultSet done = d0.execSelect(); // результат запроса
            while (done.hasNext()) // заносит полученные сущности в массив сущностей
            {
                QuerySolution row = done.next();
                Resource R = row.getResource("?ind"); 
                if (R.isURIResource())
                    Ret.Add(Ontology.getIndividual(R.toString()));
            }
            return Ret;
        }

        //public void provideindividualfields(string individtype)
        //{
        //    string typefieldind;
        //    string cutnamefieldind;
        //    string valuefieldind;

        //    list<individual> setofindividuals = providespecificclass(individtype);
        //    foreach (var indiv in setofindividuals)
        //    {
        //        stmtiterator iterator = indiv.listproperties(); // для пробега по свойствам сущности.
        //        while (iterator.hasnext())
        //        {
        //            statement fieldind = (statement)iterator.next(); //получение названия поля                    
        //            if (fieldind.getobject().isliteral())
        //            {
        //                typefieldind = fieldind.getliteral().getdatatype().tostring();
        //                cutnamefieldind = fieldind.getpredicate().getlocalname();  //получить имя поля 
        //                valuefieldind = fieldind.getliteral().getlexicalform().tostring(); //получение значения поля сущности
        //            }


        //            var neccfields = fieldsmarked.where(f => f.getcustomattribute<agentattribute>(true).name == temp.getpredicate().getlocalname()); //получение поля, совпадающего с полученным названием temp
        //            if (neccfields != null)
        //                foreach (var field in neccfields)
        //                    field.setvalue(anonimus, temp.getliteral().getlexicalform().tostring()); //запись t6ty в соответствующее поле anonymous
        //        }
        //    }
        //}
    }
}
