namespace UKParliament.Model
{
    using OntologyHelper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VDS.RDF;
    using VDS.RDF.Dynamic;

    public class ApprovedEPetition : EPetition
    {
        public ApprovedEPetition(INode node) : base(node) { }

        public ICollection<Approval> ApprovedEPetitionHasApproval => new DynamicObjectCollection<Approval>(this, Property(UKParliamentOntology.ApprovedEPetitionHasApproval.Uri));
    }
}
