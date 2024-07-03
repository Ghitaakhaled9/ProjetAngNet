using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactlyBDContext dbcontext;
        public ContactController(ContactlyBDContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllContacts(){
            var contacts = dbcontext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddRequestDTO request)
        {
            var domainModelContact = new Contact
            {
                id = Guid.NewGuid(),
                name = request.name,
                email = request.email,
                phone = request.phone,
                favorite = request.favorite
            };
            dbcontext.Contacts.Add(domainModelContact);
            dbcontext.SaveChanges();
            return Ok(domainModelContact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbcontext.Contacts.Find(id);
            if (contact is not null)
            { 
                dbcontext.Contacts.Remove(contact);
                dbcontext.SaveChanges();
            }
            return Ok();
        }
    }
}
