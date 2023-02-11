using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Business.Repositories
{
    internal interface IKeystoreRepository
    {
        string GetPhrase(string key);

        IEnumerable GetAll();

    }
}
