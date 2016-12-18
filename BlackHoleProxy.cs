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
			proxy.HttpProxy = "localhost:8888";
			proxy.NoProxy = "localhost,127.0.0.1,*tarad.com";

			chromeOptions.Proxy = proxy;
			chromeOptions.AddArgument("ignore-certificate-errors");
			webdriver =
				new ChromeDriver("/Users/somkiat/Projects/demo_ui_test/demo_ui_test/", chromeOptions);
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
