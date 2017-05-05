using GambitApi.Domains;
using GambitApi.Domains.Interfaces;
using GambitApi.Models.Entities;
using Ninject.Modules;

namespace GambitApi.NinjectModules
{
    public class RepositoriesModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Friend, int>>().To<FriendRepository>();
            Bind<IRepository<Address, int>>().To<AddressRepository>();
            Bind<IRepository<Event, int>>().To<EventRepository>();
            Bind<IRepositoryExtensions<Event>>().To<EventRepository>();
            Bind<IRepositoryExtensions<Friend>>().To<FriendRepository>();
            Bind<IRepository<Phone, string>>().To<PhoneRepository>();
            Bind<IRepository<Email, string>>().To<EmailRepository>();
            Bind<IRepository<Details, int>>().To<DetailRepository>();
        }
    }
}