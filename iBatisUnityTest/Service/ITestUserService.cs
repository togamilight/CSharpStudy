using iBatisUnityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBatisUnityTest.Service
{
    public interface ITestUserService
    {
        int AddUser(TestUser user);
        int UpdateUser(TestUser user);
        IList<TestUser> GetAllUserBySql(string sqlStr);
        int DeleteUser(TestUser user);
    }
}
