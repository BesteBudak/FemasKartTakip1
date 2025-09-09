using Business.Requests;
using Entities.Dtos;
using Entities.Models;

namespace Business.Users
{
    public interface IUserService
    {


        Task<ServiceResult<UserDto>> CreateAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateUserRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<UserDto>>> GetAllListAsync();
    }
}
