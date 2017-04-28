using System;
using GambitApi.Models.Entities;

namespace GambitApi.Domains.Validators
{
    public class FriendValidator : IValidator<Friend>
    {
        public bool Validate(Friend model)
        {
            if (model.Id == Int32.MinValue)
                return false;

            return true;
        }
    }
}