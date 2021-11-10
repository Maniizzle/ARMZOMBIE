using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Application.Exceptions;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;

namespace ZombieSurvivalSocialNetwork.Core.Application.Extensions
{
    public static class GenderExtensions
    {
        public static Gender ConvertToGender(this string gender)
        {
            switch (gender)
            {
                case "M":
                case "MALE":
                    return Gender.Male;

                case "F":
                case "FEMALE":
                    return Gender.Male;

                default:
                    throw new ApiException("Wrong gender format");
            }
        }
    }
}
