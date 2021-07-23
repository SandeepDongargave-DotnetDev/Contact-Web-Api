using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactWebApi.BusinessLayer
{
   public interface IContactBusinessLayer
    {
        Object GetListContacts();
        Object AddContacts(Contact objContact);

        Object EditContacts(Contact objContact);

        Object DeleteContacts(Contact objContact);
        Object GetListContacts(String Id);
    }
}
