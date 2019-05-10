using System.Collections.Generic;
using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class NativeElementFinderService
    {
        private readonly ISearchContext _searchContext;

        public NativeElementFinderService(ISearchContext searchContext) => _searchContext = searchContext;

        public IWebElement Find<TByStrategy>(TByStrategy by)
            where TByStrategy : ByStrategy
        {
            var element = _searchContext.FindElement(by.Convert());

            return element;
        }

        public IEnumerable<IWebElement> FindAll<TByStrategy>(TByStrategy by)
            where TByStrategy : ByStrategy
        {
            IEnumerable<IWebElement> result = _searchContext.FindElements(@by.Convert());

            return result;
        }
    }
}
