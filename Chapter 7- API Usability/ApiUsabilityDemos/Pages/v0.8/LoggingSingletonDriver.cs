﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ApiUsabilityDemos
{
    public class LoggingSingletonDriver : DriverDecorator
    {
        private static LoggingSingletonDriver instance;

        public static LoggingSingletonDriver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggingSingletonDriver(new WebDriver());
                }

                return instance;
            }
        }

        private LoggingSingletonDriver(Driver driver)
        : base(driver)
        {
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            driver?.Start(browser);
        }

        public override void Quit()
        {
            Console.WriteLine("Close browser");
            driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine("Find element");
            return driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine("Find elements");
            return driver?.FindElements(locator);
        }
    }
}
