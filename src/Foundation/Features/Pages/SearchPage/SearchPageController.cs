using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.DataAbstraction;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Find.Helpers;
using EPiServer.Tracking.PageView;
using EPiServer.Web.Mvc;
using Foundation.Cms.Pages;
using Foundation.Cms.ViewModels;
using Foundation.Cms.ViewModels.Pages;
using Geta.Tags.Implementations;

namespace Foundation.Features.Pages.SearchPage
{
    public class SearchPageController : PageController<Cms.Pages.SearchPage>
    {
        private readonly TagRepository _tagRepository;
        private readonly CategoryRepository _categoryRepository;
        public SearchPageController(TagRepository tagRepository, CategoryRepository categoryRepository)
        {
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
        }

        [PageViewTracking]
        public ActionResult Index(Cms.Pages.SearchPage currentPage, string tagName = null)
        {
            ViewBag.AllTags = _tagRepository.GetAllTags().Select(t => t.Name).ToList();
            if (tagName != null)
            {
                //It is the second way to find content by tags
                //var results = SearchClient.Instance.Search<FoundationPageData>().Filter(p => p.Tags.Match(tagName)).GetContentResult();
                var results = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<Geta.Tags.Interfaces.ITagEngine>().GetContentByTag(tagName);
                ViewBag.Results = results;
            }
            var model = SearchPageViewModel.Create(currentPage, _categoryRepository);
            return View(model);
        }

    }
}