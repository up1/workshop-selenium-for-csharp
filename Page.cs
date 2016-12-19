using System;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class Page
	{
		protected IWebDriver webdriver;
		public Page(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
			verify();
		}

		virtual public PageSidebar getPageSidebar()
		{
			return new PageSidebar(webdriver);
		}

		virtual public string getPagePath()
		{
			throw new NotImplementedException();
		}

		private void verify()
		{
			if (!currentPath().Equals(getPagePath()))
			{
				throw new NotImplementedException();
			}
		}

		private string currentPath()
		{
			Uri currentUri = new Uri(this.webdriver.Url);
			return currentUri.PathAndQuery;
		}
	}
}