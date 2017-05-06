using System.Collections.Generic;

namespace GambitApi.Domains.Interfaces
{
    public interface IRepository<T,T2>
    {
        T Get(T2 id);
        void Add(T model);
        void Modify(T model);
        void Delete(T2 id);
        List<T> GetAll();
    }
}