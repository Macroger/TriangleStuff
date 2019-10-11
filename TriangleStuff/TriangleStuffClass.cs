using System;

namespace TriangleStuff
{
    public class TriangleStuffClass
    {
        // Data Members
        private enum TriangleTypeCategories
        {
            // Equilateral: Three equal sides, three equal angles.
            Equilateral = 1,
            //Isosceles: Two equal sides, Two equal angles.
            Isosceles,
            //Scalene: No equal sides, no equal angles.
            Scalene,

        }
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
        private const double _MinimumAngleValue = 0.1;
        private const double _DegreesInATriangle = 180.0;
        private const double _MaxSideLength = 1000000;
        private const double _MinSideLength = 0.00001;

        private double _AngleA;
        private double _AngleB;
        private double _AngleC;
        private double _SideA;
        private double _SideB;
        private double _SideC;

        private int _TriangleType;
        private int _TriangleAngleType;


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

        // Read only property.
        public double MaxSideLength
        {
            get
            {
                return _MaxSideLength;
            }
        }

        // Read only property.
        public double MinSideLength
        {
            get
            {
                return _MinSideLength;
            }
        }

        public double SideA
        {
            get
            {
                return _SideA;
            }
            set
            {
                if(value > 0 && value < _MaxSideLength)
                {
                    _SideA = value;
                }
            }
        }

        public double SideB
        {
            get
            {
                return _SideB;
            }
            set
            {
                if(value > 0 && value < _MaxSideLength)
                {
                    _SideB = value;
                }
            }
        }
        public double SideC
        {
            get
            {
                return _SideC;
            }
            set
            {
                if (value > 0 && value < _MaxSideLength)
                {
                    _SideC = value;
                }
            }
        }


        // Read only property.
        public double MaximumAngleValue
        {
            get
            {
                return _MaximumAngleValue;
            }
        }

        // Read only property.
        public double MinimumAngleValue
        {
            get
            {
                return _MinimumAngleValue;
            }
        }

        // Read only property.
        public double DegreesInATriangle
        {
            get
            {
                return _DegreesInATriangle;
            }
        }


        /*
        **	Method Name:	TriangleStuffClass()
        **	Parameters:		None, is constructor.
        **	Return Values:	None, is constructor.
        **	Description:	This is one of the overloaded constructor methods for the TriangleStuffClass class. This one constructs a triangle using default
        **                  values. It will construct a triangle with 3 internal angles of 60.0 degrees each. This is an equilateral triangle.
        */
        public TriangleStuffClass()
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
        **	Method Name:	TriangleStuffClass()
        **	Parameters:		None, is constructor.
        **	Return Values:	None, is constructor.
        **	Description:	This is one of the overloaded constructor methods for the TriangleStuffClass class. This one constructs a triangle using 2 incomming parameters
        **                  which represent the three internal angles of the triangle. The third angle will be computed from the first two.
        */
        public TriangleStuffClass(double AngleA, double AngleB)
        {

            if (ValidateAngle(AngleA) == false)
            {
                throw new ArgumentOutOfRangeException($"AngleA failed validation. It must be within the values {_MinimumAngleValue} and {_MaximumAngleValue}");
            }

            if (ValidateAngle(AngleB) == true)
            {
                // Is Angle B less than (TriangleTotalAngle - AngleA - (minPossibleValueforAngleC)).
                double MaxPossibleValueForAngleB = _DegreesInATriangle - AngleA - _MinimumAngleValue;

                // Using rounded values to avoid floating point precision issues.
                double RoundedMaxPossibleValueForAngleB = Math.Round(MaxPossibleValueForAngleB, 1);
                double RoundedAngleB = Math.Round(AngleB, 1);

                if (RoundedAngleB > RoundedMaxPossibleValueForAngleB)
                {
                    throw new ArgumentOutOfRangeException($"AngleB's value plus AngleA's value exceed {_DegreesInATriangle} degrees (the max for any triangle).");
                }

            }
            else
            {
                throw new ArgumentOutOfRangeException($"AngleB failed validation. It must be within the values {_MinimumAngleValue} and {_MaximumAngleValue}");
            }

            double AngleC = DetermineThirdAngle(AngleA, AngleB);

            if(AngleC >= _MinimumAngleValue)
            {
                _AngleA = AngleA;
                _AngleB = AngleB;
                _AngleC = AngleC;
            }
            else
            {
                // Triangle is invalid
                throw new Exception("Error computing AngleC, result was 0.");
            }

            _SideA = 1.0;
            _SideB = 1.0;
            _SideC = 1.0;

            _TriangleType = (int)TriangleTypeCategories.Equilateral;
            _TriangleAngleType = (int)TriangleAngleTypeCategories.AcuteAngled;
        }

        /*
        **	Method Name:	TriangleStuffClass()
        **	Parameters:		None, is constructor.
        **	Return Values:	None, is constructor.
        **	Description:	This is one of the overloaded constructor methods for the TriangleStuffClass class. This one constructs a triangle using 3 incomming parameters
        **                  which represent the three internal angles of the triangle.
        */
        public TriangleStuffClass(double AngleA, double AngleB, double AngleC)
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
        **                  Currently this method does this by rounding each angle and determining if it equals a (also rounded) value of 90.
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
        **	Method Name:	ValidateAngle()
        **	Parameters:		double Angle: This double holds the user's angle which must be validated before used in calculations.
        **	Return Values:	bool; This method returns boolean true when validation passes and false when it does not.
        **	Description:	This method validates an incomming double by ensuring it's value is between MinimuimAngleValue(0.1) and MaximumAngleValue(179.8).
        **                  An angle of 0.0 would be invalid, as it would not be an angle at all, so I choose 0.1 as minimum angle.
        **                  Any one angle being 179.9 degrees or more would not leave enough for the minimums for the othe two angles.
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

        public double DetermineAreaOfRightTriangle(double SideA, double SideB)
        {
            double AreaOfTriangle = 0;

            AreaOfTriangle = 0.5 * (SideA * SideB);

            return AreaOfTriangle;
        }

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
