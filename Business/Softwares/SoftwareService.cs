using Business.Requests;
using DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Softwares
{
    public class SoftwareService : ISoftwareService
    {
        private readonly AppDbContext _context;

        public SoftwareService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<SoftwareResponse>> GetByIdAsync(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
                return ServiceResult<SoftwareResponse>.Fail("Yazılım bulunamadı.");

            var response = MapToResponse(software);
            return ServiceResult<SoftwareResponse>.Success(response);
        }

        public async Task<ServiceResult<List<SoftwareResponse>>> GetAllAsync()
        {
            var softwares = await _context.Softwares.ToListAsync();
            var response = softwares.Select(MapToResponse).ToList();
            return ServiceResult<List<SoftwareResponse>>.Success(response);
        }

        public async Task<ServiceResult<SoftwareResponse>> CreateAsync(CreateSoftwareRequest request)
        {
            var software = new Software
            {
                Name = request.Name,
                FarmwareCode = request.FarmwareCode,
                FileType = request.FileType,
                ApprovalCode = request.ApprovalCode,
                Description = request.Description,
                Status = true
            };

            await _context.Softwares.AddAsync(software);
            await _context.SaveChangesAsync();

            return ServiceResult<SoftwareResponse>.Success(MapToResponse(software));
        }

        public async Task<ServiceResult<SoftwareResponse>> UpdateAsync(int id, UpdateSoftwareRequest request)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
                return ServiceResult<SoftwareResponse>.Fail("Yazılım bulunamadı.");

            software.Name = request.Name;
            software.FarmwareCode = request.FarmwareCode;
            software.FileType = request.FileType;
            software.ApprovalCode = request.ApprovalCode;
            software.Description = request.Description;
            software.Status = request.Status;

            _context.Softwares.Update(software);
            await _context.SaveChangesAsync();

            return ServiceResult<SoftwareResponse>.Success(MapToResponse(software));
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
                return ServiceResult<bool>.Fail("Yazılım bulunamadı.");

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Success(true);
        }

        public async Task<ServiceResult<SoftwareRevisionResponse>> AddRevisionAsync(AddSoftwareRevisionRequest request)
        {
            var software = await _context.Softwares.FindAsync(request.SoftwareId);
            if (software == null)
                return ServiceResult<SoftwareRevisionResponse>.Fail("Yazılım bulunamadı.");

            string filePath = null;
            if (request.File != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                filePath = Path.Combine(uploadsFolder, request.File.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }
            }

            var revision = new SoftwareRevision
            {
                SoftwareId = request.SoftwareId,
                ApprovalCode = request.ApprovalCode,
                Notes = request.Notes,
                FilePath = filePath,
                CreatedDate = DateTime.Now
            };

            await _context.SoftwareRevisions.AddAsync(revision);
            await _context.SaveChangesAsync();

            var response = new SoftwareRevisionResponse
            {
                Id = revision.Id,
                SoftwareId = revision.SoftwareId,
                ApprovalCode = revision.ApprovalCode,
                Notes = revision.Notes,
                FilePath = revision.FilePath,
                CreatedDate = revision.CreatedDate
            };

            return ServiceResult<SoftwareRevisionResponse>.Success(response);
        }

        // Mapping helper
        private SoftwareResponse MapToResponse(Software software)
        {
            return new SoftwareResponse
            {
                Id = software.Id,
                Name = software.Name,
                FarmwareCode = software.FarmwareCode,
                FileType = software.FileType,
                ApprovalCode = software.ApprovalCode,
                Description = software.Description,
                Status = software.Status
            };
        }
    }


}
