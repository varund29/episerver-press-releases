using EPiServer.Web;
using PressReleases.Core.Models.Pages;
using static PressReleases.Globals;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction.Internal;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Models.ViewModels;

public class PressreleasesModel : PageViewModel<PressReleasesPage>
{
    public PressreleasesModel(PressReleasesPage currentPage)
        : base(currentPage)
    {      
    }
    public int Count { get; set; }

}
