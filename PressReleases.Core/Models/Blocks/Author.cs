using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Filters;
using EPiServer.Web;

namespace PressReleases.Core.Models.Blocks;

/// <summary>
/// Used to insert a list of pages, for example a news list
/// </summary>
[ContentType(GUID = "30685434-33DE-42AF-88A7-3126B936AEA2")]
public class Author : SiteBlockData
{
    [Display(
      GroupName = SystemTabNames.Content,
      Order = 1
      )]
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? Image { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 2)]
    [CultureSpecific]
    public virtual string Name { get; set; }

    [Display(
       GroupName = SystemTabNames.Content,
       Order = 3)]
    [CultureSpecific]
    public virtual string Descption { get; set; }

}
