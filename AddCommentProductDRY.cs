using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace demo_ui_test
{
	[TestFixture]
	public class AddCommentProductDRY
	{
		IWebDriver webdriver;

		[SetUp]
		public void setup()
		{
			webdriver = new ChromeDriver();
		}

		[TearDown]
		public void teardown()
		{
			webdriver.Close();
		}

		private void chooseProduct()
		{
			webdriver.FindElement(By.XPath("//*[@id=\"special-items\"]/div[4]/div[1]/a[2]")).Click();
		}

		private void fillInCommentForm()
		{
			webdriver.FindElement(By.Id("author")).SendKeys("Somkiat");
			webdriver.FindElement(By.Id("email")).SendKeys("Somkiat@gmail.com");
			webdriver.FindElement(By.Id("url")).SendKeys("http://www.somkiat.cc");
			webdriver.FindElement(By.XPath("//*[@id=\"et-rating\"]/div/span/div[8]/a")).Click();
			webdriver.FindElement(By.Id("comment")).Clear();
			webdriver.FindElement(By.Id("comment")).SendKeys("My comment naja 3");
			webdriver.FindElement(By.Id("submit")).Click();

		}

		[Test()]
		public void add_review_to_product()
		{
			webdriver.Url = "http://awful-valentine.com/";
			chooseProduct();
			fillInCommentForm();

			if (webdriver.Url.Contains("#"))
			{
				string[] paths = webdriver.Url.Split('#');
				string commentId = paths[1];
				IWebElement commentElement = webdriver.FindElement(By.Id(commentId));
				IWebElement infoElement = commentElement.FindElement(By.ClassName("comment-author-metainfo"));
				string name = infoElement.FindElement(By.ClassName("url")).Text;
				string commentContent = commentElement.FindElement(By.ClassName("comment-content")).Text;

				Assert.AreEqual("Somkiat", name);
				Assert.AreEqual("My comment naja 3", commentContent);
			}
			else
			{
				Assert.Fail("URL invalid !!");
			}
		}
	}
}
