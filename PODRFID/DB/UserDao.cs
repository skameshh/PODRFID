using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PODRFID.DB
{
   public class UserDao
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Name { set; get; }
        public string Dept { set; get; }
        public string Password { set; get; }
    }
}
