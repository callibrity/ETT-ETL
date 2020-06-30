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
            Environment.SetEnvironmentVariable("TEST", expected);
            string actual = ETLConfiguration.GetValue("TEST");
            Environment.SetEnvironmentVariable("TEST", "");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldRetrieveValueFromAppSettingsLast()
        {
            string expected = "Value";
            string actual = ETLConfiguration.GetValue("TEST");
            Assert.Equal(expected, actual);
        }
    }
}
