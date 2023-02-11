using System.ComponentModel.DataAnnotations;

namespace PressReleases.Core.Models.Pages;

/// <summary>
/// Used for the pages mainly consisting of manually created content such as text, images, and blocks
/// </summary>
[ContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267", GroupName =Globals.GroupNames.Default)]
public class StandardPage : SitePageData
{
    [Display(
        GroupName = SystemTabNames.Content,
        Order = 310)]
    [CultureSpecific]
    public virtual XhtmlString MainBody { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 320)]
    public virtual ContentArea MainContentArea { get; set; }
}
