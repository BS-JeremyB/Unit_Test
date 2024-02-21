using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.APP.Mock
{
    public interface IDatabaseConnection
    {
        bool CreateUser(string username, string password, int age);
        bool UpdateUserAge(string username, int newAge);
        bool Login(string username, string password);
    }
    
}
