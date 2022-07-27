using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Play.Identity.Service.Entities;
using static IdentityServer4.IdentityServerConstants;
using static Play.Identity.Service.Dtos.Dtos;

namespace Play.Identity.Service.Controller
{
    [ApiController]
    [Route("users")]
    [Authorize(Policy = LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var users = userManager.Users.ToList().Select(user => user.AsDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(Guid Id)
        {
            var user = await userManager.FindByIdAsync(Id.ToString());

            if (user == null)
                return NotFound();
            return Ok(user.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid Id, UpdateUserDto updateUserDto)
        {
            var user = await userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return NotFound();
            user.Coins = updateUserDto.Coins;
            user.Email = updateUserDto.Email;
            await userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            var user = await userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return NotFound();
            await userManager.DeleteAsync(user);
            return NoContent();
        }
    }
}