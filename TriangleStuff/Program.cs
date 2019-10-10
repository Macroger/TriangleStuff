using System;

namespace TriangleStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            float AngleA = 90.0F;
            float AngleB = 45.0F;
            float AngleC = 45.0F;


            try
            {
               TriangleStuffClass myTriangle = new TriangleStuffClass(AngleA, AngleB, AngleC);

                if(myTriangle.IsRightTriangle())
                {
                    Console.WriteLine("This triangle is a right triangle.");

                }
                else
                {
                    Console.WriteLine("This triangle is NOT a right triangle.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception caught! Details: ", ex.Message);
            }
        }
    }
}
