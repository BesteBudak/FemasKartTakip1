using Business.Photoes;
using Business.Responses;
using DataAccess.Repositories;
using Entities.Models;

namespace Business.Cards
{
    public class CardService : ICardService
    {
        private readonly CardRepository _cardRepository;
        private readonly IPhotoService _photoService;

        public CardService(CardRepository cardRepository, IPhotoService photoService)
        {
            _cardRepository = cardRepository;
            _photoService = photoService;
        }

        public async Task<ServiceResult<CardResponse>> CreateAsync(CreateCardRequest createDto)
        {
            if (createDto.FieldPhotos == null || createDto.FieldPhotos.Count != 3)
                return ServiceResult<CardResponse>.Fail("3 adet alan (field) fotoğraf listesi gönderilmelidir.");

            var card = new Card
            {
                Name = createDto.Name,
                Brand = createDto.Brand,
                StockCode = createDto.StockCode,
                SupplierCode = createDto.SupplierCode,
                ApprovalCode = createDto.ApprovalCode,
                Type = createDto.Type,
                Status = createDto.Status,
                Fields = new List<CardField>()
            };

            for (int i = 0; i < 3; i++)
            {
                var photoBase64List = createDto.FieldPhotos[i];
                if (photoBase64List == null || photoBase64List.Count != 3)
                    return ServiceResult<CardResponse>.Fail($"Field{i + 1} için 3 fotoğraf gereklidir.");

                var uploadedPhotoUrls = new List<string>();

                foreach (var base64 in photoBase64List)
                {
                    var uploadResult = await _photoService.UploadBase64Async(base64);
                    if (!uploadResult.Success)
                        return ServiceResult<CardResponse>.Fail("Fotoğraf yüklenirken hata oluştu.");

                    uploadedPhotoUrls.Add(uploadResult.Url);
                }

                card.Fields.Add(new CardField
                {
                    Name = $"Field{i + 1}",
                    PhotoUrls = uploadedPhotoUrls
                });
            }

            await _cardRepository.AddAsync(card);

            var response = new CardResponse
            {
                Id = card.Id,
                Name = card.Name,
                Brand = card.Brand,
                StockCode = card.StockCode,
                SupplierCode = card.SupplierCode,
                ApprovalCode = card.ApprovalCode,
                Type = card.Type,
                Status = card.Status,
                Fields = card.Fields.Select(f => new CardFieldResponse
                {
                    Name = f.Name,
                    PhotoUrls = f.PhotoUrls
                }).ToList()
            };

            return ServiceResult<CardResponse>.Success(response);
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null)
                return ServiceResult<bool>.Fail("Kart bulunamadı.");

            _cardRepository.Delete(card);
            await _cardRepository.SaveChangesAsync();

            return ServiceResult<bool>.Success(true);
        }


        public async Task<ServiceResult<List<CardResponse>>> GetAllAsync()
        {
            
            var cards = await _cardRepository.GetAllAsync();

            var response = cards.Select(card => new CardResponse
            {
                Id = card.Id,
                Name = card.Name,
                Brand = card.Brand,
                StockCode = card.StockCode,
                SupplierCode = card.SupplierCode,
                ApprovalCode = card.ApprovalCode,
                Type = card.Type,
                Status = card.Status,
                Fields = card.Fields.Select(f => new CardFieldResponse
                {
                    Name = f.Name,
                    PhotoUrls = f.PhotoUrls
                }).ToList()
            }).ToList();

            return ServiceResult<List<CardResponse>>.Success(response);
        }


       
           public async Task<ServiceResult<CardResponse>> GetByIdAsync(int id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
            if (card == null)
                return ServiceResult<CardResponse>.Fail("Kart bulunamadı.");

            var response = new CardResponse
            {
                Id = card.Id,
                Name = card.Name,
                Brand = card.Brand,
                StockCode = card.StockCode,
                SupplierCode = card.SupplierCode,
                ApprovalCode = card.ApprovalCode,
                Type = card.Type,
                Status = card.Status,
                Fields = card.Fields.Select(f => new CardFieldResponse
                {
                    Name = f.Name,
                    PhotoUrls = f.PhotoUrls
                }).ToList()
            };

            return ServiceResult<CardResponse>.Success(response);
        }


           public async Task<ServiceResult<CardResponse>> UpdateAsync(int cardId, UpdateCardRequest updateDto)
        {
            var card = await _cardRepository.GetByIdAsync(cardId);
            if (card == null)
                return ServiceResult<CardResponse>.Fail("Kart bulunamadı.");

            // Güncellenebilir alanlar
            card.Name = updateDto.Name ?? card.Name;
            card.Brand = updateDto.Brand ?? card.Brand;
            card.StockCode = updateDto.StockCode ?? card.StockCode;
            card.SupplierCode = updateDto.SupplierCode ?? card.SupplierCode;
            card.ApprovalCode = updateDto.ApprovalCode ?? card.ApprovalCode;
            card.Type = updateDto.Type ?? card.Type;

            await _cardRepository.SaveChangesAsync();

            var response = new CardResponse
            {
                Id = card.Id,
                Name = card.Name,
                Brand = card.Brand,
                StockCode = card.StockCode,
                SupplierCode = card.SupplierCode,
                ApprovalCode = card.ApprovalCode,
                Type = card.Type,
                Status = card.Status,
                Fields = card.Fields.Select(f => new CardFieldResponse
                {
                    Name = f.Name,
                    PhotoUrls = f.PhotoUrls
                }).ToList()
            };

            return ServiceResult<CardResponse>.Success(response);
        }

    }

}