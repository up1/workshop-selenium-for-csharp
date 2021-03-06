﻿using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace demo_ui_test
{
	

	[TestFixture]
	public class Bookatable01
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
		public void search_restaurant()
		{
			webdriver.Url = "http://www.bookatable.com/";

			//Action
			IWebElement searchLink = webdriver.FindElement(By.ClassName("global-navigation__link-search"));
			searchLink.Click();
			IWebElement searchBox = webdriver.FindElement(By.Id("global-navigation__search-input"));
			searchBox.SendKeys("All");

			//Assert
			IWebElement searchResult = webdriver.FindElement(By.XPath("/html/body/div[1]/div/nav/div/div/div/ul/li[1]/a/span[2]/span[1]"));
			Assert.AreEqual("", searchResult.Text);
		}

		[Test]
		public void search_restaurant_with_thread_sleep()
		{
			webdriver.Url = "http://www.bookatable.com/";

			//Action
			IWebElement searchLink = webdriver.FindElement(By.ClassName("global-navigation__link-search"));
			searchLink.Click();
			IWebElement searchBox = webdriver.FindElement(By.Id("global-navigation__search-input"));
			searchBox.SendKeys("All");

			Thread.Sleep(5000);

			//Assert
			IWebElement searchResult = webdriver.FindElement(By.XPath("/html/body/div[1]/div/nav/div/div/div/ul/li[1]/a/span[2]/span[1]"));
			Assert.AreEqual("", searchResult.Text);
		}

		[Test]
		public void search_restaurant_with_implicit_wait()
		{
			webdriver.Url = "http://www.bookatable.com/";
			webdriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

			//Action
			IWebElement searchLink = webdriver.FindElement(By.ClassName("global-navigation__link-search"));
			searchLink.Click();
			IWebElement searchBox = webdriver.FindElement(By.Id("global-navigation__search-input"));
			searchBox.SendKeys("All");

			//Assert
			IWebElement searchResult = webdriver.FindElement(By.XPath("/html/body/div[1]/div/nav/div/div/div/ul/li[1]/a/span[2]/span[1]"));
			Assert.AreEqual("", searchResult.Text);
		}

		[Test]
		public void search_restaurant_with_explicit_wait()
		{
			webdriver.Url = "http://www.bookatable.com/";

			//Action
			IWebElement searchLink = webdriver.FindElement(By.ClassName("global-navigation__link-search"));
			searchLink.Click();
			IWebElement searchBox = webdriver.FindElement(By.Id("global-navigation__search-input"));
			searchBox.SendKeys("All");

			Common.waitFor();

			//Assert
			WebDriverWait webdriverWait = 
				new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
			IWebElement searchResult = 
				webdriverWait.Until(x=>x.FindElement(By.XPath("/html/body/div[1]/div/nav/div/div/div/ul/li[1]/a/span[2]/span[1]")));

			Assert.AreEqual("", searchResult.Text);
		}

		[Test]
		public void search_restaurant_with_fluent_wait()
		{
			webdriver.Url = "http://www.bookatable.com/";

			//Action
			IWebElement searchLink = webdriver.FindElement(By.ClassName("global-navigation__link-search"));
			searchLink.Click();
			IWebElement searchBox = webdriver.FindElement(By.Id("global-navigation__search-input"));
			searchBox.SendKeys("All");

			Common.waitFor();

			//Assert
			DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webdriver);
			fluentWait.Timeout = TimeSpan.FromSeconds(5);
			fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
			fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			IWebElement searchResult =
				fluentWait.Until(x => x.FindElement(By.XPath("/html/body/div[1]/div/nav/div/div/div/ul/li[1]/a/span[2]/span[1]")));

			Assert.AreEqual("", searchResult.Text);
		}

		[Test]
		public void withPageLoadAndScriptTimeout()
		{
			webdriver.Manage().Timeouts()
			         .SetPageLoadTimeout(TimeSpan.FromSeconds(5));
			
			webdriver.Manage().Timeouts()
			         .SetScriptTimeout(TimeSpan.FromSeconds(5));
		}
			

	}
}
