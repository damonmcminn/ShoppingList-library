using Checkout;
using NUnit.Framework;

namespace Tests
{
    public class BaseServiceTests
    {
        protected APIClient CheckoutClient;

        [SetUp]
        public void Init()
        {
            CheckoutClient = new APIClient(); 
        }
    }
}
