using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressReleases.Core.Business;

[ServiceConfiguration(Lifecycle = ServiceInstanceScope.Singleton)]
public class InMemoryStateStorage : IStateStorage
{
    IDictionary<string, object> _states = new Dictionary<string, object>();
    public bool IsAvailable => true;
    public object Load(string key)
    {
        _states.TryGetValue(key, out object value);
        return value;
    }

    public void Delete(string key)
    {
        _states.Remove(key);
    }

    public void Save(string key, object value)
    {
        _states[key] = value;
    }
}