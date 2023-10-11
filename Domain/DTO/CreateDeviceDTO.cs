using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CreateDeviceDTO
    {
        public int UserId { get; set; }
        public string DeviceName { get; set; } = null!;
    }
}
