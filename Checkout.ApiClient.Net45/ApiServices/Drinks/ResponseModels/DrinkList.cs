using System.Collections.Generic;

namespace Checkout.ApiServices.Drinks.ResponseModels
{
    public class DrinkList
    {
        public int Count => Data.Count;
        public List<Drink> Data;
    }
}