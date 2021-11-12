using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Interfaces
{
    public interface IAdminService:IGenericService<Admin>
    {
        //Sadece bu entity'e özgü metodlar gelecek.
        PocoAdmin AdminLogin (string userName, string password);
    }
}
