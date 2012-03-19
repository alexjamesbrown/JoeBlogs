using NUnit.Framework;
using System;

namespace JoeBlogs.Tests.Mapping
{
    [TestFixture]
    public class General
    {
        [Test]
        public void trying_to_map_a_string_that_doesnt_correspond_to_enum_val_throws_exception()
        {
            var testItem = new XmlRpcComment();

            Assert.Throws<ArgumentException>(() => Map.To.Comment(testItem));
        }
    }
}