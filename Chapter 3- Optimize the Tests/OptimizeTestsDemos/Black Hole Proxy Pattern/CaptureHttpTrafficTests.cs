using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;
using Proxy = Titanium.Web.Proxy.Http;

namespace OptimizeTestsDemos.Black_Hole_Proxy_Pattern
{
    [TestClass]
    public class CaptureHttpTrafficTests
    {
        private IWebDriver _driver;
        private ProxyServer _proxyServer;
        private IDictionary<int, Proxy.Request> _requestsHistory;
        private IDictionary<int, Proxy.Response> _responsesHistory;
        private ConcurrentBag<string> _blockUrls;

        [ClassInitialize]
        public void ClassInit()
        {
            _proxyServer = new ProxyServer();
            _blockUrls = new ConcurrentBag<string>();
            _responsesHistory = new ConcurrentDictionary<int, Proxy.Response>();
            _requestsHistory = new ConcurrentDictionary<int, Proxy.Request>();
            var explicitEndPoint = new ExplicitProxyEndPoint(System.Net.IPAddress.Any, 18882, true);
            _proxyServer.AddEndPoint(explicitEndPoint);
            _proxyServer.Start();
            _proxyServer.SetAsSystemHttpProxy(explicitEndPoint);
            _proxyServer.SetAsSystemHttpsProxy(explicitEndPoint);
            _proxyServer.BeforeRequest += OnRequestCaptureTrafficEventHandler;
            _proxyServer.BeforeRequest += OnRequestBlockResourceEventHandler;
            _proxyServer.BeforeResponse += OnResponseCaptureTrafficEventHandler;
        }

        [ClassCleanup]
        public void ClassCleanup()
        {
            _proxyServer.Stop();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var proxy = new OpenQA.Selenium.Proxy
            {
                HttpProxy = "http://localhost:18882",
                SslProxy = "http://localhost:18882",
                FtpProxy = "http://localhost:18882"
            };
            var options = new ChromeOptions
            {
                Proxy = proxy
            };
            _driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Dispose();
            _requestsHistory.Clear();
            _responsesHistory.Clear();
        }

        [TestMethod]
        public void AnalyticsRequestsNotMade_When_AnalyticsRequestsSetToBeBlocked()
        {
            _blockUrls.Add("analytics");

            _driver.Navigate().GoToUrl("https://automatetheplanet.com/");

            AssertRequestNotMade("analytics");
        }

        [TestMethod]
        public void FontRequestsNotMade_When_FontRequestSetToBeBlocked()
        {
            _blockUrls.Add("fontawesome-webfont.woff2?v=4.7.0");

            _driver.Navigate().GoToUrl("https://automatetheplanet.com/");


            AssertRequestNotMade("fontawesome-webfont.woff2?v=4.7.0");
        }

        private void AssertRequestNotMade(string url)
        {
            bool areRequestsMade = _requestsHistory.Values.Any(r => r.RequestUri.ToString().Contains(url));
            Assert.IsFalse(areRequestsMade);
        }

        private async Task OnRequestBlockResourceEventHandler(object sender, SessionEventArgs e) => await Task.Run(
            () =>
            {
                if (_blockUrls.Count > 0)
                {
                    foreach (var urlToBeBlocked in _blockUrls)
                    {
                        if (e.HttpClient.Request.RequestUri.ToString().Contains(urlToBeBlocked))
                        {
                            string customBody = string.Empty;
                            e.Ok(Encoding.UTF8.GetBytes(customBody));
                        }
                    }
                }
            });

        private async Task OnRequestCaptureTrafficEventHandler(object sender, SessionEventArgs e) => await Task.Run(
            () =>
            {
                if (!_requestsHistory.ContainsKey(e.HttpClient.Request.GetHashCode()) && e.HttpClient.Request != null)
                {
                    _requestsHistory.Add(e.HttpClient.Request.GetHashCode(), e.HttpClient.Request);
                }
            });

        private async Task OnResponseCaptureTrafficEventHandler(object sender, SessionEventArgs e) => await Task.Run(
            () =>
            {
                if (!_responsesHistory.ContainsKey(e.HttpClient.Response.GetHashCode()) && e.HttpClient.Response != null)
                {
                    _responsesHistory.Add(e.HttpClient.Response.GetHashCode(), e.HttpClient.Response);
                }
            });
    }
}
