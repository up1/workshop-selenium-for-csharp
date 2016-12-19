using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace demo_ui_test
{

	class Comment2
	{
		public string name { set; get; }
		public string url { set; get; }
	}

	[TestFixture]
	public class Workshop01: Base
	{
		private void fillinCommentForm(Comment2 comment)
		{
			webdriver.FindElement(By.Id("author")).SendKeys(comment.name);
		}

		[TestCase("Somkait", "xxx.com")]
		[TestCase("Pui", "yyy.com")]
		public void test01(string name, string url)
		{
			Comment2 comment = new Comment2();
			comment.name = name;
			comment.url = url;
			fillinCommentForm(comment);
		}

		[Test]
		public void test02()
		{
			webdriver.Url = "http://awful-valentine.com/";
		}

	}

	
}
