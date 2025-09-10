using Business;
using Business.Requests;
using Business.Users;
using DataAccess;
using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResult<UserDto>> CreateAsync(CreateUserRequest request)

    {
        var user = new User
        {
            Name = request.UserName,
            Mail = request.Mail,

        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var dto = new UserDto
        {
            Id = user.Id,
            UserName = user.Name,
            Mail = user.Mail
        };

        return ServiceResult<UserDto>.SuccessAsCreated(dto, "Kullanıcı başarıyla oluşturuldu.");
    }


    public async Task<ServiceResult> UpdateAsync(int id, UpdateUserRequest request)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return ServiceResult.Fail("Kullanıcı bulunamadı.");

        user.Name = request.Name;
        user.Mail = request.Email;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.OK);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return ServiceResult.Fail("Kullanıcı bulunamadı.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.OK);
    }


    public async Task<ServiceResult<List<UserDto>>> GetAllListAsync()
    {
        var users = await _context.Users
            .OrderByDescending(u => u.Id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.Name,
                Mail = u.Mail
            })
            .ToListAsync();

        return ServiceResult<List<UserDto>>.Success(users);
    }

}
