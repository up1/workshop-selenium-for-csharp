using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_ui_test
{
	[TestFixture]
	public class BlackHoleProxy
	{
		IWebDriver webdriver;

		[SetUp]
		public void setup()
		{
			var chromeOptions = new ChromeOptions();
			var proxy = new Proxy();
			proxy.Kind = ProxyKind.Manual;
			proxy.IsAutoDetect = false;
			proxy.HttpProxy = "http://login:pass@proxyserver:port";
			proxy.NoProxy = "localhost,127.0.0.1";

			chromeOptions.Proxy = proxy;
			//chromeOptions.AddArgument("ignore-certificate-errors");
//			chromeOptions.AddArguments(
//"--proxy-server=http://user:password@yourProxyServer.com:8080");
			webdriver =
				new ChromeDriver("/Users/somkiat/Projects/demo_ui_test/demo_ui_test/"
				                 , chromeOptions);
		}

		[TearDown]
		public void teardown()
		{
			//webdriver.Close();
		}

		[Test]
		public void loadFirstPage()
		{
			webdriver.Navigate().GoToUrl("http://www.tarad.com/product/6903113");
		}

	}
}
