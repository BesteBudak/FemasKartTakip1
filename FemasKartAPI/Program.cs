using Business;
using Business.Cards;
using Business.Photoes;
using Business.Services;
using Business.Users;
using DataAccess;
using DataAccess.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGenericRepository<ApprovalProcess>, ApprovalProcessRepository>();
builder.Services.AddScoped<IGenericRepository<Card>, CardRepository>();
builder.Services.AddScoped<IGenericRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IGenericRepository<Photo>, PhotoRepository>();
builder.Services.AddScoped<IGenericRepository<Software>, SoftwareRepository>();
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();

//builder.Services.AddScoped<IPhotoService>(provider =>
//{
//    var env = provider.GetRequiredService<IWebHostEnvironment>();
//    return new PhotoService(env.WebRootPath);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
