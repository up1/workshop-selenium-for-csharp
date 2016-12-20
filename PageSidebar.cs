using System;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class PageSidebar
	{
		private IWebDriver webdriver;
		public PageSidebar(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
		}

		public SidebarCart getSidebarCart()
		{
			return new SidebarCart(this.webdriver);
		}
	}

	public class SidebarCart
	{
		IWebDriver webdriver;

		public SidebarCart(IWebDriver webdriver)
		{
			this.webdriver = webdriver;
		}

		public string getSummary()
		{
			return webdriver.FindElement(By.Id("Cart66WidgetCartEmptyAdvanced")).Text;
		}

		public string getSummaryOfEmptyCart()
		{
			return webdriver
				.FindElement(
					By.ClassName("Cart66WidgetCartEmpty")).Text;
			
		}

		public string getSubTotal()
		{
			return webdriver.FindElement(By.ClassName("Cart66Subtotal")).Text;
		}
	}

}