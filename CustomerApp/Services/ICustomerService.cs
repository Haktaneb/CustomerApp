using CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    public interface ICustomerService
    {
        CustomerSearchResultApiModel Search(string searchTerm, int pageSize, int pageNumber,string deviceId);
        DeviceSearchResultApiModel DeciveControl(string deviceId);
        bool UpdateCustomer(string accountNum , string name , string phone , string address , string dataAreaId , string email , Int64 recId);
    }
}
