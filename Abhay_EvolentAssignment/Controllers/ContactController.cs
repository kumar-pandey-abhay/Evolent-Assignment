using Abhay_EvolentAssignment.Models;
using AutoMapper;
using Common;
using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Abhay_EvolentAssignment.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _contactService;
        private IUserService _UserService;
        public ContactController(IContactService contractService, IUserService userService)
        {
            _contactService = contractService;
            _UserService = userService;

        }
        [Authorize]
        [HttpGet]
        [Route("api/contact/Users/GetAll")]
        public List<Users> GetUsers()
        {
            return _UserService.GetUsers();
        }
        [Authorize]
        [HttpPost]
        [Route("api/contact/AddContact")]
        public void AddContact([FromBody]ContactViewModel contact)
        {
            var userName = User.Identity.Name;
            var userId = _UserService.GetUserIdByName(userName);
            var contactModel = Mapper.Map<ContactBusinessModel>(contact);
            contactModel.CreatedByUserId = userId;
            _contactService.AddContact(contactModel);
        }

        [Authorize]
        [HttpGet]
        [Route("api/contact/GetAll")]
        public List<Contact> GetAllContacts()
        {
            return _contactService.GetContacts();
        }
        [Authorize]
        [HttpPost]
        [Route("api/contact/UpdateContact")]
        public string UpdateContact([FromBody]ContactViewModel contact)
        {
            var userName = User.Identity.Name;
            var userId = _UserService.GetUserIdByName(userName);
            var contactModel = Mapper.Map<ContactBusinessModel>(contact);
            contactModel.ModifiedByUserId = userId;
            return _contactService.UpdateContact(contactModel);
        }

        [Authorize]
        [HttpPost]
        [Route("api/contact/UpdateStatus")]
        public string UpdateStatus([FromBody] StatusUpdateModel statusUpdateModel)
        {
            var userName = User.Identity.Name;
            var userId = _UserService.GetUserIdByName(userName);
            var isUpdated = _contactService.UpdateStatus(statusUpdateModel.Id, statusUpdateModel.Status, userId);
            return isUpdated ? "Status updated successfully" : "Unable to update status";
        }

    }
}
