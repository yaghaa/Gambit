using System.Collections.Generic;

namespace GambitApi.Domains.Interfaces
{
    public interface IRepositoryExtensions<T>
    {
        List<T> GetAllForUser(string id);
    }
}