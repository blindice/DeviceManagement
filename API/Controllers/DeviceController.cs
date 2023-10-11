using Application.UseCases.Command;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        readonly ISender _sender;

        public DeviceController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("createdevice")]
        public async Task<IActionResult> CreateDeviceAsync([FromBody] CreateDeviceDTO device)
        {
            var result = await _sender.Send(new CreateDeviceCommand(device));

            return Ok(result);
        }

    }
}
