using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TriangleStuff;

namespace TriangleStuffUnitTests
{
    [TestClass]
    public class TriangleStuffTests
    {
        [TestMethod]
        public void Test_ValidateAngle_GivenExcessivelyLargeAngle_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being over the max valid angle.
            double BadAngle = 200;

            bool Result = TriangleStuffClass.ValidateAngle(BadAngle);

            Assert.IsFalse(Result);
        }
        [TestMethod]
        public void Test_IsRightTriangle_ReturnsFalse()
        {

            // Arrange.
            TriangleStuffClass myTriangle = new TriangleStuffClass();
            bool result = false;


            // Act.
            // A parameterless constructor was used so default values are assigned. At this point it should return false on IsRightTriangle().
            result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_IsRightTriangle_ReturnsTrue()
        {
            // Arrange.
            double AngleA = 90.0;
            double AngleB = 45.0;
            double AngleC = 45.0;
            bool Result = false;

            // Act.
            // To test if the triangle is a right angled triangle it must be constructor with specific values, one of which must be 90.0.
            TriangleStuffClass myTriangle = new TriangleStuffClass(AngleA, AngleB, AngleC);
            Result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsTrue(Result);
        }

        [TestMethod]
        public void Test_ValidateAngle_ReturnsTrue()
        {
            // Arrange.
            double AngleA = 90.0;
            double AngleB = 45.0;
            double AngleC = 45.0;
            bool Result = false;

            // Act.
            // To test if the triangle is a right angled triangle it must be constructor with specific values, one of which must be 90.0.
            TriangleStuffClass myTriangle = new TriangleStuffClass(AngleA, AngleB, AngleC);
            Result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsTrue(Result);
        }

    }
}
