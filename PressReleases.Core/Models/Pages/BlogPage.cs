using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Models.Pages;

[ContentType(
    GroupName = "Article",
    GUID = "9FD1C860-7183-4122-8CD4-FF4C55E096F8")]
public class BlogPage : SitePageData
{
    [Display(
       GroupName = SystemTabNames.Content,
       Order = 1
       )]
    [CultureSpecific]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? Image { get; set; }

    /// <summary>
    /// Gets or sets a description for the image, for example used as the alt text for the image when rendered
    /// </summary>
    [Display(
        GroupName = SystemTabNames.Content,
        Order = 2
        )]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual string? ImageDescription
    {
        get
        {
            var propertyValue = this["ImageDescription"] as string;

            // Return image description with fall back to the heading if no description has been specified
            return string.IsNullOrWhiteSpace(propertyValue) ? Heading : propertyValue;
        }
        set => this["ImageDescription"] = value;
    }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 3
        )]
    [CultureSpecific]
    public virtual string? Heading { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 4
        )]
    [CultureSpecific]
    public virtual string? SubHeading { get; set; }

    [Display(
       GroupName = SystemTabNames.Content,
       Order = 5
       )]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual XhtmlString? ShortDescription { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 6
        )]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual XhtmlString? LongDescription { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 7
        )]
    [CultureSpecific]
    [Required]
    [AllowedTypes(new[] { typeof(Author) })]
    public virtual PageReference? Author { get; set; }

    // The link must be required as an anchor tag requires an href in order to be valid and focusable
    [Display(
        GroupName = SystemTabNames.Content,
        Order = 8
        )]
    [CultureSpecific]
    public virtual DateTime? PublishedDate { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 9)]
    [AllowedTypes(new[] { typeof(BlogPage) })]
    public virtual ContentArea ReferenceLinks { get; set; }

}
