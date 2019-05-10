using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class CartPageElements
    {
        private readonly Driver _driver;

        public CartPageElements(Driver driver) => _driver = driver;

        ////public Element CouponCodeTextField => _driver.FindElement(By.Id("coupon_code"));
        ////public Element ApplyCouponButton => _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        ////public Element QuantityBox => _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        ////public Element UpdateCart => _driver.FindElement(By.CssSelector("[value*='Update cart']"));
        ////public Element MessageAlert => _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        ////public Element TotalSpan => _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        ////public Element ProceedToCheckout => _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public Element CouponCodeTextField => _driver.FindById("coupon_code");
        public Element ApplyCouponButton => _driver.FindByCss("[value*='Apply coupon']");
        public Element QuantityBox => _driver.FindByCss("[class*='input-text qty text']");
        public Element UpdateCart => _driver.FindByCss("[value*='Update cart']");
        public Element MessageAlert => _driver.FindByCss("[class*='woocommerce-message']");
        public Element TotalSpan => _driver.FindByXPath("//*[@class='order-total']//span");
        public Element ProceedToCheckout => _driver.FindByCss("[class*='checkout-button button alt wc-forward']");
    }
}
