using NUnit.Framework;
using ETL.Repository;
using System;

namespace ETL.Test
{
    public class DBTest
    {

        [SetUp]
        public void Setup()
        { }

        [Test]
        public void should_create_db_connection_object()
        {
            DB_Connection con = new DB_Connection("", "", "", "");
            Assert.Pass();
        }

        [Test]
        public void should_connect_to_database()
        {

            DB_Connection con = new DB_Connection("104.196.62.171", "postgres", "callibrity", "postgres");
            con.Connect();
            Assert.Pass();
        }

        [Test]
        public void should_close_connection()
        {

            using (DB_Connection con = new DB_Connection("104.196.62.171", "postgres", "callibrity", "postgres"))
            {
                con.Connect();
            }
            Assert.Pass();
        }
    }
}