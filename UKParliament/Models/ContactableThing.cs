namespace UKParliament.Model
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class ContactableThing : UKParliamentDynamicNode
    {
        public ContactableThing(INode node) : base(node) { }

        public ICollection<ContactPoint> ContactableThingHasContactPoint => new DynamicObjectCollection<ContactPoint>(this, Property(UKParliamentOntology.ContactableThingHasContactPoint.Uri));
    }
}
