using EPiServer.Web.Mvc;
using PressReleases.Core.Models.Pages;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using PressReleases.Core.Models.ViewModels;
using EPiServer.ServiceLocation;
using PressReleases.Core.Business;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using EPiServer.Core.Internal;
using EPiServer.Core;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Controllers;

public class PressReleasesController : PageController<PressReleasesPage>
{
    Utility utility;
    private readonly IContentRepository _repo;
    public PressReleasesController(InMemoryStateStorage state, IContentRepository repo)
    {
        _repo = repo;
        utility = new Utility(state);
    }

    [HttpGet]
    public IActionResult Index(PressReleasesPage currentPage)
    {

        if (SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink))
        {
        }

        var model = new PressreleasesModel(currentPage)
        {

        };
        var categoryRepo = ServiceLocator.Current.GetInstance<CategoryRepository>();
        var rootCategory = categoryRepo.GetRoot();
        CategoryCollection childCategories = rootCategory.Categories;
        IDictionary<int, string>  topics = utility.GetSubCategories("Topics");
        IDictionary<int, string> segments = utility.GetSubCategories("Segments");
        IDictionary<int, string> authors = utility.GetAuthors("Authors");
       
        ViewData["Topics"] = topics;
        ViewData["Authors"] = authors;
        ViewData["Segments"] = segments;
        return View(model);
    }

    [HttpGet]
    public IActionResult GetBlogs(int pageId, int topic, int segment, int author, int page, int pageSize)
    {
        BlogListModel model = utility.GetBlogsFilter(pageId, topic, segment, author, page, pageSize);
      
        return PartialView("Blocks/Articles", model);
    }

}
