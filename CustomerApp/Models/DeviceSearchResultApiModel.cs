using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class DeviceSearchResultApiModel
    {
        public int ResultCount { get; set; }
        public IEnumerable<DeviceEntity> Results { get; set; }
    }
}
