namespace CustomerApp.Controllers
{
    using CustomerApp.Models;
    using CustomerApp.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public IActionResult Search([FromBody] CustomerSearchRequestApiModel request)
        {
            var searchResult = customerService.Search(request.SearchTerm, request.PageSize, request.PageNumber,request.DeviceId);
            if (searchResult == null)
            {
                return BadRequest();
                
            }
            return Ok(searchResult);

        }
        [HttpPost]
        public IActionResult DeviceControl([FromBody] DeviceEntity device)
        {
            var searchResult = customerService.DeciveControl(device.Id);
            if (searchResult.ResultCount == 0)
            {
                return BadRequest();

            }
            return Ok(searchResult);

        }
        [HttpPost]
        public IActionResult UpdateCustomer([FromBody] CustomerEntity customer)
        {
            var searchResult = customerService.UpdateCustomer(customer.Id, customer.Name, customer.Phone, customer.Address, customer.DataAreaId, customer.Email, customer.RecId);
            if (searchResult == false)
            {
                return BadRequest();

            }
            return Ok();

        }
    }
}