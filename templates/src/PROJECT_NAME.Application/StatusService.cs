using PROJECT_NAME.Domain.Entities;
using PROJECT_NAME.Domain.Interfaces;
using System.Threading.Tasks;

namespace PROJECT_NAME.Application
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status> GetStatusAsync()
        {
           return await _statusRepository.GetStatusAsync();
        }
    }
}
