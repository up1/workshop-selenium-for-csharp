using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_ui_test
{

	public class Base
	{
		public IWebDriver webdriver;

		[SetUp]
		public void xx()
		{
			webdriver = new ChromeDriver(@"/Users/somkiat/Projects/demo_ui_test/demo_ui_test");
			webdriver.Manage()
					 .Timeouts()
					 .ImplicitlyWait(
						 TimeSpan.FromSeconds(30));
		}

		[TearDown]
		public void yyy()
		{
			webdriver.Dispose();
		}
	}
}
