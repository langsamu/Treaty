namespace UKParliament.Model
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class LayingBody : Group
    {
        public LayingBody(INode node) : base(node) { }

        public ICollection<Laying> LayingBodyHasLaying => new DynamicObjectCollection<Laying>(this, Property(UKParliamentOntology.LayingBodyHasLaying.Uri));
    }
}
