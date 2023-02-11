using EPiServer.Web.Mvc;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PressReleases.Core.Models.ViewModels;
using PressReleases.Core.Models.Pages;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using PressReleases.Core.Models.Blocks;
using PressReleases.Core.Business;
using Castle.MicroKernel.Registration;

namespace PressReleases.Core.Controllers;

public class BlogController : PageController<BlogPage>
{
    Utility utility;
    public BlogController(InMemoryStateStorage state, IContentRepository repo)
    {
        utility = new Utility(state);
    }

    [HttpGet]
    public IActionResult Index(BlogPage currentPage)
    {
        var model = new BlogModel(currentPage)
        {
        };

        // Get object used to load Episerver content
        var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
       
        // Some content reference
        var contentLink = new ContentReference(currentPage.Author.ID);

        // Get content of a specific type
        model.Author = contentLoader.Get<Author>(contentLink);
        IDictionary<int, string> topics = utility.GetSubCategories("Topics");

        model.ReferenceLinks= utility.GetContentArea(currentPage.ReferenceLinks);
      
        ViewData["Topics"] = topics;
        return View(model);
    }
}
