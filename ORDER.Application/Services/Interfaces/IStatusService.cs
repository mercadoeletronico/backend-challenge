using ORDER.Application.Dto;

namespace ORDER.Application.Services.Interfaces
{
    public interface IStatusService
    {
        StatusResponseDto ApprovedStatus(StatusRequestDto request);
    }
}