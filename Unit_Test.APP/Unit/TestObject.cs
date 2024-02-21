using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.APP.Unit
{
    public class TestObject
    {
        public TestObject()
        {
            salary = 1000;
        }
        public int salary { get; set; }

    }

    public class TestObjectChild : TestObject
    {
        public TestObjectChild()
        {
            salary = 2000;
        }
    }

    public static class ObjectFactory
    {
        public static TestObject CreateObject(int yearOfCareer)
        {
            if (yearOfCareer > 5)
            {
                return new TestObjectChild();
            }
            return new TestObject();
        }
    }
}
