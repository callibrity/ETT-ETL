using NUnit.Framework;
using ETL;

namespace ETL.Test
{
    public class Tests
    {
        private Class1 temp;

        [SetUp]
        public void Setup()
        {
            temp = new Class1();
        }

        [Test]
        public void doNothing_shouldreturn_1()
        {
            Assert.AreEqual(temp.doNothing(),1);
        }
    }
}