using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByIdStrategy : ByStrategy
    {
        public ByIdStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.Id(Value);
    }
}
