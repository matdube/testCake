using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
        }
    }
}
