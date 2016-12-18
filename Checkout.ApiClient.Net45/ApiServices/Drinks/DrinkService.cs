using Checkout.ApiServices.Drinks.RequestModels;
using Checkout.ApiServices.Drinks.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Drinks
{
    public class DrinkService
    {
        public HttpResponse<Drink> CreateDrink(string name, DrinkCreate requestModel)
        {
            return new ApiHttpClient().PostRequest<Drink>(ApiUrls.Drinks, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<Drink> GetDrink(string drinkId)
        {
            var getDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().GetRequest<Drink>(getDrinkUri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> UpdateDrink(string drinkId, DrinkUpdate requestModel)
        {
            var updateDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().PutRequest<OkResponse>(updateDrinkUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteDrink(string drinkId)
        {
            var deleteDrinkUri = string.Format(ApiUrls.Drink, drinkId);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteDrinkUri, AppSettings.SecretKey);
        }

        public HttpResponse<DrinkList> GetDrinkList()
        {
            var getDrinkListUri = string.Format(ApiUrls.Drinks);
            return new ApiHttpClient().GetRequest<DrinkList>(getDrinkListUri, AppSettings.SecretKey);
        }

        public HttpResponse<DrinkList> GetDrinkList(string name)
        {
            var qs = $"?name={name}";
            var getDrinkListUri = string.Concat(ApiUrls.Drinks, qs);
            return new ApiHttpClient().GetRequest<DrinkList>(getDrinkListUri, AppSettings.SecretKey);
        }
    }
}