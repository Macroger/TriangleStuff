/*
**  File Name:      Triangle.cs
**	Project Name:	TriangleStuff
**	Author:         Matthew G. Schatz
**  Date:           October 18, 2019
**	Description:	This file holds the source code for the Triangle class. This class is designed to represent a triangle, and knows about characteristics typical to a triangle such as internal angles and side lengths.
*/

using System;

namespace TriangleStuff
{
     /*
     **  Class Name: Triangle
     **  Description: This class is designed to represent a Triangle. It holds information about a single triangle, including angles and sides. It performs calculations to determine what kind of 
     *   triangle category it is, and what type of angle it has.
     */
    public class Triangle
    {
        // Data Members

        // This enum is used to enumerate the three types of triangles, Equilateral, Isosceles, and Scalene.
        private enum TriangleTypeCategories
        {
            // Equilateral: Three equal sides, three equal angles.
            Equilateral = 1,
            //Isosceles: Two equal sides, Two equal angles.
            Isosceles,
            //Scalene: No equal sides, no equal angles.
            Scalene,

        }

        // This enum is used to enumerate the three types of angles a triangle can have, Right, Acute, and Obtuse.
        private enum TriangleAngleTypeCategories
        {
            // Has one angle of exactly 90 degrees.
            RightAngled,
            // All angles are less than 90 degrees.
            AcuteAngled,
            // Has one angle more than 90 degrees.
            ObtuseAngled

        }

        // I am using a value of 179.8F for maximum of each angle because there needs to be room for all three angles, and if each has a minimum of 0.1 then the maximum must
        // leave room for (MaxAngleValue) + (MinAngleValue) + (MinAngleValue) which translates into (179.8) + (0.1) + (0.1) = 180.0.
        private const double _MaximumAngleValue = 179.8;
       
        // This constant represents the minimum value this class will allow for its triangle.
        private const double _MinimumAngleValue = 0.1;
        
        // This constant represents the total degrees in a triangle.
        private const double _DegreesInATriangle = 180.0;
       
        // This constant represents the largest value acceptable for a side length.
        private const double _MaxSideLength = 1000000;
        
        // This constant represents the smallest value acceptable for a side length.
        private const double _MinSideLength = 0.00001;

        // This constant represents the largest value acceptable for area.
        private const double _MaxAreaValue = 1000000;

        // This constant represents the smallest value acceptable for area.
        private const double _MinAreaValue = 0.00001;

        // This constant represents the number of decimal places to keep in calculations.
        private const int _NumberOfDecimalPlacesToKeep = 5;

        // These values are used to hold the angles.
        private double _AngleA;
        private double _AngleB;
        private double _AngleC;

        // These values are used to hold the side lengths.
        private double _SideA;
        private double _SideB;
        private double _SideC;

        // This value is used to hold the area of the triangle. This value is only valid if the triangle is a right angled triangle.
        private double _Area;

        // This variable is used to hold the current triangle type (Equilateral, Isosceles, Scalene).
        private int _TriangleType;

        // This variable is used to hold the current triangle's angle type (Right, Acute, Obtuse).
        private int _TriangleAngleType;

        // Property accessor for _TriangleType.
        public int TriangleType
        {
            get
            {
                return _TriangleType;
            }
            set 
            {
                // If value is equal to the int equivalents of the enum TriangleAngleTypeCategories (0-2) allow it through
                if (value >= (int)TriangleTypeCategories.Equilateral && value <= (int)TriangleTypeCategories.Scalene)
                {
                    _TriangleType = value;
                }
            }

        }

        // Property accessor for _TriangleAngleType.
        public int TriangleAngleType
        {
            get
            {
                return _TriangleAngleType;
            }
            set
            {
                // If value is equal to the int equivalents of the enum TriangleAngleTypeCategories (0-2) allow it through
                if (value >= (int)TriangleAngleTypeCategories.RightAngled && value <= (int)TriangleAngleTypeCategories.ObtuseAngled)
                {
                    _TriangleAngleType = value;
                }
            }
        }

