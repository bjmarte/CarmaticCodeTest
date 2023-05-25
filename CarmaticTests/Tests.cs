using CarmaticCode;

namespace CarmaticTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Works()
        {
            var message = new CarmaticLogic().GetMessage();

            Assert.That(message, Is.EqualTo("Hello Carmatic"));
        }

        [Test]
        public void DoesNotWork()
        {
            var message = new CarmaticLogic().GetMessage();
            Assert.That(message, Is.EqualTo("This is broken"));
        }
    }
}