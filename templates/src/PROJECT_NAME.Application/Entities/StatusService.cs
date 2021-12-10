using AutoMapper;
using PROJECT_NAME.Application.Dtos;
using System.Threading.Tasks;
using PROJECT_NAME.Domain.Interfaces;
using IStatusService = PROJECT_NAME.Application.Interfaces.IStatusService;

namespace PROJECT_NAME.Application.Entities
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<StatusResponse> GetStatusAsync()
        {
           var status = await _statusRepository.GetStatusAsync();

           return _mapper.Map<StatusResponse>(status);
        }
    }
}
