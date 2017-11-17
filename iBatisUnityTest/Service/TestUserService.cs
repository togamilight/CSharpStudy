using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iBatisUnityTest.Models;
using iBatisUnityTest.DataMapper;
using iBatisUnityTest.Dao;

namespace iBatisUnityTest.Service
{
    public class TestUserService : ITestUserService
    {
        public IMapper DataMapper { get; set;}
        public ITestUserDao UserDao { get; set; }

        public int AddUser(TestUser user)
        {
            int id = 0;
            try
            {
                id = UserDao.AddUser(user, DataMapper.Instance);
            }
            catch (Exception)
            {

                throw;
            }
            return id;
        }

        public int DeleteUser(TestUser user)
        {
            int count = 0;
            try
            {
                count = UserDao.DeleteUser(user, DataMapper.Instance);
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public IList<TestUser> GetAllUserBySql(string sqlStr)
        {
            IList<TestUser> users = new List<TestUser>();
            try
            {
                users = UserDao.GetAllUserBySql(sqlStr, DataMapper.Instance);
            }
            catch (Exception)
            {

                throw;
            }
            return users;
        }

        public int UpdateUser(TestUser user)
        {
            int count = 0;
            try
            {
                count = UserDao.UpdateUser(user, DataMapper.Instance);
            }
            catch (Exception)
            {
                throw;
            }
            return count;
        }
    }
}