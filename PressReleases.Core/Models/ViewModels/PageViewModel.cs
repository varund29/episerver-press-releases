using PressReleases.Core.Models.Pages;
using PressReleases.Core.Models.ViewModels;

namespace PressReleases.Core.Models.ViewModels;

public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
{
    public PageViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public T CurrentPage { get; private set; }

    public IContent Section { get; set; }
}

public static class PageViewModel
{
    /// <summary>
    /// Returns a PageViewModel of type <typeparam name="T"/>.
    /// </summary>
    /// <remarks>
    /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
    /// </remarks>
    public static PageViewModel<T> Create<T>(T page)
        where T : SitePageData => new(page);
}
