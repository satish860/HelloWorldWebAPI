using HelloWorldWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using HelloWorldWebAPI;


namespace TodoApi.UnitTest
{
    [TestFixture]
    public class HiloControllerTest
    {
        [Test]
        public void Should_Get_the_HiloRangeResult_From_Query()
        {
            new TodoBootStrap().ConfigureDatabaseForTest().SeedDatabase();
            dynamic Controller = TestInstance.HiloController;
            HiloRangeResult Result=Controller.GetNextRange("Todo");
            Result.High.Should().Be(1);
            Result.Capacity.Should().Be(10);
        }
    }
}
