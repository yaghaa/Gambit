using System;
using Gambit.ApiClient;
using Gambit.Models.ApiModels;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gambit.Startup))]
namespace Gambit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // EVENTS
            // GetAll Wydarzenia
            var client = new EventsRestApiClient();
            var resultEvents = client.GetAll();

            // Get
            var resultEvent = client.Get(1);

            // GetAllForClient
            // UWAGA Id istniejącego usera
            var resultEventsForClient = client.GetAllForClient("b65e1b90-cb5b-4f28-9b9f-675b5b929df7");

            // Add Wydarzenie 
            // UWAGA Id istniejącego usera
            var myEvent = new Event
            {
                Date = DateTime.Now,
                Hour = DateTime.Now,
                Id = "b65e1b90-cb5b-4f28-9b9f-675b5b929df7",
                Kind = "moj rodzaj",
                Name = "Gambit wydarzenie",
                WydarzenieId = 9
            };
            client.Add(myEvent);

            // Modify Wydarzenie
            var myEvent2 = new Event
            {
                Date = DateTime.Now.AddDays(-1),
                Hour = DateTime.Now.AddHours(-6),
                Id = "b65e1b90-cb5b-4f28-9b9f-675b5b929df7",
                Kind = "modyfikowane",
                Name = "modyfikowane",
                WydarzenieId = 9
            };
            client.Modify(myEvent2);

            // Delete Wydarzenie
            client.Delete(myEvent.WydarzenieId);



            ////FRIENDS
            //// GetAll Wydarzenia
            var friendClient = new FriendsRestApiClient();
            var resultFriends = friendClient.GetAll();

            //// Get
            var resultFriend = friendClient.Get(1);

            // GetAllForClient
            // UWAGA Id istniejącego usera
            var resultFriendsForClient = friendClient.GetAllForClient("b65e1b90-cb5b-4f28-9b9f-675b5b929df7");

            // Add Friend
            // UWAGA Id istniejącego usera
            var myFriend = new Friend
            {
                Name = "Jadzia",
                Name2 = "Hela",
                Surname = "Nowicka",
                Id = 66,
                Email = "e@ma.il",
                Number = "123456789",
                Address = new Address
                {
                    AddressId = 55,
                    City = "Wojnowice",
                    County = "dolnośląskie",
                    Country = "Polska",
                    FlatNumber = 1,
                    HouseNumber = 11,
                    ZipCode = "55-555"
                },
                Details = new Details
                {
                    BirthDay = DateTime.Now.AddYears(-25),
                    NameDay = DateTime.Now,
                    InfoId = 122
                }

            };
            friendClient.Add(myFriend);

            // Modify Friend
            myFriend.Name = "Jolanta";
            myFriend.Surname = "Przywłocka";
            friendClient.Modify(myFriend);

            // Delete Friend
            friendClient.Delete(myFriend.Id);
        }
    }
}
