using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GambitApi.Domains.Interfaces;
using GambitApi.Domains.Validators;
using GambitApi.Models.Entities;

namespace GambitApi.Controllers
{

    public class FriendsController : ApiController
    {
        private readonly IRepository<Friend, int> _friendRepository;
        private readonly IRepository<Address, int> _addressRepository; 
        private readonly IRepository<Phone, string> _phoneRepository; 
        private readonly IRepository<Email, string> _emailRepository; 
        private readonly IRepository<Details, int> _detailsRepository; 
        private readonly IValidator<Friend> _friendValidator; 
        private readonly IRepositoryExtensions<Friend> _friendRepositoryExtensions; 

        public FriendsController(IRepository<Friend, int> friendRepository, IRepository<Address, int> addressRepository, IValidator<Friend> friendValidator, IRepository<Phone, string> phoneRepository, IRepository<Email, string> emailRepository, IRepositoryExtensions<Friend> friendRepositoryExtensions, IRepository<Details, int> detailsRepository)
        {
            _friendRepository = friendRepository;
            _addressRepository = addressRepository;
            _friendValidator = friendValidator;
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
            _friendRepositoryExtensions = friendRepositoryExtensions;
            _detailsRepository = detailsRepository;
        }

        public Friend Get(int id)
        {
            if (id == int.MinValue)
            {
                NotFound();
            }

            return _friendRepository.Get(id);
        }

        public List<Friend> GetAll()
        {
            return _friendRepository.GetAll();
        }

        public List<Friend> GetAllForUser(string id)
        {
            return _friendRepositoryExtensions.GetAllForUser(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            if (id == int.MinValue)
            {
                NotFound();
            }
            
            _friendRepository.Delete(id);
        }

        [HttpPost]
        public void Update([FromBody]Friend friend)
        {
            if (friend == null)
            {
                NotFound();
            }

            _friendRepository.Modify(friend);
        }

        
        [HttpPost]
        public void Add([FromBody]Friend friend)
        {
            if (friend == null)
            {
                NotFound();
                return;
            }

            if (_friendValidator.Validate(friend))
            {
                if (friend.Address != null && _addressRepository.Get(friend.Address.AddressId) == null)
                {
                    _addressRepository.Add(friend.Address);
                }
                if (friend.Number != null && _phoneRepository.Get(friend.Number) == null)
                {
                    _phoneRepository.Add(new Phone { Numer = friend.Number });
                }
                if (friend.Email != null && _emailRepository.Get(friend.Email) == null)
                {
                    _emailRepository.Add(new Email { KontaktEmail = friend.Email });
                }
                if (friend.Details != null && _detailsRepository.Get(friend.Details.InfoId) == null)
                {
                    _detailsRepository.Add(new Details { InfoId = friend.Details.InfoId, BirthDay = friend.Details.BirthDay, NameDay = friend.Details.NameDay});
                }

                _friendRepository.Add(friend);
            }
        }
    }
}
