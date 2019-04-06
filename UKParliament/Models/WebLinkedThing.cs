namespace UKParliament
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class WebLinkedThing : UKParliamentDynamicNode
    {
        public WebLinkedThing(INode node) : base(node) { }

        public ICollection<WebLink> WebLinkedThingHasWebLink => new DynamicObjectCollection<WebLink>(this, Property(UKParliamentOntology.WebLinkedThingHasWebLink));
    }
}
