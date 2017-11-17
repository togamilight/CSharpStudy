using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iBatisUnityTest.Models;
using IBatisNet.DataMapper;

namespace iBatisUnityTest.Dao
{
    public interface ITestUserDao
    {
        int AddUser(TestUser user, ISqlMapper sqlMapper);
        int UpdateUser(TestUser user, ISqlMapper sqlMapper);
        IList<TestUser> GetAllUserBySql(string sqlStr, ISqlMapper sqlMapper);
        int DeleteUser(TestUser user, ISqlMapper sqlMapper);
    }
}
