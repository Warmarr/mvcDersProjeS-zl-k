using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public Admin GetAdmin(string mail, string password)
        {
            return _adminDal.Get(x=>x.AdminUserName==mail && x.AdminPassword==password);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
