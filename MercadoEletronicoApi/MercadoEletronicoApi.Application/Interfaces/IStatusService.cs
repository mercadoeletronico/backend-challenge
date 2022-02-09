using MercadoEletronicoApi.Application.DTOs;
using System.Threading.Tasks;

namespace MercadoEletronicoApi.Application.Interfaces
{
    public interface IStatusService
    {
        Task<StatusResponseDTO> UpdateStatus(StatusRequestDTO request);
    }
}
