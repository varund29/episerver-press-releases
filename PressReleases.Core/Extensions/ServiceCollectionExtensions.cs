using EPiServer.Find.Framework;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PressReleases.Core.Business;
using PressReleases.Core.Business.Repositories;
using PressReleases.Core.Models.Blocks;

namespace PressReleases.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlockPartial(this IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(options => options.ViewLocationExpanders.Add(new SiteViewEngineLocationExpander()));
        services.AddSingleton(x => SearchClient.Instance);
        services.AddSingleton<IKeystoreRepository, KeystoreRepository>();
        return services;
    }

}
