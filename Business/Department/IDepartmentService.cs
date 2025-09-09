using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IDepartmentService
    {
        //Task<ServiceResult<IEnumerable<Department>>> GetAllAsync();
        Task<ServiceResult<Department>> GetByIdAsync(int id);
        Task<ServiceResult<Department>> CreateAsync(Department department);
        Task<ServiceResult<bool>> UpdateAsync(Department department);
        Task<ServiceResult<bool>> DeleteAsync(int id);

        Task<ServiceResult<bool>> AddUserToDepartmentAsync(int departmentId, User user);
        Task<ServiceResult<bool>> RemoveUserFromDepartmentAsync(int departmentId, int userId);
    }
}
