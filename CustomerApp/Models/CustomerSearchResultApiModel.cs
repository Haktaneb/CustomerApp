using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class CustomerSearchResultApiModel
    {
        public int ResultCount { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<CustomerEntity> Results { get; set; }
    }
}
