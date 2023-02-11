using Castle.MicroKernel.Registration;
using EPiServer.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Web.Mvc.Html;
using Microsoft.IdentityModel.Tokens;
using PressReleases.Core.Models.Blocks;
using PressReleases.Core.Models.Pages;
using PressReleases.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Business
{
    internal class Utility
    {
        InMemoryStateStorage _state;
        public Utility(InMemoryStateStorage state)
        {
            _state = state;
        }
        public IEnumerable<BlogPage> GetBlogs(int pageId)
        {
            var pageRef = new PageReference(pageId);
            var contentRepository = ServiceLocator.Current.GetInstance<IContentLoader>();
            var page = contentRepository.Get<PressReleasesPage>(pageRef);
            IEnumerable<BlogPage>? pages = null;
            if (_state.Load("BlogPage") != null)
            {
                pages = _state.Load("BlogPage") as IEnumerable<BlogPage>;
            }
            else
            {
                pages = GetAll<BlogPage>(page.Root);
            }

            return pages;
        }

        public BlogListModel GetBlogsFilter(int pageId, int topic, int segment, int author, int page, int pageSize)
        {

            IEnumerable<BlogPage>? pages = GetBlogs(pageId);
            pages = pages.OrderByDescending(x => x.PublishedDate) as IEnumerable<BlogPage>;
            var list = new List<BlogPage>();
            if (topic != 0 && segment != 0)
            {
                pages = pages.Where(x => x.Category.Contains(topic) && x.Category.Contains(segment));
            }
            else if (topic != 0)
            {
                pages = pages.Where(x => x.Category.Contains(topic));
            }
            else if (segment != 0)
            {
                pages = pages.Where(x => x.Category.Contains(segment));
            }
            if (author != 0)
            {
                pages = pages.Where(x => x.Author.ID == author);
            }
            int Count = pages.Count();
            pages = pages.Skip((page - 1) * pageSize).Take(pageSize);

            Pagination pagination = new Pagination();
            pagination.Size = pageSize;
            pagination.Count = Count / pageSize;
            pagination.SelectedPage = page;

            BlogListModel model = new BlogListModel();
            model.blogs = pages;
            model.Pagination = pagination;
            return model;
        }
        private IEnumerable<T> GetAll<T>(ContentReference rootLink) where T : BlogPage
        {
            var _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            var children = _contentLoader.GetChildren<BlogPage>(rootLink);
            foreach (var child in children)
            {
                if (child is T childOfRequestedTyped)
                {
                    yield return childOfRequestedTyped;
                }
                foreach (var descendant in GetAll<T>(child.ContentLink))
                {
                    yield return descendant;
                }
            }
        }

        public IDictionary<int, string> GetSubCategories(string paraentCategory)
        {
            IDictionary<int, string> topics = new Dictionary<int, string>();
            var categoryRepo = ServiceLocator.Current.GetInstance<CategoryRepository>();
            var rootCategory = categoryRepo.GetRoot();
            CategoryCollection childCategories = rootCategory.Categories;
            foreach (Category category in childCategories)
            {
                foreach (var subCategories in category.Categories)
                {
                    if (category.Name == paraentCategory)
                    {
                        topics.Add(subCategories.ID, subCategories.Name);
                    }
                }
            }

            return topics;
        }

        public IDictionary<int, string> GetAuthors(string blockFolder)
        {
            IDictionary<int, string> authors = new Dictionary<int, string>();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var list = contentLoader.GetChildren<IContent>(ContentReference.GlobalBlockFolder);
            var alist = list.Where(x => x.Name == blockFolder).FirstOrDefault();
            list = contentLoader.GetChildren<IContent>(alist.ContentLink);
            if (list != null)
            {
                foreach (var item in list)
                {
                    authors.Add(item.ContentLink.ID, item.Name);
                }
            }

            return authors;
        }

        public IList<PageData> GetContentArea(ContentArea contentArea)
        {
            var _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            IList<PageData> listContent =null; ;
            if (contentArea != null)
            {
                listContent = new List<PageData>();
                foreach (var item in contentArea.Items)
                {
                    var content = _contentLoader.Get<PageData>(item.ContentLink);
                    listContent.Add(content);
                }
            }

            return listContent;
        }
    }
}


// Some content reference

// IEnumerable<IContent> blockFolders = _repo.GetChildren<IContent>(ContentReference.GlobalBlockFolder);
//ContentReference blockStartNode = null;

//foreach (var f in blockFolders)
//{
//    if (f.Name.Contains("Authors"))
//    {
//        blockStartNode = f.ContentLink;
//        break;
//    }
//}
//if (blockStartNode != null)
//{
//    var list = _repo.GetChildren<IContent>(blockStartNode);
//    foreach (var item in list)
//    {
//        authors.Add(item.ContentLink.ID, item.Name);
//    }
//}
