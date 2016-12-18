using Checkout.ApiServices.Drinks.RequestModels;
using Checkout.ApiServices.Drinks.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Drinks
{
    public class DrinkService
    {
        public HttpResponse<Drink> CreateDrink(DrinkCreate requestModel)
        {
            return new ApiHttpClient().PostRequest<Drink>(ApiUrls.Drinks, requestModel);
        }

        public HttpResponse<Drink> GetDrink(string drinkId)
        {
            var getDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().GetRequest<Drink>(getDrinkUri);
        }

        public HttpResponse<Drink> UpdateDrink(string drinkId, DrinkUpdate requestModel)
        {
            var updateDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().PutRequest<Drink>(updateDrinkUri, requestModel);
        }

        public HttpResponse<OkResponse> DeleteDrink(string drinkId)
        {
            var deleteDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteDrinkUri);
        }

        public HttpResponse<DrinkList> GetDrinkList()
        {
            var getDrinkListUri = string.Format(ApiUrls.Drinks);
            return new ApiHttpClient().GetRequest<DrinkList>(getDrinkListUri);
        }

        public HttpResponse<DrinkList> GetDrinkList(string name)
        {
            var qs = $"?name={name}";
            var getDrinkListUri = string.Concat(ApiUrls.Drinks, qs);
            return new ApiHttpClient().GetRequest<DrinkList>(getDrinkListUri);
        }
    }
}