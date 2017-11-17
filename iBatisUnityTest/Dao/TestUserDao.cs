using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using iBatisUnityTest.Models;

namespace iBatisUnityTest.Dao
{
    public class TestUserDao : ITestUserDao
    {
        public int AddUser(TestUser user, ISqlMapper sqlMapper)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(sqlMapper.Insert("TestUser.AddUser", user));
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }

        public int DeleteUser(TestUser user, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = Convert.ToInt32(sqlMapper.Delete("TestUser.DeleteUser", user));
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public IList<TestUser> GetAllUserBySql(string sqlStr, ISqlMapper sqlMapper)
        {
            IList<TestUser> users = new List<TestUser>();
            try
            {
                users = sqlMapper.QueryForList<TestUser>("TestUser.GetAllUserBySql", sqlStr);
            }
            catch (Exception)
            {

                throw;
            }
            return users;
        }

        public int UpdateUser(TestUser user, ISqlMapper sqlMapper)
        {
            int count = 0;
            try
            {
                count = Convert.ToInt32(sqlMapper.Update("TestUser.UpdateUser", user));
            }
            catch (Exception)
            {
                throw;
            }
            return count;
        }
    }
}