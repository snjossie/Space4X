using Assets.Scripts;
using NUnit.Framework;

namespace Tests.Editor
{
    public class NumberExtensionsTests
    {
        [TestCase(0f, 0f, 1f, true)]
        [TestCase(0.15f, 0f, 1f, true)]
        [TestCase(0.25f, 0f, 1f, true)]
        [TestCase(0.5f, 0f, 1f, true)]
        [TestCase(0.75f, 0f, 1f, true)]
        [TestCase(0.95f, 0f, 1f, true)]
        [TestCase(1f, 0f, 1f, true)]
        [TestCase(-0.15f, 0f, 1f, false)]
        [TestCase(-0.25f, 0f, 1f, false)]
        [TestCase(-0.5f, 0f, 1f, false)]
        [TestCase(-0.75f, 0f, 1f, false)]
        [TestCase(-0.95f, 0f, 1f, false)]
        [TestCase(1.15f, 0f, 1f, false)]
        [TestCase(1.5f, 0f, 1f, false)]
        [TestCase(2f, 0f, 1f, false)]
        [TestCase(10f, 0f, 1f, false)]
        public void IsBetweenIncludeLimit(float value, float min, float max, bool expected)
        {
            var actual = value.IsBetweenIncludeLimits(min, max);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
