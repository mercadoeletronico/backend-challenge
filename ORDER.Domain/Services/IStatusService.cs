using ORDER.Domain.Dto;

namespace ORDER.Domain.Services
{
    public interface IStatusService
    {
        StatusResponseDto ApprovedStatus(StatusRequestDto request);
    }
}