using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;

namespace demo_ui_test
{

	public class HomePage: Page
	{

		public HomePage(IWebDriver webdriver): base(webdriver)
		{
		}

		public override string getPagePath()
		{
			return "/";
		}

		public SpecialItems getItems()
		{
			return new SpecialItems(webdriver);
		}
			
	}

	public class SpecialItems
	{
		private IWebDriver webdriver;
		private List<SpecialItem> items = new List<SpecialItem>();

		public SpecialItems(IWebDriver webdriver)
		{
			this.webdriver = webdriver;

			foreach (IWebElement element in 
			         webdriver.FindElements(By.ClassName("special-item")))
			{
				this.items.Add(new SpecialItem(webdriver, element));
			}

		}

		public SpecialItem get(int index)
		{
			return this.items[index];
		}

	}

	public class SpecialItem
	{
		private IWebDriver webdriver;
		private IWebElement element;

		public SpecialItem(IWebDriver webdriver, IWebElement element)
		{
			this.webdriver = webdriver;
			this.element = element;
		}

		public void addToCart()
		{
			this.element.FindElement(By.ClassName("add-to-cart")).Click();
			Thread.Sleep(3000);
			this.webdriver.FindElement(By.Id("fancybox-content"))
			    .FindElement(By.ClassName("Cart66ButtonPrimary"))
			    .Click();
		}
	}

}