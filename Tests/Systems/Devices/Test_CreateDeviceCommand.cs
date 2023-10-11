using Application.Interfaces;
using Application.UseCases.Command;
using Domain;
using Domain.DTO;
using FluentAssertions;
using MediatR;
using Moq;

namespace Tests.Systems.Devices
{
    public  class Test_CreateDeviceCommand
    {
        //should return the created id
        [Fact]
        public async Task CreateDeviceCommand_Should_returnCreatedId_WhenSuccess()
        {
            //arrange
            var mockRepo = new Mock<IDeviceRepository>();
            mockRepo.Setup(x => x.AddDevice(It.IsAny<Device>())).Callback<Device>(d => d = new Device { Name = "SampleDevice", UserId = 1 }).ReturnsAsync(1);

            var command = new CreateDeviceCommand(new CreateDeviceDTO { UserId = 1, DeviceName = "SampleDevice" });
            var handler = new CreateDeviceCommandHandler(mockRepo.Object);

            //act
            var result = await handler.Handle(command, default);

            //assert
            result.Should().Be(1);
        }

        //should use repo adddevice
        [Fact]
        public async Task CreateDeviceCommand_Should_UseRepoAddMethod_WhenSuccess()
        {
            //arrange
            var mockRepo = new Mock<IDeviceRepository>();
            mockRepo.Setup(x => x.AddDevice(It.IsAny<Device>())).Callback<Device>(d => d = new Device { Name = "SampleDevice", UserId = 1 }).ReturnsAsync(1).Verifiable();

            var command = new CreateDeviceCommand(new CreateDeviceDTO { UserId = 1, DeviceName = "SampleDevice" });
            var handler = new CreateDeviceCommandHandler(mockRepo.Object);

            //act
            var result = await handler.Handle(command, default);

            //assert
            mockRepo.Verify();
        }
    }
}
