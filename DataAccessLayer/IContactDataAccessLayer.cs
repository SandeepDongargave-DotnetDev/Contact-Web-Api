using ContactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactWebApi.DataAccessLayer
{
   public interface IContactDataAccesslayer
    {
        Object GetListContacts();
        Object GetListContacts(String Id);
        Object AddContacts( Contact objContact);

        Object EditContacts( Contact objContact);

        Object DeleteContacts( Contact objContact);
    }
}
