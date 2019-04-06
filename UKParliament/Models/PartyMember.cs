namespace UKParliament
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class PartyMember : Person
    {
        public PartyMember(INode node) : base(node) { }

        public ICollection<PartyMembership> PartyMemberHasPartyMembership => new DynamicObjectCollection<PartyMembership>(this, Property(UKParliamentOntology.PartyMemberHasPartyMembership));
    }
}
