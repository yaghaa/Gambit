using System.Collections.Generic;
using Gambit.Models.ApiModels;

namespace Gambit.ApiClient
{
    public interface IRestApiClient
    {
        List<Event> GetAll();
        List<Event> GetAllForClient(string id);
    }
}