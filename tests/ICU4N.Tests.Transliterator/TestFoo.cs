using NUnit.Framework;
using System;

namespace ICU4N.Tests.Transliterator
{
    public class TestFoo
    {
        [Test]
        public void TestGetMessage()
        {
            var target = new Foo();

            Assert.AreEqual("Hello", target.GetMessage());
        }
    }
}
