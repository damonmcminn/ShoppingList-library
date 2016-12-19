using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShoppingList.ApiServices.SharedModels
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        Asc,
        Desc
    }
}
