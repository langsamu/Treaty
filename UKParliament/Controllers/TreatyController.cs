﻿// MIT License
//
// Copyright (c) 2019 UK Parliament
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace UKParliament
{
    using Microsoft.AspNetCore.Mvc;
    using OntologyHelper;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UKParliament.Model;

    [Route("/view/treaty")]
    public class TreatyController : BaseController
    {
        public TreatyController(SparqlService sparqlService) : base(sparqlService) { }

        [HttpGet]
        public ActionResult Index()
        {
            //var query = "treaty.sparql";
            //var filters = new List<string>() { "current", "leadGovernmentOrganisation", "seriesMembershipType", "procedureStep" };

            //return GetView(query, filters);
            var graph = this.SparqlService.Execute("UKParliament.SPARQL.treaty.sparql");

            var filters = new List<string>() { "current", "leadGovernmentOrganisation", "seriesMembershipType", "procedureStep" };

            ViewBag.Filter = false;

            if (filters.Any(x => Request.Query.ContainsKey(x)))
            {
                ViewBag.Filter = true;
                ViewBag.Current = Request.Query["current"];
                ViewBag.LeadGovernmentOrganisation = Request.Query["leadGovernmentOrganisation"];
                ViewBag.SeriesMembershipType = Request.Query["seriesMembershipType"];
                ViewBag.ProcedureStep = Request.Query["procedureStep"];
            }

            return this.View(new UKParliamentDynamicGraph(graph));
        }

        [HttpGet("{id}")]
        public ActionResult Item(string id)
        {
            var uris = new[] { new Uri(UKParliamentOntology.BaseUri, id) };
            var sparqlParameters = new Dictionary<string, IEnumerable<object>> { { "id", uris } };
            var graph = this.SparqlService.Execute("UKParliament.SPARQL.treaty_by_id.sparql", sparqlParameters);
            return this.View(new UKParliamentDynamicGraph(graph));
        }
    }
}
