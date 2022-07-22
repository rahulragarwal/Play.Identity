using Play.Identity.Service.Entities;
using static Play.Identity.Service.Dtos.Dtos;

namespace Play.Identity.Service
{
    public static class Extension
    {
        public static UserDto AsDto(this ApplicationUser applicationUser) {
            return new UserDto(applicationUser.Id, applicationUser.Email, applicationUser.UserName, applicationUser.Coins, applicationUser.CreatedOn );
        }
    }
}