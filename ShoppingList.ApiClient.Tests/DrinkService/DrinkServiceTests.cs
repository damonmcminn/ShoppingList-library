using System.Net;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

using ShoppingList.ApiServices.Drinks.RequestModels;
using ShoppingList.ApiServices.Drinks.ResponseModels;

namespace Tests
{
    public class DrinkServiceTests : BaseServiceTests
    {
        private string _pepsiId;
        private string _pepsi = "Pepsi";
        private string[] _extraDrinks = { "Dr Pepper", "Fanta", "San Pellegrino", "Coffee" };
        private DrinkList _drinks;

        [TestFixtureTearDownAttribute]
        public void CleanUp()
        {
            foreach (var drink in _drinks)
            {
                CheckoutClient.DrinkService.DeleteDrink(drink.Id);
            }
        }

        [Test]
        public void CreateDrink()
        {
            var pepsi = new DrinkCreate() {Name = _pepsi};

            var response = CheckoutClient.DrinkService.CreateDrink(pepsi);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();


            _pepsiId = response.Model.Id;
        }

        [Test]
        public void GetDrink()
        {
            var response = CheckoutClient.DrinkService.GetDrink(_pepsiId);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.Name.Should().Be(_pepsi);
        }

        [Test]
        public void UpdateDrink()
        {
            var fortyTwoUnits = new DrinkUpdate() {Quantity = 42};
            var response = CheckoutClient.DrinkService.UpdateDrink(_pepsiId, fortyTwoUnits);

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.Quantity.Should().Be(42);
        }

        [Test]
        public void Z_DeleteDrink()
        {
            var response = CheckoutClient.DrinkService.DeleteDrink(_pepsiId);

            // DeleteDrink is successful, but response is null for some reason...
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Z_GetDrinkList()
        {
            foreach (var name in _extraDrinks)
            {
                CheckoutClient.DrinkService.CreateDrink(new DrinkCreate() {Name = name});
            }

            var response = CheckoutClient.DrinkService.GetDrinkList();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().NotBeNull();
            response.Model.Count.Should().Be(4);
            response.Model.Last().Name.Should().Be(_extraDrinks.Last());
            response.Model.First().Name.Should().Be(_extraDrinks.First());

            _drinks = response.Model;
        }
    }
}