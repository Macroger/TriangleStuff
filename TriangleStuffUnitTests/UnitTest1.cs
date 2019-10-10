using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleStuffUnitTests;

namespace TriangleStuffUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_IsRightTriangle_false()
        {
            // Arrange.
            TriangleStuffClass myTriangle = new TriangleStuffClass();
            bool result = false;

            // Act.
            // A parameterless constructor was used so default values are used. At this point it should return false on IsRightTriangle().
            result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsFalse(result);
        }
    }
}
