using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PressReleases.Core.Business.Repositories;

namespace PressReleases.Core.Helpers;

public static class KeystoreHelpers
{
    public static string GetKeyValueEntry(this IHtmlHelper html, string key, string fallback = "")
    {
        if (string.IsNullOrEmpty(key))
            return string.Empty;

        var _dictionaryService = ServiceLocator.Current.GetInstance<IKeystoreRepository>();

        var phrase = _dictionaryService?.GetPhrase(key)?.Trim();

        return !string.IsNullOrEmpty(phrase) ? phrase : fallback;
    }
}
