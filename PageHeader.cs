using System;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class PageHeader
	{
		private IWebDriver webdriver;
		public PageHeader(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
		}
	}

}