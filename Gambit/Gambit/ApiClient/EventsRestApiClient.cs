using System.Collections.Generic;
using Gambit.Models.ApiModels;
using Newtonsoft.Json;
using RestSharp;

namespace Gambit.ApiClient
{
    public class EventsRestApiClient : IRestApiClient
    {
        public List<Event> GetAll()
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/getall", Method.GET);

            var response = client.Execute<List<Event>>(request);
            
            return response.Data;
        }

        public List<Event> GetAllForClient(string id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/getallforclient/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            
            var response = client.Execute<List<Event>>(request);

            return response.Data;
        }

        public Event Get(int id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/get/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            var response = client.Execute<Event>(request);

            return response.Data;
        }

        public void Delete(int id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/delete/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());

            client.Execute(request);
        }

        public void Add(Event @event)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/add/", Method.POST);
            
            request.AddJsonBody(@event);
            
            client.Execute(request);
        }

        public void Modify(Event @event)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/events/update/", Method.POST);

            request.AddJsonBody(@event);

            client.Execute(request);
        }
    }
}