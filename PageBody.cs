using System;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class PageBody
	{
		private IWebDriver webdriver;
		public PageBody(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
		}
	}

}