﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.title = "Search";
            ViewBag.columns = ListController.columnChoices;
            ViewBag.searchTerm = searchTerm;


            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                
                return View("Index");
            }

            if (searchType == "all")

            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }

            else

            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            return View("Index");
        }



    }
}
