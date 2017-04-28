using GambitApi.Domains.Validators;
using GambitApi.Models.Entities;
using Ninject.Modules;

namespace GambitApi.NinjectModules
{
    public class ValidatorsModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Friend>>().To<FriendValidator>();
        }
    }
}