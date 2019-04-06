namespace UKParliament
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class MnisParty : Party
    {
        public MnisParty(INode node) : base(node) { }

        public ICollection<string> PartyMnisId => new DynamicObjectCollection<string>(this, Property(UKParliamentOntology.PartyMnisId));
    }
}
