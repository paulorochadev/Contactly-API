using Contactly_API.Models;
using Contactly_API.Models.Data;
using Contactly_API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext _dbContext;

        public ContactsController(ContactlyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _dbContext.Contacts.ToList();

            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO requestDTO)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = requestDTO.Name,
                Email = requestDTO.Email,
                Phone = requestDTO.Phone,
                Favorite = requestDTO.Favorite
            };

            _dbContext.Contacts.Add(domainModelContact);
            _dbContext.SaveChanges();

            return Ok(requestDTO);
        }

    }
}
