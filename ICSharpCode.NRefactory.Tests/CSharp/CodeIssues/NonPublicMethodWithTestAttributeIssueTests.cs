//
// NonPublicMethodWithTestAttributeIssueTests.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2013 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using NUnit.Framework;
using ICSharpCode.NRefactory6.CSharp.CodeActions;

namespace ICSharpCode.NRefactory6.CSharp.CodeIssues
{
	[TestFixture]
	public class NonPublicMethodWithTestAttributeIssueTests : InspectionActionTestBase
	{
		const string NUnitClasses = @"using System;
using NUnit.Framework;

namespace NUnit.Framework {
	public class TestFixtureAttribute : System.Attribute {}
	public class TestAttribute : System.Attribute {}
}";

		[Test]
		public void TestImplicitPrivate()
		{
			Test<NonPublicMethodWithTestAttributeIssue>(NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	void NonPublicMethod ()
	{
	}
}", NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	public void NonPublicMethod ()
	{
	}
}");
		}

		[Test]
		public void TestExplictPrivate()
		{
			Test<NonPublicMethodWithTestAttributeIssue>(NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	private void NonPublicMethod ()
	{
	}
}", NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	public void NonPublicMethod ()
	{
	}
}");
		}

		[Test]
		public void TestExplictProtected()
		{
			Test<NonPublicMethodWithTestAttributeIssue>(NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	protected void NonPublicMethod ()
	{
	}
}", NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	[Test]
	public void NonPublicMethod ()
	{
	}
}");
		}

		
		[Test]
		public void TestDisable()
		{
			var input = NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	// ReSharper disable once NUnit.NonPublicMethodWithTestAttribute
	[Test]
	void NonPublicMethod ()
	{
	}
}
";
			Analyze<NonPublicMethodWithTestAttributeIssue>(input);
		}


		[Test]
		public void TestDisableAll()
		{
			var input = NUnitClasses + 
				@"
[TextFixture]
class Tests 
{
	// ReSharper disable All
	[Test]
	void NonPublicMethod ()
	{
	}
	// ReSharper restore All
}
";
			Analyze<NonPublicMethodWithTestAttributeIssue>(input);
		}
	}
}

