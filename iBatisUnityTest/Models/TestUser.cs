using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iBatisUnityTest.Models
{
    public class TestUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Password { get; set; }
    }
}