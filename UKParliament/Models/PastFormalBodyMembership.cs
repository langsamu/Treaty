namespace UKParliament
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class PastFormalBodyMembership : FormalBodyMembership
    {
        public PastFormalBodyMembership(INode node) : base(node) { }

        public ICollection<DateTimeOffset> FormalBodyMembershipEndDate => new DynamicObjectCollection<DateTimeOffset>(this, Property(UKParliamentOntology.FormalBodyMembershipEndDate));
    }
}
