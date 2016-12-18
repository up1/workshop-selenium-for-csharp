using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_ui_test
{
	[TestFixture]
	public class AddProductToCart
	{
		IWebDriver webdriver;

		[SetUp]
		public void setup()
		{
			webdriver = new ChromeDriver("/Users/somkiat/Projects/demo_ui_test/demo_ui_test/");
		}

		[TearDown]
		public void teardown()
		{
			//webdriver.Close();
		}

		[Test]
		public void addProductToCart()
		{
			webdriver.Url = "http://awful-valentine.com/";

			HomePage homepage = new HomePage(webdriver);
			homepage.getItems().get(0).addToCart();

			webdriver.Url = "http://awful-valentine.com/contact-us/";
			ContactUsPage contactUsPage = new ContactUsPage(webdriver);
			Assert.AreEqual("You have 1 item ($5.77) in your shopping cart.", 
			                contactUsPage.getPageSidebar().getSidebarCart().getSummary());
		}
	}
}
