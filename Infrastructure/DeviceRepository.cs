using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class DeviceRepository : IDeviceRepository
    {
        readonly DeviceContext _context;

        public DeviceRepository(DeviceContext context)
        {
            _context = context;
        }

        public async Task<int> AddDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return device.Id;
        }
    }
}
