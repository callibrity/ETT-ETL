using Xunit;
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

        [Fact]
        public void should_create_db_connection_object()
        {
            DBConnection con = new DBConnection();
        }

        [Fact]
        public void connection_should_initially_be_closed()
        {
            DBConnection con = new DBConnection();
            Assert.False(con.IsConnectionOpen);
        }

        [Fact]
        public void should_connect_to_database()
        {

            DBConnection con = new DBConnection();
            con.Connect();
            Assert.True(con.IsConnectionOpen);
        }

        [Fact]
        public void should_close_connection()
        {
            DBConnection con = new DBConnection();
            con.Connect();
            con.Dispose();
            Assert.False(con.IsConnectionOpen);
        }

        [Fact]
        public void should_close_connection_after_disposal()
        {
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
            }

            Assert.False(con.IsConnectionOpen);
        }

        [Fact]
        public void should_have_one_row()
        {
            List<TestClass> temp = null;
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
                temp = con.ExecuteQuery<TestClass>(@"Select 'hi', 7");
            }
            Assert.Equal("hi", temp[0].str);
            Assert.Equal(7, temp[0].num);
        }

        [Fact]
        public void should_return_negative_one_on_query()
        {
            DBConnection con;
            using (con = new DBConnection())
            {
                con.Connect();
                Assert.Equal(-1, con.ExecuteNonQuery("Select NOW()"));
            }

        }


    }
}