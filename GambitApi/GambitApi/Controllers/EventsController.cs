using System.Collections.Generic;
using System.Web.Http;
using GambitApi.Domains.Interfaces;
using GambitApi.Models.Entities;

namespace GambitApi.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IRepository<Event, int> _eventRepository;
        private readonly IRepositoryExtensions<Event> _eventRepositoryExtensions;

        public EventsController(IRepository<Event, int> eventRepository, IRepositoryExtensions<Event> eventRepositoryExtensions)
        {
            _eventRepository = eventRepository;
            _eventRepositoryExtensions = eventRepositoryExtensions;
        }

        public Event Get(int id)
        {
            if (id == int.MinValue)
            {
                NotFound();
            }

            return _eventRepository.Get(id);
        }

        public List<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public List<Event> GetAllForUser(string id)
        {
            return _eventRepositoryExtensions.GetAllForUser(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            if (id == int.MinValue)
            {
                NotFound();
            }

            _eventRepository.Delete(id);
        }

        [HttpPost]
        public void Update([FromBody]Event friend)
        {
            if (friend == null)
            {
                NotFound();
            }

            _eventRepository.Modify(friend);
        }


        [HttpPost]
        public void Add([FromBody]Event friend)
        {
            if (friend == null)
            {
                NotFound();
                return;
            }
 
            _eventRepository.Add(friend);
            
        }
    }
}