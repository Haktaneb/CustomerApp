using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CustomerApp.Models
{
    public class DeviceEntity
    {
        
        public string Id { get; set; }
        public int Status { get; set; }      
        public string Description { get; set; }
    }
}
