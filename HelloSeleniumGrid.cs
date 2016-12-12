using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace demo_ui_test
{
	[TestFixture]
	public class HelloSeleniumGrid
	{
		IWebDriver webdriver;

		[SetUp]
		public void setup()
		{
			DesiredCapabilities capabilities = new DesiredCapabilities();
			capabilities = DesiredCapabilities.Chrome();
			capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
			capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Mac));

			webdriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities);
			webdriver.Manage().Window.Maximize();
		}

		[TearDown]
		public void teardown()
		{
			webdriver.Quit();
		}

		[Test]
		public void hello()
		{
			webdriver.Navigate().GoToUrl("http://www.google.com");
		}
			
	}
}
