using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Abstract {
    public interface IAdminRepository:IGenericRepository<Admin> {

        Admin AdminLogin (string userName, string password);
    }
}
