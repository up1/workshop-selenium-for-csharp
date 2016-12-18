using System;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class PageFooter
	{
		private IWebDriver webdriver;
		public PageFooter(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
		}
	}

}