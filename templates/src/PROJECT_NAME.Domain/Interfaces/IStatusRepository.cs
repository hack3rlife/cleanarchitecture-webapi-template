using System.Threading.Tasks;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Domain.Interfaces
{
    public interface IStatusRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Status> GetStatusAsync();
    }
}
