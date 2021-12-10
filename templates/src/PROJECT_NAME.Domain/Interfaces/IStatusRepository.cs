using System.Threading.Tasks;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Domain.Interfaces
{
    public interface IStatusRepository
    {
        /// <summary>
        /// Gets the service status
        /// </summary>
        /// <returns>The Service <see cref="Status"/></returns>
        Task<Status> GetStatusAsync();
    }
}
