using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactInfoMaintain.Controllers
{
    public class ContactAPIController : ApiController
    {
        [Route("api/ContactAPI/InsertContact")]
        [HttpPost]
        public ContactDetail InsertContact(ContactDetail _Contact)
        {
            using (masterEntities entities = new masterEntities())
            {
                entities.ContactDetails.Add(_Contact);
                entities.SaveChanges();
            }

            return _Contact;
        }

        [Route("api/ContactAPI/UpdateContact")]
        [HttpPost]
        public bool UpdateContact(ContactDetail _Contact)
        {
            using (masterEntities entities = new masterEntities())
            {
                ContactDetail updatedContact = (from c in entities.ContactDetails
                                            where c.ID == _Contact.ID
                                            select c).FirstOrDefault();
                updatedContact.FirstName = _Contact.FirstName;
                updatedContact.LastName = _Contact.LastName;
                updatedContact.Email = _Contact.Email;
                updatedContact.PhoneNumber = _Contact.PhoneNumber;
                updatedContact.AvailabiltyStatus = _Contact.AvailabiltyStatus;

                entities.SaveChanges();
            }

            return true;
        }

        [Route("api/ContactAPI/DeleteContact")]
        [HttpPost]
        public void DeleteContact(ContactDetail _Contact)
        {
            using (masterEntities entities = new masterEntities())
            {
                ContactDetail Contact = (from c in entities.ContactDetails
                                         where c.ID == _Contact.ID
                                     select c).FirstOrDefault();
                entities.ContactDetails.Remove(Contact);
                entities.SaveChanges();
            }
        }




    }
}
