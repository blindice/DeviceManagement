using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Command
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, int>
    {
        private IDeviceRepository _repo;

        public CreateDeviceCommandHandler(IDeviceRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = new Device
            {
                Name = request.device.DeviceName,
                UserId = request.device.UserId
            };

            var result = await _repo.AddDevice(device);

            return result;
        }
    }
}
