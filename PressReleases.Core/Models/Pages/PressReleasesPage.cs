using EPiServer.Filters;
using PressReleases.Core.Models.Blocks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PressReleases.Core.Models.Pages;

[ContentType(
    GUID = "19671657-B684-4D95-A61F-8DD4FE60D559",
    GroupName = "PressReleases")]
public class PressReleasesPage : StandardPage
{
    [Display(
       GroupName = SystemTabNames.Content,
       Order = 1)]
    [CultureSpecific]
    public virtual string Heading { get; set; }

    [Display(
       GroupName = SystemTabNames.Content,
       Order = 2)]
    [CultureSpecific]
    public virtual string Descption { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 3)]
    [DefaultValue(3)]
    [Required]
    public virtual int Count { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 4)]
    [DefaultValue(FilterSortOrder.PublishedDescending)]
    [UIHint("SortOrder")]
    [BackingType(typeof(PropertyNumber))]
    public virtual FilterSortOrder SortOrder { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 5)]
    [Required]
    public virtual PageReference Root { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 6)]
    public virtual PageType PageTypeFilter { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 7)]
    public virtual CategoryList CategoryFilter { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 8)]
    public virtual bool Recursive { get; set; }



    /// <summary>
    /// Sets the default property values on the content data.
    /// </summary>
    /// <param name="contentType">Type of the content.</param>
    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);

        Count = 10;
        SortOrder = FilterSortOrder.PublishedDescending;
    }
}

