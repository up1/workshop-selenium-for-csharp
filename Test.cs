using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_ui_test
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void hello_google()
		{
			IWebDriver webdriver = new ChromeDriver(@"/Users/somkiat/Projects/demo_ui_test/demo_ui_test/");
			webdriver.Url = "http://www.google.com";
			webdriver.Close();
		}
	}
}
