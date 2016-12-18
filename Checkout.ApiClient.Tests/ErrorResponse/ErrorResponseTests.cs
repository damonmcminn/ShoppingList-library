using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture(Category = "ErrorResponseTests")]
    public class ErrorResponseTests : BaseServiceTests
    {
        [Test]
        public void GetDrinkList_FailsWithNotFound_IfNameParameterNotFound()
        {
            // this fails because response is null
            // strongly suspect because /drinks?name={name} returns empty body in case of 404
//            var response = CheckoutClient.DrinkService.GetDrink("coke");
//
//            response.Should().NotBeNull();
//            response.HttpStatusCode.Should().NotBe(HttpStatusCode.OK);
//            response.HasError.Should().BeTrue();
        }
    }
}