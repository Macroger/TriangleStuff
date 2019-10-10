using System;
using System.Collections.Generic;
using System.Text;

namespace TriangleStuff
{
    public class TriangleStuffClass
    {
        // Data Members

        private float _AngleA;
        private float _AngleB;
        private float _AngleC;

        public float AngleA
        {
            get
            {
                return _AngleA;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleA = value;
                }
            }
                
        }

        public float AngleB
        {
            get
            {
                return _AngleB;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleB = value;
                }

            }
        }

            
        public float AngleC
        {
            get
            {
                return _AngleC;
            }
            set
            {
                if (ValidateAngle(value))
                {
                    _AngleC = value;
                }
            }
        }
                     

        public TriangleStuffClass()
        {
            // In this parameterless constructor the default setup is to be an equilateral triangle, I.E., all angles are 60 degress.
            _AngleA = 60.0F;
            _AngleB = 60.0F;
            _AngleC = 60.0F;
        }
        public TriangleStuffClass(float AngleA, float AngleB, float AngleC)
        {
            if(ValidateAngle(AngleA))
            {
                _AngleA = AngleA;
            }
            else
            {
                throw new ArgumentOutOfRangeException("AngleA");
            }

            if(ValidateAngle(AngleB))
            {
                _AngleB = AngleB;
            }
            else
            {
                throw new ArgumentOutOfRangeException("AngleB");
            }

            if (ValidateAngle(AngleC))
            {
                _AngleB = AngleB;
            }
            else
            {
                throw new ArgumentOutOfRangeException("AngleC");
            }
        }
        public bool IsRightTriangle()
        {
            float UpperLimit = 90.99999F;
            float LowerLimit = 90.00001F;
            bool Result = false;
            int NumberOfRightAngles = 0;

            // This checks if _AngleA is approximately greater than 89 degrees, and less than approximately 91 degrees.
            // If so, this triangle is a right angled triangle. (Unless it has more than 1 angle thats 90 degrees).
            if(_AngleA >= LowerLimit && _AngleA <= UpperLimit)
            {
                NumberOfRightAngles++;
            }

            if (_AngleB >= LowerLimit && _AngleB <= UpperLimit)
            {
                NumberOfRightAngles++;
            }

            if (_AngleC >= LowerLimit && _AngleC <= UpperLimit)
            {
                NumberOfRightAngles++;
            }
            
            // Check if there was a right angle found. However, if more than one was found there is an error.
            if(NumberOfRightAngles == 1)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }

            return Result;
        }

        public static bool ValidateAngle(float Angle)
        {
            bool Result = false;

            if(Angle >= 0.0F && Angle < 180.0F)
            {
                Result = true;
            }
            return Result;

        }
    }
}
