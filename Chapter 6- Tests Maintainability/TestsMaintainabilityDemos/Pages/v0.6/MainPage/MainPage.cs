namespace TestsReadabilityDemos.Sixth
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(Driver driver) : base(driver)
        {
            MainElements = new MainElements(driver);
            MainAssertions = new MainAssertions(MainElements);
        }

        public MainElements MainElements { get; set; }
        public MainAssertions MainAssertions { get; set; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            MainElements.AddToCartFalcon9.Click();
            MainElements.ViewCartButton.Click();
        }

        protected override void WaitForElementToDisplay()
        {
            MainElements.AddToCartFalcon9.WaitToExists();
        }
    }
}