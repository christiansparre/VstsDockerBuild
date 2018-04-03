using System;
using Xunit;

namespace VstsDockerBuild.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var blowUp = Environment.GetEnvironmentVariable("BLOWUP");

            if (blowUp != null)
            {
                Assert.NotEqual("yes", blowUp);
            }

        }

        [Fact]
        public void Test2()
        {

        }

        [Fact]
        public void Test3()
        {

        }

        [Fact]
        public void Test4()
        {

        }

        [Fact]
        public void Test5()
        {

        }
    }
}
