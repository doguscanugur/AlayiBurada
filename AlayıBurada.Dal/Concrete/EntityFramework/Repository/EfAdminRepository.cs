using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Dal.Concrete.EntityFramework.Repository {
    public class EfAdminRepository : EfGenericRepository<Admin>, IAdminRepository {
        public Admin AdminLogin (string userName, string password) {

            return context.Admin.Where(x => x.AdminUserName == userName && x.AdminPassword == password).FirstOrDefault();
        }
    }
}
