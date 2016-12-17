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
			webdriver = new ChromeDriver("/Users/somkiat/Projects/demo_ui_test/demo_ui_test/");
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

		private void fillInCommentForm(Comment comment)
		{
			webdriver.FindElement(By.Id("author")).SendKeys(comment.name);
			webdriver.FindElement(By.Id("email")).SendKeys(comment.email);
			webdriver.FindElement(By.Id("url")).SendKeys(comment.link);
			webdriver.FindElement(By.XPath("//*[@id=\"et-rating\"]/div/span/div[8]/a")).Click();
			webdriver.FindElement(By.Id("comment")).Clear();
			webdriver.FindElement(By.Id("comment")).SendKeys(comment.content);
			webdriver.FindElement(By.Id("submit")).Click();
		}

		private Comment generateUniqueComment()
		{
			Comment comment = new Comment();
			comment.name = "Somkiat";
			comment.email = "somkiat.p@gmail.com";
			comment.link = "http://www.somkiat.cc";
			comment.content = "My comment " + DateTime.Now.ToString("hh.mm.ss.ffffff");
			return comment;
		}

		private string getNewCommentId()
		{
			if (webdriver.Url.Contains("#"))
			{
				string[] paths = webdriver.Url.Split('#');
				string commentId = paths[1];
				return commentId;
			}
			return "";
		}

		private void gotoHomepage()
		{
			webdriver.Url = "http://awful-valentine.com/";
		}

		private void generateNewComment(Comment comment)
		{
			gotoHomepage();
			chooseProduct();
			fillInCommentForm(comment);
		}

		[Test()]
		public void add_review_to_product()
		{
			Comment comment = generateUniqueComment();
			generateNewComment(comment);
			string newCommentId = getNewCommentId();

			IWebElement commentElement = webdriver.FindElement(By.Id(newCommentId));
			IWebElement infoElement = commentElement.FindElement(By.ClassName("comment-author-metainfo"));
			string name = infoElement.FindElement(By.ClassName("url")).Text;
			string commentContent = commentElement.FindElement(By.ClassName("comment-content")).Text;
			Assert.AreEqual(comment.name, name);
			Assert.AreEqual(comment.content, commentContent);
		}

		[Test()]
		public void duplicate_review_to_product()
		{
			Comment comment = generateUniqueComment();
			generateNewComment(comment);
			generateNewComment(comment);

			IWebElement errorElement = webdriver.FindElement(By.Id("error-page"));
			string error = errorElement.Text;
			Assert.AreEqual("Duplicate comment detected; it looks as though you’ve already said that!", error);

		}
	}

	class Comment
	{
		public string name { set; get; }
		public string email { set; get; }
		public string link { set; get; }
		public string content { set; get; }
	}
}
