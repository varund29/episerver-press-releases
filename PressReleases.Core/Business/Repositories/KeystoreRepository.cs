using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Globalization;
using PressReleases.Core.Models.Blocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Business.Repositories
{
    internal class KeystoreRepository : IKeystoreRepository
    {

        private readonly IClient _findClient;

        public KeystoreRepository(IClient findClient)
        {
            _findClient = findClient ?? throw new ArgumentNullException(nameof(findClient));
        }

        public string GetPhrase(string key)
        {
            var queryBuilder = this._findClient
                .Search<IDictionaryEntryBlock>()
                .ExcludeDeleted().InLanguageBranch(ContentLanguage.PreferredCulture.Name)
                .Filter(x => x.Key.MatchCaseInsensitive(key));

            var result = queryBuilder.GetContentResult().Items.FirstOrDefault();

            return result?.Phrase ?? "";
        }

        public IEnumerable GetAll()
        {
            var queryBuilder = this._findClient
                .Search<IDictionaryEntryBlock>()
                .ExcludeDeleted();

            var result = queryBuilder.GetContentResult().Items;

            return result;
        }
    }

}
