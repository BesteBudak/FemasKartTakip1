using Business;
using Business.Services;
using DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace MyProject.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<ServiceResult<IEnumerable<Department>>> GetAllAsync()
        //{
        //    var departments = await _context.Departments
        //        .Include(d => d.Users)
        //        .ToListAsync();

        //    return ServiceResult<IEnumerable<Department>>.SuccessResult(departments);
        //}

        public async Task<ServiceResult<Department>> GetByIdAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Users)
                .FirstOrDefaultAsync(d => d.Id == id);

            return department == null
                ? ServiceResult<Department>.Fail("Bölüm bulunamadı.")
                : ServiceResult<Department>.Success(department);
        }

        public async Task<ServiceResult<Department>> CreateAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return ServiceResult<Department>.Success(department);
        }

        public async Task<ServiceResult<bool>> UpdateAsync(Department department)
        {
            if (!await _context.Departments.AnyAsync(d => d.Id == department.Id))
                return ServiceResult<bool>.Fail("Bölüm bulunamadı.");

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Success(true);
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return ServiceResult<bool>.Fail("Bölüm bulunamadı.");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Success(true);
        }

        public async Task<ServiceResult<bool>> AddUserToDepartmentAsync(int departmentId, User user)
        {
            var department = await _context.Departments
                .Include(d => d.Users)
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            if (department == null)
                return ServiceResult<bool>.Fail("Bölüm bulunamadı.");

            user.DepartmentId = departmentId;
            department.Users.Add(user);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Success(true);
        }

        public async Task<ServiceResult<bool>> RemoveUserFromDepartmentAsync(int departmentId, int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId && u.DepartmentId == departmentId);

            if (user == null)
                return ServiceResult<bool>.Fail("Bölüm bulunamadı.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Success(true);
        }
    }
}
