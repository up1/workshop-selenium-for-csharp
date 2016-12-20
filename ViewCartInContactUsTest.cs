using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace demo_ui_test
{
	[TestFixture]
	public class ViewCartInContactUsTest
	{
		IWebDriver webdriver;

		[SetUp]
		public void setup()
		{
			webdriver = new ChromeDriver("/Users/somkiat/Projects/demo_ui_test/demo_ui_test/");
		}

		[Test]
		public void addOneProductToCartFromFirstPage()
		{
			webdriver.Url = "http://awful-valentine.com/";
			HomePage homepage = new HomePage(webdriver);
			homepage.getItems().get(0).addToCart();

			webdriver.Url = "http://awful-valentine.com/contact-us/";
			ContactUsPage page = new ContactUsPage(webdriver);
			SidebarCart cart = page.getPageSidebar().getSidebarCart();

			Assert.AreEqual("You have 1 item ($5.77) in your shopping cart."
			                , cart.getSummary());
			Assert.AreEqual("$5.77", cart.getSubTotal());
		}

		[Test]
		public void emptyCartInContactUsPage()
		{
			webdriver.Url = "http://awful-valentine.com/contact-us/";
			ContactUsPage page = new ContactUsPage(webdriver);
			string message = page.getPageSidebar()
			                     .getSidebarCart()
			                     .getSummaryOfEmptyCart();

			Assert.AreEqual("", message);
		}
	}
}
