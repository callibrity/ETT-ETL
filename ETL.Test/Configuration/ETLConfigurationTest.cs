using Xunit;
using System;
using ETL.Configuration;

namespace ETL.Test.Configuration
{
    public class ETLConfigurationTest
    {
        [Fact]
        public void ShouldRetrieveValueFromEnvironmentVariableFirst()
        {
            string expected = "Other Value";
            Environment.SetEnvironmentVariable("Test", expected);
            string actual = ETLConfiguration.GetValue("Test");
            Environment.SetEnvironmentVariable("Test", "");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldRetrieveValueFromAppSettingsLast()
        {
            string expected = "Value";
            string actual = ETLConfiguration.GetValue("Test");
            Assert.Equal(expected, actual);
        }
    }
}
