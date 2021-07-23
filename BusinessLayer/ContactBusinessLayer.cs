using ContactWebApi.DataAccessLayer;
using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactWebApi.BusinessLayer
{
    public class ContactBusinessLayer: IContactBusinessLayer
    {
        private IContactDataAccesslayer _objContactDal;

        public ContactBusinessLayer(IContactDataAccesslayer objContactDal)
        {
            _objContactDal = objContactDal;

        }

        public object AddContacts(Contact objContact)
        {
            return _objContactDal.AddContacts(objContact);
        }

       

        public object DeleteContacts( Contact objContact)
        {
            return _objContactDal.DeleteContacts(objContact);
        }

        public object EditContacts()
        {
            return _objContactDal.GetListContacts();
        }

        public object EditContacts(Contact objContact)
        {
            return _objContactDal.EditContacts(objContact);
        }

        public Object GetListContacts()
        {
            return _objContactDal.GetListContacts();
        }

        public object GetListContacts(String ID)
        {
            return _objContactDal.GetListContacts(ID);
        }
    }
}