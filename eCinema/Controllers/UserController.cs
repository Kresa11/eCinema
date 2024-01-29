using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;
using eCinema.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Controllers
{
    public class UserController : BaseCRUDController<UserDto, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<UserDto> Register([FromBody] RegistrationRequest registration)
        {
            return await _userService.Register(registration);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("adminUpdate/{id}")]
        public virtual async Task<UserDto> AdminUpdate(Guid id, [FromBody] UserAdminUpdateRequest updateRequest)
        {
            return await _userService.UpdateUserAdmin(id, updateRequest);
        }
    }
}
