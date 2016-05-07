using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
        
        public String Source { get; set; } 
        
        /// <summary>
        /// Считывает файл онтологии.
        /// <param name="Source">Путь к файлу онтологии.</param>
        /// </summary>
        public void GetOntology(string Source) 
        {
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM);
            File = Ontology.getDocumentManager();
            File.addAltEntry(Source, "file:" + Source);
  
            Ontology.read(Source, "RDF/XML");
            Ontology = ModelFactory.createOntologyModel(OntModelSpec.OWL_MEM_MICRO_RULE_INF, Ontology);            
        }

        /// <summary>
        /// Классы онтологии в формате разметки OWL.
        /// </summary>
        public List<String> GetClasses()
        {
            List<String> Classes = new List<String>();
            ExtendedIterator i = Ontology.listClasses();
            while (i.hasNext())
            {
                OntClass temp = (OntClass)i.next();
                Classes.Add(temp.getURI());
            }
            return Classes;
        }

        /// <summary>
        /// Считывает сущности, принадлежащие определенному классу.
        /// </summary>
        /// <param name="TypeName">Имя класса.</param>
        /// <param name="Prefixes">Префиксы для запроса SPARQL.</param>
        /// <returns></returns>
        private List<Individual> ProvideIndividualsOfClass(String sparqlQuery)
        {
            List<Individual> Ret = new List<Individual>(); 
            //String sparqlQuery = "";
            ////запрос SPARQL к онтологии
            //if (Prefixes != null && !Prefixes.Any())
            //    foreach (string prefix in Prefixes)
            //        sparqlQuery += prefix + " ";
            //sparqlQuery = "PREFIX rdfr:<http://www.semanticweb.org/serega/ontologies/2015/6/SpaceWorld#>" +
            //              "SELECT ?ind " +
            //              "WHERE { ?ind a rdfr:" + TypeName + " }";
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

        public List<Object> GetSpecificIndividuals(String NameOfClass, String sparqlQuery)
        {
            List<Object> result = new List<Object>();
            string typefieldind = "";
            string curnamefieldind = "";
            string valuefieldind = "";

            Type typeOfClass = Type.GetType(NameOfClass);
            var temp = Activator.CreateInstance(typeOfClass);
            PropertyInfo[] properties = temp.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance); //получение полей C# класса сущности.

            var propertiesMarked = properties.Where(field =>  //получение полей с атрибутом "IndividualAttribute".
            {
                var searched = field.GetCustomAttribute<IndividualAttribute>(true);
                return searched != null;
            });     
            
            List<Individual> setofindividuals = ProvideIndividualsOfClass(sparqlQuery);
            foreach (var indiv in setofindividuals)
            {                
                StmtIterator iterator = indiv.listProperties(); // для пробега по свойствам сущности.
                while (iterator.hasNext())
                {
                    Statement fieldind = (Statement)iterator.next(); //получение названия поля                    
                    if (fieldind.getObject().isLiteral())
                    {
                        typefieldind = fieldind.getLiteral().getDatatype().ToString();
                        curnamefieldind = fieldind.getPredicate().getLocalName();  //получить имя поля 
                        valuefieldind = fieldind.getLiteral().getLexicalForm().ToString(); //получение значения поля сущности
                    }

                    var neccProperties = propertiesMarked.Where(f => f.GetCustomAttribute<IndividualAttribute>(true).Name == curnamefieldind); //получение поля, совпадающего с полученным названием temp
                    if (neccProperties != null)
                        foreach (var property in neccProperties)
                            property.SetValue(temp, valuefieldind); //запись t6ty в соответствующее поле 
                }
                result.Add(temp);
                temp = Activator.CreateInstance(typeOfClass);
            }
            return result;
        }
    }
}
