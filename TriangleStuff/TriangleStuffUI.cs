/*
**  File Name:      TriangleStuffUI.cs
**	Project Name:	TriangleStuff
**	Author:         Matthew G. Schatz
**  Date:           October 10, 2019
**	Description:	This file contains the class definition for the TriangleStuffUI. This class is designed to provide the User Interface for any
**                  interactions between the user and the TriangleStuffClass class. This user interface does not need to be complicated so it will
**                  be implemented as a console interface.
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TriangleStuff
{
    class TriangleStuffUI
    {
        private enum MainMenuOptionsEnum
        {
            InputNewTriangle = 1,
            AdjustSideA,
            AdjustSideB,
            CalculateHypotenuse,
            Quit
        }
        private List<string> MainMenuOptions = new List<string>
        {
            "Input New Triangle",
            "Adjust Side A Length",
            "Adjust Side B Length", 
            "Calculate Hypotenuse",
            "Quit"

        };

        private const char AsciiDegreeSymbol = (char)176;

        private TriangleStuffClass myTriangle = new TriangleStuffClass();

        public void DrawMainMenu()
        {
            string UserResponse = "";

            // This while loop looks to see if the user entered the last value contained in the MainMenuOptions list, which by convention should be the Quit option.
            while(UserResponse != MainMenuOptions.Count.ToString())
            {
                // Clear the console screen incase anything else was displayed.
                Console.Clear();

                Console.WriteLine(
                    "Triangle Stuff UI v0.1" +
                    "\n\n\n" +
                    "Current Triangle Statistics:" +
                    "\n" +
                    $"\nType of Triangle: {myTriangle.WhatKindOfTriangle()}" +
                    $"\nType of Angles: {myTriangle.WhatTypeOfAngle()}" +
                    "\n" +
                    $"\nAngle A: {myTriangle.AngleA:N1}{AsciiDegreeSymbol} " +
                    $"\nAngle B: {myTriangle.AngleB:N1}{AsciiDegreeSymbol} " +
                    $"\nAngle C: {myTriangle.AngleC:N1}{AsciiDegreeSymbol} " +
                    "\n" +
                    $"\nSide A: {myTriangle.SideA:N3}" +
                    $"\nSide B: {myTriangle.SideB:N3}" +
                    $"\n{(myTriangle.WhatTypeOfAngle() == "Right" ? "Hypotenuse" : "Side C")}: {myTriangle.SideC:N3}" +
                    "\n\n\n" +
                    "Menu Options:" +
                    "\n"
                    );

                for (int i = 0; i < MainMenuOptions.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".) " + MainMenuOptions[i]);
                }

                Console.Write("\nSelection: ");

                UserResponse = Console.ReadLine();

                if(ValidateMainMenuOptionChoice(UserResponse))
                {
                    int UserResponseValue = Int32.Parse(UserResponse);

                    switch (UserResponseValue)
                    {
                        case (int)MainMenuOptionsEnum.InputNewTriangle:
                            DisplayInsertNewAnglesSreen();
                            PressAnyKeyToContiue();
                            break;

                        case (int)MainMenuOptionsEnum.AdjustSideA:
                            DisplayAdjustSideScreen("A");
                            PressAnyKeyToContiue();
                            break;

                        case (int)MainMenuOptionsEnum.AdjustSideB:
                            DisplayAdjustSideScreen("B");
                            break;

                        case (int)MainMenuOptionsEnum.CalculateHypotenuse:
                            DisplayCalculateHypotenuseScreen();
                            PressAnyKeyToContiue();
                            break;

                        case (int)MainMenuOptionsEnum.Quit:
                            Console.WriteLine("\nExiting program...");
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"\nInvalid choice. Please try again or enter {MainMenuOptions.Count} to quit.");
                    PressAnyKeyToContiue();
                } 
            }
        }


        public void DisplayCalculateHypotenuseScreen()
        {
            if(myTriangle.IsRightTriangle() == true)
            {
                Console.Clear();

                double RawHypotenuse = TriangleStuffClass.DetermineHypotenuse(myTriangle.SideA, myTriangle.SideB);
                myTriangle.SideC = Math.Round(RawHypotenuse, 3);
                Console.Write(
                  "Triangle Stuff UI v0.1" +
                   "\n" +
                   $"Calculate Hypotenuse Screen." +
                   "\n\n" +
                   $"This screen will automatically calculate the length of the hypotenuse based on the sides of the currently loaded right angled triangle." +
                   "\n\n" +
                   $"Side A: {myTriangle.SideA}." +
                   "\n" +
                   $"Side B: {myTriangle.SideB}." +
                   "\n" +
                   $"Hypotenuse: {myTriangle.SideC}." +
                   "\n\n"
                   );
            }
            else
            {
                Console.WriteLine("\n\nError, the current triangle is not right angled.\nCalculate hypotenuse menu option only applies to right angled triangles.\n\n");
            }
        }


        public void DisplayAdjustSideScreen(string WhichSide)
        {
            string UserResponse = "";
            bool OperationComplete = false;

            while (UserResponse != "Q" && OperationComplete == false)
            {
                Console.Clear();

                Console.Write(
                  "Triangle Stuff UI v0.1" +
                   "\n" +
                   $"Adjust Side{WhichSide} Length Screen." +
                   "\n\n" +
                   $"This screen will allow you to edit the length of Side{WhichSide}." +
                   "\n" +
                   $"The maximum allowed length for sides is {myTriangle.MaxSideLength}." +
                   "\n\n" +
                   $"Please enter the length with upto 1,000,000 with or without 5 decimal places, I.E., 1,000,000, 0.00001, 5.5." +
                   "\n" +
                   "\nNew Length: "
                   );

                UserResponse = Console.ReadLine();
                UserResponse = UserResponse.ToUpper();

                if(ValidateSideLengthString(UserResponse))
                {
                    if(WhichSide == "A")
                    {
                        myTriangle.SideA = Double.Parse(UserResponse);
                        Console.WriteLine($"\nSide{WhichSide} updated to: {myTriangle.SideA}.");
                    }
                    else if(WhichSide == "B")
                    {
                        myTriangle.SideB = Double.Parse(UserResponse);
                        Console.WriteLine($"\nSide{WhichSide} updated to: {myTriangle.SideB}.");
                    }
                    else if(WhichSide == "C")
                    {
                        myTriangle.SideC = Double.Parse(UserResponse);
                        Console.WriteLine($"\nSide{WhichSide} updated to: {myTriangle.SideC}.");
                    }

                    OperationComplete = true;
                }
                else
                {
                    if (UserResponse == "Q")
                    {
                        Console.WriteLine("\nDetected Q, exiting...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error. Invalid side length detected. Please keep between {myTriangle.MinSideLength:N5} and {myTriangle.MaxSideLength:N1}.");
                    }
                }
            }
        }


        public void DisplayInsertNewAnglesSreen()
        {
            string UserResponse = "";
            bool OperationComplete = false;

            double AngleA = 0;
            double AngleB = 0;
            double AngleC = 0;

            while (UserResponse != "Q" && OperationComplete == false)
            {
                bool AngleAVerified = false;
                bool AngleBVerified = false;

                // Clear the console screen incase anything else was displayed.
                Console.Clear();

                Console.Write(
                   "Triangle Stuff UI v0.1" +
                    "\n" +
                    "Insert New Angles Screen." +
                    "\n\n" +
                    "This screen will allow you to enter all new angles for the triangle." +
                    "\n" +
                    $"The minimum angle allowed is {myTriangle.MinimumAngleValue:N1}{AsciiDegreeSymbol} and the maximum is {myTriangle.MaximumAngleValue:N1}{AsciiDegreeSymbol}." +
                    "\n\n" +
                    $"Please enter the angle to one decimal place, I.E., 90.0 for 90{AsciiDegreeSymbol}." + 
                    "\n"
                    );

                if(AngleAVerified == false)
                {
                    Console.Write("\nFirst Angle(Q to quit): ");

                    UserResponse = Console.ReadLine();
                    UserResponse = UserResponse.ToUpper();

                    if (ValidateAngleString(UserResponse) == true)
                    {
                        // This value is used to determine the next value that can be entered and still have a valid triangle.
                        double NextMaximumPossibleValue = 0;
                        double MinimumValueForAngleC = myTriangle.MinimumAngleValue;

                        AngleA = Double.Parse(UserResponse);

                        NextMaximumPossibleValue = myTriangle.DegreesInATriangle - AngleA - MinimumValueForAngleC;

                        Console.WriteLine($"Angle A accepted! The maximum value that can be entered next is: {NextMaximumPossibleValue:N1}.");

                        AngleAVerified = true;
                    }
                    else if (UserResponse == "Q")
                    {
                        Console.WriteLine("\nDetected Q, exiting...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Error. Invalid angle detected. Please keep between {myTriangle.MinimumAngleValue:N1} and {myTriangle.MaximumAngleValue:N1}.");
                    }
                }
                
                if(AngleBVerified == false)
                {
                    Console.Write("\nSecond Angle(Q to quit): ");

                    UserResponse = Console.ReadLine();
                    UserResponse = UserResponse.ToUpper();

                    if (ValidateAngleString(UserResponse) == true)
                    {
                        AngleB = Double.Parse(UserResponse);
                        AngleC = myTriangle.DegreesInATriangle - AngleA - AngleB;
                        AngleC = Math.Round(AngleC, 1);

                        Console.WriteLine($"Angle B accepted! The value of Angle C has been calculated as: {AngleC:N1}.");

                        AngleBVerified = true;

                    }
                    else if (UserResponse == "Q")
                    {
                        Console.WriteLine("\nDetected Q, exiting...");
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"\nError. Invalid angle detected. Valid range is between {myTriangle.MinimumAngleValue:N1} and {myTriangle.MaximumAngleValue:N1}.");
                    }
                }

                if(AngleAVerified == true && AngleBVerified == true)
                {
                    OperationComplete = true;
                }
            }

            if(OperationComplete == true)
            {
                if (myTriangle.InsertNewTriangle(AngleA, AngleB, AngleC))
                {
                    Console.WriteLine("\nSuccess! New Triangle succesfully entered.");
                }
                else
                {
                    Console.WriteLine("\nError. New Triangle failed to insert.");
                }
            }
        }

        public void PressAnyKeyToContiue()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
        }

        /*
        **	Method Name:	ValidateAngleString()
        **	Parameters:		string UserResponse: This string represents the user's choice of main menu options.
        **	Return Values:	bool; This method returns boolean true when validation passes and false when it does not.
        **	Description:	This method validates an incomming string by using a regex pattern to allow only values from 0.1 - 179.8 inclusive.
        */
        public bool ValidateAngleString(string UserResponse)
        {
            bool Result = false;

            // This regex will allow numbers in the range 0.1 - 179.8 inclusive.
            Regex RegExPattern = new Regex(@"^(([0]\.[1-9])|([1-9](\.[0-9])?)|([1-9][0-9](\.[0-9])?)|(1[0-7][0-8](\.[0-9])?)|(179)(\.[0-8])?)$");

            if (RegExPattern.IsMatch(UserResponse))
            {
                Result = true;
            }

            return Result;
        }

        public bool ValidateSideLengthString(string UserResponse)
        {
            bool Result = false;

            // This regex will allow numbers in the range 0.00001 - 1,000,000 inclusive. No trailing zeros allowed though.
            Regex RegExPattern = new Regex(@"^([1-9][0-9]{0,6}(\.[0-9]{0,4}[1-9])?|1000000)$");

            if (RegExPattern.IsMatch(UserResponse))
            {
                Result = true;
            }

            return Result;
        }
        /*
        **	Method Name:	ValidateOptionChoice()
        **	Parameters:		string UserResponse: This string represents the user's choice of main menu options.
        **	Return Values:	bool; This method returns boolean true when validation passes and false when it does not.
        **	Description:	This method validates an incomming string by using a regex pattern to allow only values from 1 to the number of options in the MainMenuOptions list.
        **                  BEWARE! This method will begin to fail to validate numbers if the MainMenuOptions list grows beyond 9 options. If that occurs new validation will be required.
        */
        public bool ValidateMainMenuOptionChoice(string UserResponse)
        {
            bool Result = false;

            // Convert the number of options in the MainMenuOptions list into a string so it may be used in the regex pattern.
            string MainMenuOptionCount = MainMenuOptions.Count.ToString();

            // This regex will allow numbers in the range 1 - MainMenuOptionCount which should correspond to the max options value.
            string RegExPattern = $"^([1-{MainMenuOptionCount}])$";
            Regex RegEx = new Regex(RegExPattern);

            if (RegEx.IsMatch(UserResponse))
            {
                Result = true;
            }

            return Result;
        }
    }
}
