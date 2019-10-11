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
        public void Test_ValidateAngle_GivenTooSmallAngle_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being under the min valid angle.
            double BadAngle = 0.0000001;

            bool Result = TriangleStuffClass.ValidateAngle(BadAngle);

            Assert.IsFalse(Result);
        }



        [TestMethod]
        public void Test_ValidateTriangle_GivenTooSmallTotalAngles_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being under the min valid degrees for a triangle.
            // This set shoud equal 80 + 70 + 5 = 175 degrees, which is invalid for a triangle.
            double BadAngleA = 80;
            double BadAngleB = 70;
            double BadAngleC = 5;

            bool Result = TriangleStuffClass.ValidateTriangle(BadAngleA, BadAngleB, BadAngleC);

            Assert.IsFalse(Result);
        }

        [TestMethod]
        public void Test_DetermineAreaOfRightTriangle_GivenValidValues_ReturnsCorrectCalculation()
        {
            // Arrange
            double SideA = 55;
            double SideB = 92.6;
            double AreaOfTriangle = 5093;
            double Result = 0;
            TriangleStuffClass myTriangle = new TriangleStuffClass();


            // Act
            Result = myTriangle.DetermineAreaOfRightTriangle(SideA, SideB);


            // Assert
            Assert.AreEqual(AreaOfTriangle, Result);
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

    }
}
