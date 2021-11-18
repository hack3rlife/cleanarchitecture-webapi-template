using System.Threading.Tasks;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Domain.Interfaces
{
    public interface IStatusService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The service <see cref="Status"/></returns>
        Task<Status> GetStatusAsync();
    }
}
