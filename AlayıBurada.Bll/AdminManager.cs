using AlayıBurada.Dal.Abstract;
using AlayıBurada.Entities.Models;
using AlayıBurada.Entities.PocoModel;
using AlayıBurada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlayıBurada.Bll
{
    public class AdminManager : GenericManager<Admin>, IAdminService
    {

        IAdminRepository adminRepository;

        public AdminManager(IAdminRepository adminRepository) : base(adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public PocoAdmin AdminLogin(string userName, string password)
        {

            if (string.IsNullOrEmpty(userName.Trim()))
            {
                throw new Exception("You have to fill Admin Name field.");
            }
            if (string.IsNullOrEmpty(password.Trim()))
            {
                throw new Exception("You have to fill Password field.");
            }
            var pass = new ToPasswordRepository().Sha512(password);
            var admin = adminRepository.AdminLogin(userName, pass);
            if (admin == null)
            {
                throw new Exception("Admin Name or Password is wrong.");
            }
            else
            {
                return new PocoAdmin
                {
                    AdminUserName = userName,
                    AdminPassword = password,
                };
            }
        }
    }
}
