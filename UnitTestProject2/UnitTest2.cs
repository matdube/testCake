using NUnit.Framework;

namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void Test2()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
        }
    }
}
