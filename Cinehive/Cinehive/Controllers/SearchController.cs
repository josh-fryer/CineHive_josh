using HiveData.Models;
using HiveData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HiveData.Repository;
using HiveServices.Service;

namespace Cinehive.Controllers
{
    public class SearchController : Controller
    {
        private ISearchService searchService;

        public SearchController()
        {
            searchService = new SearchService();
        }

        public async Task<ActionResult> Search(string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                string q = query.Trim();
                
                return View(await searchService.Search(q));
            }

            return View();
        }
    }
}