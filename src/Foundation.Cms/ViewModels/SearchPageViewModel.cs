using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.DataAbstraction;
using Foundation.Cms.Pages;

namespace Foundation.Cms.ViewModels
{
    public class SearchPageViewModel : ContentViewModel<SearchPage>
    {
        public string CategoryName { get; set; }

        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {

        }

        public static SearchPageViewModel Create(SearchPage currentPage, CategoryRepository categoryRepository)
        {
            var model = new SearchPageViewModel(currentPage);
            if (currentPage.Category.Any())
            {
                model.CategoryName = categoryRepository.Get(currentPage.Category.FirstOrDefault()).Description;
            }
            return model;
        }
    }
}
