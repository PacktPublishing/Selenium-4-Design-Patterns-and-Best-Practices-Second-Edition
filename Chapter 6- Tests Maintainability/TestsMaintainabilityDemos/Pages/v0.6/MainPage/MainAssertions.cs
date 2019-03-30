using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsReadabilityDemos.Sixth
{
    public class MainAssertions
    {
        private readonly MainElements _elements;

        public MainAssertions(MainElements elements) => _elements = elements;

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _elements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
