using EPiServer.Web;
using PressReleases.Core.Models.Pages;
using static PressReleases.Globals;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction.Internal;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Models.ViewModels;

public class BlogModel : PageViewModel<BlogPage>
{
    public BlogModel(BlogPage currentPage)
        : base(currentPage)
    {
        this.Author = new Author();        
    }
    public Author? Author { get; set; }

    public IList<PageData> ReferenceLinks { get; set;}

}
