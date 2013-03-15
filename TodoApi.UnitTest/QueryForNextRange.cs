using HelloWorldWebAPI.Model;
using HelloWorldWebAPI.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using HelloWorldWebAPI;


namespace TodoApi.UnitTest
{
    [TestFixture]
    public class QueryForNextRange
    {
        [Test]
        public void Should_be_Able_to_Query_For_Next_Range()
        {
            new TodoBootStrap().ConfigureDatabaseForTest().SeedDatabase();
            dynamic Query = TestInstance.HiloRangeQuery;
            HiloRangeResult Result = Query.ExecuteWith("Todo");
            Result.Capacity.Should().Be(10);
            Result.High.Should().Be(1);
        }

        [Test]
        public void When_the_Range_is_Taken_We_Should_Start_with_nextRange()
        {
            new TodoBootStrap().ConfigureDatabaseForTest().SeedDatabase();
            dynamic Query = TestInstance.HiloRangeQuery;
            HiloRangeResult Result = Query.ExecuteWith("Todo");
            HiloRangeResult SecondResult = Query.ExecuteWith("Todo");
            SecondResult.Capacity.Should().Be(10);
            SecondResult.High.Should().Be(2);
        }
    }
}
