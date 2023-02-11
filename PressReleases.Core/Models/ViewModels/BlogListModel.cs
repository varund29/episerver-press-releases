using EPiServer.Web;
using PressReleases.Core.Models.Pages;
using static PressReleases.Globals;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction.Internal;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Models.ViewModels;

public class BlogListModel 
{
    public IEnumerable<BlogPage> blogs { get; set; }
    public Pagination Pagination { get; set; }

}
