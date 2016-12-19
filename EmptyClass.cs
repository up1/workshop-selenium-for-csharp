using System;
using NUnit.Framework;

namespace demo_ui_test
{
	[TestFixture]
	public class LifeCycle
	{
		int counter = 0;

		[OneTimeSetUp]
		public void init() { counter = 2; }

		[OneTimeTearDown]
		public void cleanAll() { Console.WriteLine("cleanAll"); }

		[SetUp]
		public void setup() { Console.WriteLine("setup"); }

		[TearDown]
		public void teardown() { Console.WriteLine("teardown"); }

		[Test]
		public void testcase01() { Console.WriteLine("testcase01" + counter);}

		[Test]
		public void testcase02() { Console.WriteLine("testcase02" + counter); }
		
	}
}
