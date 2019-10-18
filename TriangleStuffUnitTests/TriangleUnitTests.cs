/*
**  File Name:      TriangleUnitTests.cs
**	Project Name:	TriangleStuff
**	Author:         Matthew G. Schatz
**  Date:           October 18, 2019
**	Description:	This file holds the source code for the TriangleUnitTests class. This class performs unit tests on the Triangle class. 
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleStuff;

namespace TriangleStuffUnitTests
{
    /*
     **  Class Name: TriangleStuffUnitTests
     **  Description: This class is designed to provide unit tests to verify the correct operation of the Triangle class.
     */

    [TestClass]
    public class TriangleStuffTests
    {
        /*
        **	Method Name:	Test_ValidateAngle_GivenExcessivelyLargeAngle_ReturnsFalse()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This is a test method. It is designed to test that the ValidateAngle method produces a boolean false when provided an angle that is too large.
        */
        [TestMethod]
        public void Test_ValidateAngle_GivenExcessivelyLargeAngle_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being over the max valid angle.
            double BadAngle = 200;

            bool Result = Triangle.ValidateAngle(BadAngle);

            Assert.IsFalse(Result);
        }

        /*
        **	Method Name:	Test_ValidateAngle_GivenTooSmallAngle_ReturnsFalse()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method. This test is designed to verify that ValidateAngle produces a boolean false when given a angle that is too small.
        */
        [TestMethod]
        public void Test_ValidateAngle_GivenTooSmallAngle_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being under the min valid angle.
            double BadAngle = 0.0000001;

            bool Result = Triangle.ValidateAngle(BadAngle);

            Assert.IsFalse(Result);
        }


        /*
        **	Method Name:	Test_ValidateTriangle_GivenTooSmallTotalAngles_ReturnsFalse()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method; This test is designed to verify that ValidateTriangle produces a boolean false when provided angles that are individually valid, but together fail to combine to 180 degrees.
        */
        [TestMethod]
        public void Test_ValidateTriangle_GivenTooSmallTotalAngles_ReturnsFalse()
        {
            // This Angle is designed to be invalid by being under the min valid degrees for a triangle.
            // This set shoud equal 80 + 70 + 5 = 175 degrees, which is invalid for a triangle.
            double BadAngleA = 80;
            double BadAngleB = 70;
            double BadAngleC = 5;

            bool Result = Triangle.ValidateTriangle(BadAngleA, BadAngleB, BadAngleC);

            Assert.IsFalse(Result);
        }

        /*
        **	Method Name:	Test_DetermineAreaOfRightTriangle_GivenValidValues_ReturnsCorrectCalculation()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method; This test is designed to verify the method DetermineAreaOfRightTriangle produces the correct result when fed valid numbers.
        */
        [TestMethod]
        public void Test_DetermineAreaOfRightTriangle_GivenValidValues_ReturnsCorrectCalculation()
        {
            // Arrange 
            double SideA = 55;
            double SideB = 92.6;
            double AreaOfTriangle = 2546.5;
            double Result = 0;
            Triangle myTriangle = new Triangle();


            // Act
            Result = myTriangle.DetermineAreaOfRightTriangle(SideA, SideB);


            // Assert
            Assert.AreEqual(AreaOfTriangle, Result);
        }

        /*
        **	Method Name:	Test_DetermineAreaOfRightTriangle_GivenInvalidValues_ReturnsZero()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method; This test is designed to verify DetermineAreaOfRightTriangle returns 0 when given an invalid sideA.
        */
        [TestMethod]
        public void Test_DetermineAreaOfRightTriangle_GivenInvalidValues_ReturnsZero()
        {
            // Arrange 
            // Feeding the method under test a very small value that should be rejected.
            double SideA = 0.0000000001;
            double SideB = 5;
            double AreaOfTriangle = 0;
            double Result = 0;
            Triangle myTriangle = new Triangle();
            
            // Act
            Result = myTriangle.DetermineAreaOfRightTriangle(SideA, SideB);


            // Assert
            Assert.AreEqual(AreaOfTriangle, Result);
        }

        /*
        **	Method Name:	Test_IsRightTriangle_ReturnsFalse()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method; This test is designed to verify that IsRightTriangle returns false when the triangle created is NOT a right triangle.
        */
        [TestMethod]
        public void Test_IsRightTriangle_ReturnsFalse()
        {

            // Arrange.
            Triangle myTriangle = new Triangle();
            bool result = false;


            // Act.
            // A parameterless constructor was used so default values are assigned. At this point it should return false on IsRightTriangle().
            result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsFalse(result);
        }

        /*
        **	Method Name:	Test_IsRightTriangle_ReturnsTrue()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	Test Method; This test is designed to verify that IsRightTriangle returns true when the triangle is indeed a right triangle.
        */
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
            Triangle myTriangle = new Triangle(AngleA, AngleB, AngleC);
            Result = myTriangle.IsRightTriangle();


            // Assert.
            Assert.IsTrue(Result);
        }

    }
}
