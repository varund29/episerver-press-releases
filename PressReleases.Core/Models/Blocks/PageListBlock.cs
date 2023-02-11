using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Filters;

namespace PressReleases.Core.Models.Blocks;

/// <summary>
/// Used to insert a list of pages, for example a news list
/// </summary>
[ContentType(GUID = "30685434-33DE-42AF-88A7-3126B936AEAD")]
public class PageListBlock : SiteBlockData
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
