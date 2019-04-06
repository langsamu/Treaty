namespace UKParliament
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class SesThing : ExternalThing
    {
        public SesThing(INode node) : base(node) { }

        public ICollection<string> SesId => new DynamicObjectCollection<string>(this, Property(UKParliamentOntology.SesId));
    }
}
