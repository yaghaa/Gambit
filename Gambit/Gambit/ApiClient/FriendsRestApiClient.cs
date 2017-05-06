using System.Collections.Generic;
using Gambit.Models.ApiModels;
using RestSharp;

namespace Gambit.ApiClient
{
    public class FriendsRestApiClient
    {
        // FRIENDS
        public List<Friend> GetAll()
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/getall", Method.GET);

            var response = client.Execute<List<Friend>>(request);

            return response.Data;
        }

        public List<Friend> GetAllForClient(string id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/getallforuser/{id}", Method.GET);
            request.AddUrlSegment("id", id);

            var response = client.Execute<List<Friend>>(request);

            return response.Data;
        }

        public Friend Get(int id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/get/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            var response = client.Execute<Friend>(request);

            return response.Data;
        }

        public void Delete(int id)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/delete/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());

            client.Execute(request);
        }

        public void Add(Friend friend)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/add/", Method.POST);

            request.AddJsonBody(friend);

            client.Execute(request);
        }

        public void Modify(Friend friend)
        {
            var client = new RestClient("http://localhost:59543/");
            var request = new RestRequest("api/friends/update/", Method.POST);

            request.AddJsonBody(friend);

            client.Execute(request);
        }
    }
}