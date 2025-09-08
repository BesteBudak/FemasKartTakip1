using Business.Requests;
using Business.Responses;
using DataAccess;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ApprovalService : IApprovalService
    {
        private readonly AppDbContext _context;

        public ApprovalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApprovalResponse>> GetAllAsync()
        {
            var approvalProcesses = await _context.ApprovalProcesses
                .Include(a => a.Software)
                    .ThenInclude(s => s.Cards) // 1 Software → N Cards
                .ToListAsync();

            var result = new List<ApprovalResponse>();

            foreach (var approval in approvalProcesses)
            {
                var software = approval.Software;

                if (software?.Cards == null || !software.Cards.Any())
                {
                    // Eğer yazılıma bağlı kart yoksa, boş kartlı DTO eklenebilir (opsiyonel)
                    result.Add(new ApprovalResponse
                    {
                        ApprovalId = approval.Id,
                        CardId = 0,
                        CardStockCode = "-",
                        CardName = "-",
                        SoftwareCode = software?.FarmwareCode,
                        SoftwareName = software?.Name,
                        ProgramType = software?.FileType,
                        Status = approval.Status switch
                        {
                            ApprovalStatus.Approved => "Onaylandı",
                            ApprovalStatus.Rejected => "Reddedildi",
                            ApprovalStatus.Pending => "Bekliyor",
                            _ => "Bilinmiyor"
                        },

                        Uploader = approval.Uploader
                    });
                }
                else
                {
                    foreach (var card in software.Cards)
                    {
                        result.Add(new ApprovalResponse
                        {
                            ApprovalId = approval.Id,
                            CardId = card.Id,
                            CardStockCode = card.StockCode,
                            CardName = card.Name,
                            SoftwareCode = software.FarmwareCode,
                            SoftwareName = software.Name,
                            ProgramType = software.FileType,
                            Status = approval.Status switch
                            {
                                ApprovalStatus.Approved => "Onaylandı",
                                ApprovalStatus.Rejected => "Reddedildi",
                                ApprovalStatus.Pending => "Bekliyor",
                                _ => "Bilinmiyor"
                            },

                            Uploader = approval.Uploader
                        });
                    }
                }
            }

            return result;
        }

        public async Task<bool> UpdateStatusAsync(UpdateApprovalStatusRequest request)
        {
            var approval = await _context.ApprovalProcesses.FindAsync(request.ApprovalId);
            if (approval == null)
                return false;

            approval.Status = request.NewStatus;
            await _context.SaveChangesAsync();
            return true;
        }

    }


}
