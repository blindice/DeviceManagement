using Domain.DTO;
using MediatR;

namespace Application.UseCases.Command
{
    public record CreateDeviceCommand(CreateDeviceDTO device) : IRequest<int>
    {}
}
