using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Test.APP.Unit;

namespace Unit_Test.TEST.Unit
{
    public class UnitTest
    {
        #region TestNumber

        [Fact]
        [Trait("Category", "Number")]
        public void AddTwoInt()
        {
            TestNumber TestNumber = new TestNumber();
            int result = TestNumber.Add(2, 2);

            Assert.Equal(4, result);
        }

        [Fact]
        [Trait("Category", "Number")]
        public void AddTwoDouble()
        {
            TestNumber TestNumber = new TestNumber();
            double result = TestNumber.Add(2.6, 2.03);

            Assert.Equal(4.6, result, 1);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(-2, -2, -4)]
        [Trait("Category", "Number")]
        public void AddTwoIntData(int a, int b, int expected)
        {
            TestNumber TestNumber = new TestNumber();
            int result = TestNumber.Add(a, b);

            Assert.Equal(expected, result);
        }

        #endregion

        #region TestString

        [Fact]
        [Trait("Category", "String")]
        public void ReturnFullName()
        {
            TestString TestString = new TestString();
            string result = TestString.FullName("john", "Doe");

            Assert.Equal("John Doe", result, ignoreCase: true);
        }

        [Fact]
        [Trait("Category", "String")]
        public void ReturnFullNameSpace()
        {
            TestString TestString = new TestString();
            string result = TestString.FullName("John", "Doe");

            Assert.Matches("^[A-Za-z]+ [A-Za-z]+$", result);
        }

        [Fact]
        [Trait("Category", "String")]
        public void ReturnFullNameStartWith()
        {
            TestString TestString = new TestString();
            string result = TestString.FullName("John", "Doe");

            Assert.StartsWith("John", result, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        [Trait("Category", "String")]
        public void ReturnFullNameStartContains()
        {
            TestString TestString = new TestString();
            string result = TestString.FullName("Jane", "Doe");

            Assert.Contains("ane", result, StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion

        #region TestNullBool

        [Fact]
        [Trait("Category", "NullBool")]
        public void UserNameNotNull()
        {
            TestNullBool TestNullBool = new TestNullBool();
            TestNullBool.UserName = "John";

            Assert.NotNull(TestNullBool.UserName);
        }

        [Fact]
        [Trait("Category", "NullBool")]
        public void UserNameIsNull()
        {
            TestNullBool TestNullBool = new TestNullBool();

            Assert.Null(TestNullBool.UserName);
            Assert.True(string.IsNullOrEmpty(TestNullBool.UserName));
        }

        #endregion

        #region TestCollection

        [Fact]
        [Trait("Category", "Collection")]
        public void FibonacciNotContains4()
        {
            TestCollection TestCollection = new TestCollection();

            Assert.DoesNotContain(4, TestCollection.fibonacciSeries);
        }

        [Fact]
        [Trait("Category", "Collection")]
        public void FibonacciExactList()
        {
            TestCollection TestCollection = new TestCollection();
            List<int> expected = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };

            Assert.Equal(expected, TestCollection.fibonacciSeries);
        }

        #endregion

        #region TestRange

        [Fact]
        [Trait("Category", "Range")]
        public void AgeInRange()
        {
            TestRange TestRange = new TestRange();

            Assert.InRange(TestRange.Age, 18, 60);
        }

        [Fact]
        [Trait("Category", "Range")]
        public void AgeNotInRange()
        {
            TestRange TestRange = new TestRange();
            TestRange.Age = 10;

            Assert.NotInRange(TestRange.Age, 18, 60);
        }
        #endregion

        #region TestException
        [Fact]
        [Trait("Category", "Exception")]
        public void DivideByZero()
        {
            TestException TestException = new TestException();

            Assert.Throws<DivideByZeroException>(() => TestException.Divide(10, 0));
        }

        #endregion

        #region TestObject
        [Fact]
        [Trait("Category", "Object")]
        public void CompareObject()
        {
            TestObject TestObject1 = new TestObject();
            TestObject TestObject2 = new TestObject();

            Assert.NotSame(TestObject1, TestObject2);
        }
        [Fact]
        [Trait("Category", "Object")]
        public void CompareObjectChild()
        {
            TestObject testObject = ObjectFactory.CreateObject(6);
            TestObject testObject2 = ObjectFactory.CreateObject(2);

            Assert.IsType<TestObjectChild>(testObject);
            Assert.IsNotType<TestObjectChild>(testObject2);
        }

        #endregion

        #region TestDataShare

        [Theory]
        [Trait("Category", "DataShare")]
        [MemberData(nameof(DataShare.IsEvenData), MemberType = typeof(DataShare))]
        public void IsEven(int number, bool expected)
        {
            TestDataShare TestDataShare = new TestDataShare();
            bool result = TestDataShare.IsEven(number);

            Assert.Equal(expected, result);
        }
        #endregion
    }
}
