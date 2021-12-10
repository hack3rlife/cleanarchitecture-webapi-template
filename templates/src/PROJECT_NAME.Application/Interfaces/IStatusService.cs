using PROJECT_NAME.Application.Dtos;
using System.Threading.Tasks;

namespace PROJECT_NAME.Application.Interfaces
{
    public interface IStatusService
    {
        /// <summary>
        /// Get the status of the service
        /// </summary>
        /// <returns>The <see cref="StatusResponse"/></returns>
        Task<StatusResponse> GetStatusAsync();
    }
}
