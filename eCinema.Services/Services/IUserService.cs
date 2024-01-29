using System.Collections;
using eCinema.Model.Dtos;
using eCinema.Model.Requests;
using eCinema.Model.SearchObjects;

namespace eCinema.Services.Services
{
    public interface IUserService : ICRUDService<UserDto, UserSearchObject,
       UserInsertRequest, UserUpdateRequest>
    {
        Task<UserDto?> Login(string username, string password);
        Task<UserDto> Register(RegistrationRequest registration);
        Task<UserDto> UpdateUserAdmin(Guid id, UserAdminUpdateRequest update);
    }
}
