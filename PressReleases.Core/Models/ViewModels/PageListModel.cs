using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Models.ViewModels;

public class PageListModel
{
    public PageListModel(PageListBlock block)
    {
        Heading = block.Heading;
        Descption = block.Descption;
    }
    public string Heading { get; set; }

    public string Descption { get; set; }

    public IEnumerable<PageData> Pages { get; set; }

    public bool ShowIntroduction { get; set; }

    public bool ShowPublishDate { get; set; }
}
