using AutoMapper;
using PROJECT_NAME.Application.Dtos;
using PROJECT_NAME.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using IStatusService = PROJECT_NAME.Application.Interfaces.IStatusService;

namespace PROJECT_NAME.Application.Services
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

           var statusResponse = _mapper.Map<StatusResponse>(status);

            if(DateTime.TryParse(statusResponse.Started, out DateTime result))
            {
                var elapsedTime = DateTime.UtcNow - result;
                statusResponse.ElapsedTime = elapsedTime.ToString();
            }

            return statusResponse;
        }

        public async Task SetStatusAsync()
        {
            await _statusRepository.UpsertStatusAsync();
        }
    }
}
