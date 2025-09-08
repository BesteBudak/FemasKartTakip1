using Business.Requests;
using Business.Responses;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICardService
    {
        Task<ServiceResult<CardResponse>> GetByIdAsync(int id);
        Task<ServiceResult<List<CardResponse>>> GetAllAsync();
        Task<ServiceResult<CardResponse>> CreateAsync(CreateCardRequest createDto);
        Task<ServiceResult<CardResponse>> UpdateAsync(int cardId, UpdateCardRequest updateDto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}
