using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace StabilizeTestsDemos
{
    [TestClass]
    public class ProductPurchaseTests
    {
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void CompletePurchase()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var sortDropDown = new SelectElement(_driver.FindElement(By.CssSelector("[name$='orderby']")));
            // order matters.
            ////var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

            sortDropDown.SelectByText("Sort by price: low to high");

            var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(500);
            var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();

            // should wait somehow- directly fails.
            var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");

            var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();

            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);

            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            ////quantityBox.SendKeys("0");
            quantityBox.SendKeys("2");

            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(2000);

            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var billingFirstName = _driver.FindElement(By.Id("billing_first_name"));
            ////billingFirstName.Clear();
            billingFirstName.SendKeys("Anton");
            var billingLastName = _driver.FindElement(By.Id("billing_last_name"));
            ////billingLastName.Clear();
            billingLastName.SendKeys("Angelov");
            var billingCompany = _driver.FindElement(By.Id("billing_company"));
            billingCompany.Clear();
            billingCompany.SendKeys("Space Flowers");
            var billingCountryWrapper = _driver.FindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = _driver.FindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.SendKeys("Germany");

            var germanyOption = _driver.FindElement(By.XPath("//*[contains(text(),'Germany')]"));

            ////var executor = (IJavaScriptExecutor)_driver;
            ////executor.ExecuteScript("arguments[0].click();", germanyOption);
            germanyOption.Click();
            // click wrapper
            // type filter
            // implement JS Click? adapter?

            var billingAddress1 = _driver.FindElement(By.Id("billing_address_1"));
            billingAddress1.Clear();
            billingAddress1.SendKeys("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = _driver.FindElement(By.Id("billing_address_2"));
            billingAddress2.Clear();
            billingAddress2.SendKeys("Lützowplatz 17");
            var billingCity = _driver.FindElement(By.Id("billing_city"));
            billingCity.Clear();
            billingCity.SendKeys("Berlin");
            var billingState = _driver.FindElement(By.Id("billing_state"));
            billingState.Clear();
            billingState.SendKeys("Berlin");
            var billingZip = _driver.FindElement(By.Id("billing_postcode"));
            billingZip.Clear();
            billingZip.SendKeys("10115");
            var billingPhone = _driver.FindElement(By.Id("billing_phone"));
            billingPhone.Clear();
            billingPhone.SendKeys("+00498888999281");
            var billingEmail = _driver.FindElement(By.Id("billing_email"));
            billingEmail.Clear();
            billingEmail.SendKeys("info@berlinspaceflowers.com");
            var createAccountCheckBox = _driver.FindElement(By.Id("createaccount"));
            createAccountCheckBox.Click();
            var checkPaymentsRadioButton = _driver.FindElement(By.CssSelector("[for*='payment_method_cheque']"));
            checkPaymentsRadioButton.Click();
            var placeOrderButton = _driver.FindElement(By.Id("place_order"));
            placeOrderButton.Click();
        }
    }
}