        // Property accessor for _AngleA.
        public double AngleA
        {
            get
            {
                return _AngleA;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleA = Math.Round(value, 1);
                }
            }
                
        }

        // Property accessor for _AngleB.
        public double AngleB
        {
            get
            {
                return _AngleB;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleB = Math.Round(value, 1);
                }

            }
        }

        // Property accessor for _AngleC.
        public double AngleC
        {
            get
            {
                return _AngleC;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleC = Math.Round(value, 1);
                }
            }
        }

        // Property accessor for SideA.
        public double SideA
        {
            get
            {
                return _SideA;
            }
            set
            {
                if (value > _MinSideLength && value < _MaxSideLength)
                {
                    _SideA = value;
                }
            }
        }

        // Property accessor for SideB.
        public double SideB
        {
            get
            {
                return _SideB;
            }
            set
            {
                if (value > _MinSideLength && value < _MaxSideLength)
                {
                    _SideB = value;
                }
            }
        }

        // Property accessor for SideC.
        public double SideC
        {
            get
            {
                return _SideC;
            }
            set
            {
                if (value > _MinSideLength && value < _MaxSideLength)
                {
                    _SideC = value;
                }
            }
        }

        // Property accessor for Area.
        public double Area
        {
            get
            {
                return _Area;
            }
            set
            {
                if (value > _MinAreaValue && value < _MaxAreaValue)
                {
                    _Area = value;
                }
            }
        }

        // Read only property accessor for _MaxSideLength.
        public double MaxSideLength
        {
            get
            {
                return _MaxSideLength;
            }
        }

        // Read only property accessor for _MinSideLength.
        public double MinSideLength
        {
            get
            {
                return _MinSideLength;
            }
        }

        // Read only property accessor for _MaxSideLength.
        public double MaxAreaValue
        {
            get
            {
                return _MaxAreaValue;
            }
        }

        // Read only property accessor for _MinSideLength.
        public double MinAreaValue
        {
            get
            {
                return _MinAreaValue;
            }
        }

        // Read only property property accessor for _MaximumAngleValue.
        public double MaximumAngleValue
        {
            get
            {
                return _MaximumAngleValue;
            }
        }

        // Read only property accessor for _MinimumAngleValue.
        public double MinimumAngleValue
        {
            get
            {
                return _MinimumAngleValue;
            }
        }

        // Read only property accessor for _DegreesInATriangle.
        public double DegreesInATriangle
        {
            get
            {
                return _DegreesInATriangle;
            }
        }

        // Method(s):

        /*
        **	Method Name:	Triangle()
        **	Parameters:		None, is constructor.
        **	Return Values:	None, is constructor.
        **	Description:	This is one of the overloaded constructor methods for the Triangle class. This one constructs a triangle using default
        **                  values. It will construct a triangle with 3 internal angles of 60.0 degrees each. This is an equilateral triangle with acute angles.
        **                  Sides are gives default values of 1.0 each.
        */
        public Triangle()
        {
            _AngleA = 60.0;
            _AngleB = 60.0;
            _AngleC = 60.0;

            _SideA = 1.0;
            _SideB = 1.0;
            _SideC = 1.0;

            _TriangleType = (int)TriangleTypeCategories.Equilateral;
            _TriangleAngleType = (int)TriangleAngleTypeCategories.AcuteAngled;
        }

        /*
        **	Method Name:	Triangle()
        **	Parameters:		None, is constructor.
        **	Return Values:	None, is constructor.
        **	Description:	This is one of the overloaded constructor methods for the TriangleStuffClass class. This one constructs a triangle using 3 incomming parameters
        **                  which represent the three internal angles of the triangle.
        *   Exceptions:     This method can throw exceptions of ArgumentOutOfRangeException type.
        */
        public Triangle(double AngleA, double AngleB, double AngleC)
        {
            if(ValidateAngle(AngleA) == false)
            {
                throw new ArgumentOutOfRangeException("AngleA");
            }

            if(ValidateAngle(AngleB) == false)
            {
                throw new ArgumentOutOfRangeException("AngleB");
            }

            if (ValidateAngle(AngleC) == false)
            {
                throw new ArgumentOutOfRangeException("AngleC");
            }

            // If processing reaches here then all 3 angles have passed validation.
            if(ValidateTriangle(AngleA, AngleB, AngleC))
            {
                _AngleA = AngleA;
                _AngleB = AngleB;
                _AngleC = AngleC;
            }
            else
            {
                // Triangle is invalid
                throw new Exception("Triangle does not have exactly 180 degrees.");
            }

            _SideA = 1.0;
            _SideB = 1.0;
            _SideC = 1.0;

            _TriangleType = (int)TriangleTypeCategories.Equilateral;
            _TriangleAngleType = (int)TriangleAngleTypeCategories.AcuteAngled;
        }

        /*
        **	Method Name:	WhatTypeOfAngle()
        **	Parameters:		None.
        **	Return Values:	string: A string containing the angle of the triangle.
        **	Description:	This method returns a string indicating the type of angle of the currently loaded triangle.
        */
        public string WhatTypeOfAngle()
        {
            string ReturnString = "";
            int Result = 0;

            double RoundedNinetyDegrees = Math.Round((double)90, 1);

            if(_AngleA > RoundedNinetyDegrees)
            {
                // AngleA is an obtuse angle, making the triangle an Obtuse triangle.
                Result = (int)TriangleAngleTypeCategories.ObtuseAngled;
            }
            else if(_AngleA == RoundedNinetyDegrees)
            {
                // AngleA is a right angle, 
                Result = (int)TriangleAngleTypeCategories.RightAngled;
            }
            else if(_AngleA < RoundedNinetyDegrees)
            {
                // Angle A is an acute angle. Must determine what the other angles are now.

                if(_AngleB > RoundedNinetyDegrees)
                {
                    // AngleB is an obtuse angle, making the triangle an Obtuse triangle.
                    Result = (int)TriangleAngleTypeCategories.ObtuseAngled;
                }
                else if(_AngleB == RoundedNinetyDegrees)
                {
                    // Angle B is a right angle, making the triangle a right angled triangle.
                    Result = (int)TriangleAngleTypeCategories.RightAngled;
                }
                else if(_AngleB < RoundedNinetyDegrees)
                {
                    // AngleB is an acute angle, must determine what Angle C is.

                   if(_AngleC > RoundedNinetyDegrees)
                    {
                        // AngleC is an obtuse angle, making the triangle an Obtuse triangle.
                        Result = (int)TriangleAngleTypeCategories.ObtuseAngled;
                    }
                   else if(_AngleC == RoundedNinetyDegrees)
                    {
                        // AngleC is a right angle, making the triangle a right angled triangle..
                        Result = (int)TriangleAngleTypeCategories.RightAngled;
                    }
                   else if(_AngleC < RoundedNinetyDegrees)
                    {
                        // AngleC is an acute angle, as are all previous angles, making this triangle an Acute triangle.
                        Result = (int)TriangleAngleTypeCategories.AcuteAngled;
                    }
                }
            }

            if (Result == (int)TriangleAngleTypeCategories.AcuteAngled)
            {
                ReturnString = "Acute";
            }
            else if (Result == (int)TriangleAngleTypeCategories.ObtuseAngled)
            {
                ReturnString = "Obtuse";
            }
            else if(Result == (int)TriangleAngleTypeCategories.RightAngled)
            {
                ReturnString = "Right";
            }

            return ReturnString;
        }

        /*
        **	Method Name:	WhatKindOfTriangle
        **	Parameters:		None.
        **	Return Values:	string: A string containing the type of the triangle.
        **	Description:	This method returns a string indicating the type of the currently loaded triangle.
        */
        public string WhatKindOfTriangle()
        {
            int Result = 0;
            string ReturnString = "";

            if(_AngleA == _AngleB)
            {
                if(_AngleB == _AngleC)
                {
                    // Triangle is equilateral.
                    Result = (int)TriangleTypeCategories.Equilateral;
                }
                else
                {
                    // Triangle has 2 out of 3 angles the same, it is Isosceles.
                    Result = (int)TriangleTypeCategories.Isosceles;
                }

            }
            else
            {
                // Triangle has no equal sides, it is Scalene.
                Result = (int)TriangleTypeCategories.Scalene;
            }

            if(Result == (int)TriangleTypeCategories.Scalene)
            {
                ReturnString = "Scalene";
            }
            else if(Result == (int)TriangleTypeCategories.Equilateral)
            {
                ReturnString = "Equilateral";
            }
            else if(Result == (int)TriangleTypeCategories.Isosceles)
            {
                ReturnString = "Isosceles";
            }

            return ReturnString;
        }

        /*
        **	Method Name:	IsRightTriangle()
        **	Parameters:		None.
        **	Return Values:	bool; This method returns boolean true when the currently loaded angle values indicate a right angled triangle.
        **	Description:	This method returns a boolean value to indicate wheter the currently loaded triangle is a right angled triangle.
        **                  To determine if the triangle is right angled it calls the WhatTypeOfAngle method, and passes on true if its right angled.
        */
        public bool IsRightTriangle()
        {
            bool Result = false;

            if (WhatTypeOfAngle() == "Right")
            {
                Result = true;
            }

            return Result;
        }

        /*
        **	Method Name:	InsertNewTriangle()
        **	Parameters:		double FirstAngle:  A double containing the first angle of the new triangle.
        *                   double SecondAngle: A double containing the second angle of the new triangle.
        *                   double ThirdAngle: A double containing the third angle of the new triangle.
        **	Return Values:	bool:
        **	Description:	This method is used to insert a new triangle into the class. It calls the triangle validation method to verify its of correct angles
        **                  before inserting the new angles in.
        */
        public bool InsertNewTriangle(double FirstAngle, double SecondAngle, double ThirdAngle)
        {
            bool Result = false;

            Result = ValidateTriangle(FirstAngle, SecondAngle, ThirdAngle);

            if (Result == true)
            {
                AngleA = FirstAngle;
                AngleB = SecondAngle;
                AngleC = ThirdAngle;
            }

            return Result;
            
        }

        /*
        **	Method Name:	DetermineAreaOfRightTriangle()
        **	Parameters:		double SideA:   Thie first side of the right angled triangle.
        *                   double SideB:   The second side of the right angled triangle.
        **	Return Values:	double: The result of the calculation. This value is the area of a right triangle having the dimensions specified by SideA and SideB.
        **	Description:	This method is used to calculate the area of a right triangle. Nothing major, just some basic triangle math and a return value.
        */
        public double DetermineAreaOfRightTriangle(double SideA, double SideB)
        {
            double AreaOfTriangle = 0;

            if (ValidateSideLength(SideA) && ValidateSideLength(SideB))
            {
                AreaOfTriangle = 0.5 * (SideA * SideB);
                AreaOfTriangle = Math.Round(AreaOfTriangle, _NumberOfDecimalPlacesToKeep);
            }

            return AreaOfTriangle;
        }

        /*
        **	Method Name:	ValidateAngle()
        **	Parameters:		double Angle: This double holds the user's angle which must be validated before used in calculations.
        **	Return Values:	bool; This method returns boolean true when validation passes and false when it does not.
        **	Description:	This method validates an incomming double by ensuring it's value is between MinimuimAngleValue(0.1) and MaximumAngleValue(179.8).
        **                  An angle of 0.0 would be invalid, as it would not be an angle at all, so I choose 0.1 as minimum angle.
        **                  Any one angle being 179.9 degrees or more would not leave enough for the minimums for the othe two angles. That is why 179.8 was chosen as max.
        */
        public static bool ValidateAngle(double Angle)
        {
            bool Result = false;

            // Checking to ensure Angle is within acceptable limits. The limits used here are mostly unrestricted, just ensuring the angle is within the min and max values for an angle.
            if (Angle >= _MinimumAngleValue && Angle <= _MaximumAngleValue)
            {
                Result = true;
            }
            else
            {
                Console.WriteLine("Number did NOT pass validation");
            }

            return Result;
        }

        /*
        **	Method Name:	ValidateTriangle()
        **	Parameters:		double AngleA:  The first angle of the triangle to validate.
        *                   double AngleB:  The second angle of the triangle to validate.
        *                   double AngleC:  The third angle of the triangle to valdiate.
        **	Return Values:	bool:   This method returns true to indicate the triangle is valid, and false to indicate it is not.
        **	Description:	This method is designed to validate a triangle by comparing the sum of the angles with the known required value for a valid triangle (180 degrees).
        **  Note:           This method is declared as static, so can not call non-static methods.
        */
        public static bool ValidateTriangle(double AngleA, double AngleB, double AngleC)
        {
            bool Result = false;

            // Sum the values of the angles, round them, and determine if they are equal to 180.0 degrees. 
            double RoundedAngleSum = Math.Round((AngleA + AngleB + AngleC), 1);
            double RoundedDegreesInATriangle = Math.Round(_DegreesInATriangle, 1);
            
            if(RoundedAngleSum == RoundedDegreesInATriangle)
            {
                // This triangle matches the requirement of having 180 degrees.
                Result = true;
            }
            else
            {
                // Triangle angles do not add up to 180.0. This triangle is invalid!
                Result = false;
            }

            return Result;
        }

        /*
        **	Method Name:	ValidateSideLength()
        **	Parameters:		double Side: The side to be validated.
        **	Return Values:	bool: This method returns true to indicate a valid side length, and false to indicate an invalid side length.
        **	Description:	This method returns true to indicate a valid side length, and false to indicate an invalid side length. 
        *   Note:           Declared as static, so can not call non-static methods.
        */
        public static bool ValidateSideLength(double Side)
        {
            bool Result = false;

            if(Side <= _MaxSideLength && Side >= _MinSideLength)
            {
                Result = true;
            }

            return Result;
        }


        /*
        **	Method Name:	DetermineThirdAngle()
        **	Parameters:		double AngleA:  The first angle, to be used to calculate the third.
        *                   double AngleB:  The second angle, to be used to calculate the third.
        **	Return Values:	double: The resulting third angle.
        **	Description:	This method is designed to determine a third triangle angle given the first and second.
        *   Note:           This method is declared as static, so can not call non-static methods.
        */
        public static double DetermineThirdAngle(double AngleA, double AngleB)
        {
            double AngleC = 0F;

            double RoundedAngleA = Math.Round(AngleA, 1);
            double RoundedAngleB = Math.Round(AngleB, 1);
            double RoundedDegreesInATriangle = Math.Round(_DegreesInATriangle, 1);

            if ((RoundedAngleA + RoundedAngleB) < RoundedDegreesInATriangle)
            {
                AngleC = RoundedDegreesInATriangle - (RoundedAngleA + RoundedAngleB);
                AngleC = Math.Round(AngleC, 1);
            }

            return AngleC;
        }

        /*
        **	Method Name:	DetermineHypotenuse
        **	Parameters:		double SideA:   The first side used as part of the calculation.
        *                   double SideB:   The second side used as part of the calculation.
        **	Return Values:	double: This method returns a double containing the hypotenuse.
        **	Description:	This method is used to determine a hypotenuse, when given SideA and SideB. 
        */
        public static double DetermineHypotenuse(double SideA, double SideB)
        {
            double Hypotenuse = 0F;
            double HypotenuseSquared = 0F;

            HypotenuseSquared = (SideA * SideA) + (SideB * SideB);
            Hypotenuse = Math.Sqrt(HypotenuseSquared);

            return Hypotenuse;

        }
    }
}
