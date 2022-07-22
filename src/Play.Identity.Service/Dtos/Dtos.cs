using System.ComponentModel.DataAnnotations;

namespace Play.Identity.Service.Dtos
{
    public class Dtos
    {
        public record UserDto(Guid Id, string Email, string UserName, decimal Coins, DateTimeOffset createdDate);

        public record UpdateUserDto([Required][EmailAddress]string Email, [Range(0,1000000)]decimal Coins);
    }
}