using System;
using OpenQA.Selenium;

namespace demo_ui_test
{
	public class ContactUsPage: Page
	{
		public ContactUsPage(IWebDriver webdriver) : base(webdriver)
		{
		}

		public override string getPagePath()
		{
			return "/contact-us/";
		}
	}
}