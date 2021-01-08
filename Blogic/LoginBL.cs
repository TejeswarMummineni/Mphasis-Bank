using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness_Entities;
using DAL;

namespace Blogic
{
    public class LoginBL
    {
        LoginDAL ld = new LoginDAL();
        public int Loginvalidate(LoginEntites log)
        {
            return ld.Loginvalidate(log);
        }
    }
}
