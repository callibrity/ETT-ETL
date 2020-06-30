using NUnit.Framework;
using ETL.Repository;
using System.Collections.Generic;

namespace ETL.Repository.Test
{
    public class DBConnectionTest
    {
        private class TestClass
        {
            public string str;
            public int num;

            public TestClass(string str, int num)
            {
                this.str = str;
                this.num = num;
            }
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void should_create_db_connection_object()
        {
            DBConnection con = new DBConnection();
        }

        [Test]
        public void connection_should_initially_be_closed()
        {
            DBConnection con = new DBConnection();
            Assert.IsFalse(con.IsConnectionOpen);
        }

        [Test]
        public void should_connect_to_database()
        {

            DBConnection con = new DBConnection();
            con.Connect();
            Assert.IsTrue(con.IsConnectionOpen);
        }

        [Test]
        public void should_close_connection()
        {
            DBConnection con = new DBConnection();
            con.Connect();
            con.Dispose();
            Assert.IsFalse(con.IsConnectionOpen);
        }

        [Test]
        public void should_close_connection_after_disposal()
        {
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
            }

            Assert.IsFalse(con.IsConnectionOpen);
        }

        [Test]
        public void should_have_one_row()
        {
            List<TestClass> temp = null;
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
                temp = con.ExecuteQuery<TestClass>(@"Select 'hi', 7");
            }
            Assert.AreEqual("hi", temp[0].str);
            Assert.AreEqual(7, temp[0].num);
        }

        [Test]
        public void should_return_negative_one_on_query()
        {
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
                Assert.AreEqual(-1, con.ExecuteNonQuery("Select NOW()"));
            }

        }


    }
}