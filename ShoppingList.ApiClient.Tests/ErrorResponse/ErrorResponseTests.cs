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
           var response = CheckoutClient.DrinkService.GetDrinkList("coke");

           response.Should().NotBeNull();
           response.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}