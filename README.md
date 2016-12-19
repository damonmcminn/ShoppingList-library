# ShoppingList-library

## Requirements

- A locally running instance of [ShoppingList](https://github.com/damonmcminn/ShoppingList)
- .Net Framework 4.5 and later

## How to use the library

- Download the sourcode from our master branch and reference it in your solution.

## Configuration

- **ShoppingList.RequestTimeout**: Set your default number of seconds to wait before the request times out on the ApiHttpClient. Default is 60.
- **ShoppingList.MaxResponseContentBufferSize**: Sets the maximum number of bytes to buffer when reading the response. Default is 10240.
- **ShoppingList.DebugMode**: If set to true, the request and response result will be logged to console. Set this option to false when going Live. Default is false;
- **ShoppingList.Environment**: You can set your environment to point to **Sandbox** or **Live**. Regardless of choice the environment is the ShoppingList development URL.

```html
<appSettings>
    <add key="ShoppingList.RequestTimeout" value="60" />
    <add key="ShoppingList.MaxResponseContentBufferSize" value="10240" />
    <add key="ShoppingList.DebugMode" value="true" />
    <add key="ShoppingList.Environment" value="Sandbox" />
</appSettings>
```

### Constructor configuration

There are many constructors available for configuring the settings programmatically and you only need to do it once. If you provide settings from constructor it will override the matching setting in the config file otherwise the library will be looking for the settings in config file.

```csharp
APIClient()
APIClient(Environment env, bool debugMode, int connectTimeout)
APIClient(Environment env, bool debugMode)
APIClient(Environment env)
APIClient(bool debugMode)
```

### Endpoints

There is a single API endpoint that the **APIClient** interacts with.

- Drinks

#### Drinks

##### Create drink example

``` csharp
// Create payload
var drinkModel = new DrinkCreate() {Name = "Pepsi"};

try
{
	// Create APIClient instance
	APIClient shoppingListApiClient = new APIClient(ShoppingList.APIClient.Helpers.Environment.Sandbox);

	// Submit your request and receive an apiResponse
	HttpResponse<Charge> apiResponse = shoppingListApiClient.DrinkService.CreateDrink(drinkModel);

	if (!apiResponse.HasError)
	{
		// Access the response object retrieved from the api
		var charge = apiResponse.Model;
	}
	else
	{
		// Api has returned an error object. You can access the details in the error property of the apiResponse.
		// apiResponse.error
	}
}
catch (Exception e)
{
	//... Handle exception
}
```

## Debug Mode

If you enable debug mode by setting the **ShoppingList.DebugMode** to true in the config file or in code all the http requests and responses will be logged in the console.

## Unit Tests

All the unit test are written with NUnit and resides in the test project.
