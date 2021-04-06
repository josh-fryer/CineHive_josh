using HiveData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public interface ISearchService
    {
        Task<SearchResultsVM> Search(string query);
    }
}