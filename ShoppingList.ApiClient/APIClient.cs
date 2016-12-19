using ShoppingList.ApiServices.Drinks;
using ShoppingList.Helpers;

namespace ShoppingList
{
    public sealed class APIClient
    {
        private DrinkService _drinkService;

        public DrinkService DrinkService => _drinkService ?? (_drinkService = new DrinkService());

        public APIClient()
        {
            if (AppSettings.Environment == Environment.Undefined)
            {
                AppSettings.SetEnvironmentFromConfig();
            }

            ContentAdaptor.Setup();
        }

        public APIClient(Environment env, bool debugMode, int connectTimeout)
            : this(env, debugMode)
        {
            AppSettings.RequestTimeout = connectTimeout;
        }

        public APIClient(Environment env, bool debugMode)
            : this(env)
        {
            AppSettings.DebugMode = debugMode;
        }

        public APIClient(Environment env)
        {
            AppSettings.Environment = env;
            ContentAdaptor.Setup();
        }

        public APIClient(bool debugMode) : this()
        {
            AppSettings.DebugMode = debugMode;
        }
    }
}
