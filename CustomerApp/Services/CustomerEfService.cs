namespace CustomerApp.Services
{
    using CustomerApp.DAL;
    using CustomerApp.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class CustomerEfService : ICustomerService
    {
        public readonly CustomerContext db;
        private List<DeviceEntity> deviceExist;

        public CustomerEfService(CustomerContext db)
        {
            this.db = db;
        }

        public DeviceSearchResultApiModel DeciveControl(string deviceId)
        {         
            var model = new DeviceSearchResultApiModel();
            var query = db.Devices.Where(d => d.Id == (deviceId));
            model.ResultCount = query.Count();
            model.Results = query;
            return model;
        }   

        public CustomerSearchResultApiModel Search(string searchTerm, int pageSize, int pageNumber,string deviceId)
        {
            var model = new CustomerSearchResultApiModel();
            deviceExist = db.Devices.Where(d => d.Id == (deviceId)).ToList();
            var ActiveDevice= deviceExist.Find(d => d.Id == deviceId && d.Status == 1);
            
            if (ActiveDevice != null)
            {
                var query = db.Customers.Where(c => c.Name.Contains(searchTerm) ||
                                               c.Id.Contains(searchTerm));

                model.ResultCount = query.Count();

                model.PageCount = (model.ResultCount + pageSize - 1) / pageSize;

                var skipVal = (pageNumber - 1) * pageSize;

                model.Results = query.Skip(skipVal).Take(pageSize);
                return model;
            }        
                return null;          
        }

        public bool UpdateCustomer(string accountNum , string name , string phone , string address , string dataAreaId , string email , Int64 recId)
        {
            try
            {
                CustomerEntity thisrole = (from x in db.Customers
                              where x.RecId == recId
                              select x).First();
                thisrole.Id = accountNum;
                thisrole.Name = name;
                thisrole.Phone = phone;
                thisrole.Email = email;
                thisrole.Address = address;
                db.SaveChanges();
               // db.Update(thisrole);
                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
  
    }