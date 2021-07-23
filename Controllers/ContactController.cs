using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;
using ContactWebApi.BusinessLayer;
using ContactWebApi.Models;
using System.Web.Http;



namespace ContactWebApi.Controllers
{
    public class ContactController : ApiController
    {
        private IContactBusinessLayer _objContactBal;

        public ContactController(IContactBusinessLayer objContactBal)
        {
            _objContactBal = objContactBal;

        }
        [Route("api/Contact/GetListContacts")]
        [HttpGet]
        public Object GetListContacts()
        {
            return _objContactBal.GetListContacts();
        }

        [Route("api/Contact/GetListContactsByID")]
        [HttpGet]
        public Object GetListContactsByID(string ID)
        {
            return _objContactBal.GetListContacts(ID);
        }

        [Route("api/Contact/AddContacts")]
        [HttpPost]
        public Object AddContacts([FromBody]  Contact objContact)
        {
            return _objContactBal.AddContacts(objContact);
        }

        [Route("api/Contact/DeleteContacts")]
        [HttpPost]
        public Object DeleteContacts([FromBody] Contact objContact)
        {
            return _objContactBal.DeleteContacts(objContact);
        }

        [Route("api/Contact/UpdateContacts")]
        [HttpPost]
        public Object UpdateContacts([FromBody] Contact objContact)
        {
            return _objContactBal.EditContacts(objContact);
        }
    }
}
