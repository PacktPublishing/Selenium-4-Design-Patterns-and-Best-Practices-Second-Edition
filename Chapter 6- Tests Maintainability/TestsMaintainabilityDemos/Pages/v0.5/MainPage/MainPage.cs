﻿using OpenQA.Selenium;

namespace TestsReadabilityDemos.Fifth
{
    public class MainPage : NavigatableEShopPage
    {
        private Element _addToCartFalcon9 => Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element _viewCartButton => Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public MainPage(Driver driver) : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            _addToCartFalcon9.Click();
            _viewCartButton.Click();
        }

        protected override void WaitForElementToDisplay()
        {
            _addToCartFalcon9.WaitToExists();
        }
    }
}