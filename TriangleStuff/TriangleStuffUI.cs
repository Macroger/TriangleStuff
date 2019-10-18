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
     /*
     **  Class Name: TriangleStuffUI
     **  Description: This class is designed to act as the UI layer between the user and the underlying Triangle class it uses.
     */
    class TriangleStuffUI
    {

        // Datamember(s):

        // This enum is used to hold the values that will be checked against the users' input to determine which option they wish to use. Main objective is to prevent magic numbers.
        private enum MainMenuOptionsEnum
        {
            InputNewTriangle = 1,
            AdjustSideA,
            AdjustSideB,
            CalculateHypotenuse,
            CalculateArea,
            Quit
        }

        // This list of strings is used to hold the options that should be displayed on the screen.
        private List<string> MainMenuOptions = new List<string>
        {
            "Input New Triangle",
            "Adjust Side A Length",
            "Adjust Side B Length", 
            "Calculate Hypotenuse",
            "Calculate Area",
            "Quit"

        };

        // This const char is the value for a degree symbol. Used to enrich the display elements with the actual degree symbol instead of text "degrees".
        private const char AsciiDegreeSymbol = (char)176;

        //  An instantiated object of type Triangle. Used to do most of the actual processing as this class is just the UI to Triangle.
        private Triangle myTriangle = new Triangle();

        // Method(s):

        /*
        **	Method Name:	DrawMainMenu()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This method is used to display the main menu to the user. It also prompts the user for input and determines which screen to activate.
        */
        public void DrawMainMenu()
        {
            string UserResponse = "";

            // This while loop looks to see if the user entered the last value contained in the MainMenuOptions list, which by convention should be the Quit option.
            while(UserResponse != MainMenuOptions.Count.ToString())
            {
                // Clear the console screen incase anything else was displayed.
                Console.Clear();

                // Display the main information screen including details on the triangle currently loaded.
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
                    $"\n{(myTriangle.WhatTypeOfAngle() == "Right" ? ($"Area: {myTriangle.Area:N3}" ): "")} " +
                    "\n\n\n" +
                    "Menu Options:" +
                    "\n"
                    );

                // Using a loop to display the options the user can choose from, based on the MainMenuOptions list.
                for (int i = 0; i < MainMenuOptions.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".) " + MainMenuOptions[i]);
                }
                
                Console.Write("\nSelection: ");

                // Get user's input.
                UserResponse = Console.ReadLine();

                // If the user's input is valid, determine which option they chose.
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

                        case (int)MainMenuOptionsEnum.CalculateArea:
                            DisplayCalculateAreaScreen();
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

        /*
        **	Method Name:	DisplayCalculateHypotenuseScreen()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This method shows the calculate hypotenuse screen, but only if the currently loaded triangle qualifies as right angled.
        */
        public void DisplayCalculateHypotenuseScreen()
        {
            if(myTriangle.IsRightTriangle() == true)
            {
                Console.Clear();

                double RawHypotenuse = Triangle.DetermineHypotenuse(myTriangle.SideA, myTriangle.SideB);
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

        /*
        **	Method Name:	DisplayCalculateAreaScreen()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This method shows the calculate area screen, but only if the currently loaded triangle qualifies as right angled.
        */
        public void DisplayCalculateAreaScreen()
        {
            if (myTriangle.IsRightTriangle() == true)
            {
                Console.Clear();

                double RawArea = myTriangle.DetermineAreaOfRightTriangle(myTriangle.SideA, myTriangle.SideB);
                myTriangle.Area = Math.Round(RawArea, 3);
                Console.Write(
                  "Triangle Stuff UI v0.1" +
                   "\n" +
                   $"Calculate Area Screen." +
                   "\n\n" +
                   $"This screen will automatically calculate the area based on the sides of the currently loaded right angled triangle." +
                   "\n\n" +
                   $"Side A: {myTriangle.SideA}." +
                   "\n" +
                   $"Side B: {myTriangle.SideB}." +
                   "\n" +
                   $"Area: {myTriangle.Area}." +
                   "\n\n"
                   );
            }
            else
            {
                Console.WriteLine("\n\nError, the current triangle is not right angled.\nCalculate area menu option only applies to right angled triangles.\n\n");
            }
        }

        /*
        **	Method Name:	DisplayAdjustSideScreen()
        **	Parameters:		string WhichSide: This string determines which side this screen is working on.
        **	Return Values:	Void.
        **	Description:	This method is used to display the screen for adjusting a side length. Its used for both side A and B. It determines which side it is working on
        **                  by looking at WhichSide. It uses a regex pattern to allow only a specific range of numbers (0.0001 - 1,000,000).
        */

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

        /*
        **	Method Name:	DisplayInsertNewAnglesSreen()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This method is used to display the screen for inputting new angles into the triangle. Because of the nature of a triangle it is impossible to update only one angle, it would invalidate the rest.
        **                  Instead, this method gets the user to input two angles at a time and calculates the third.
        */
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

        /*
        **	Method Name:	PressAnyKeyToContiue()
        **	Parameters:		None.
        **	Return Values:	Void.
        **	Description:	This method is used to display a short message and wait for the user to enter input of any kind. Just a shortcut to a function I found myself using often.
        */
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

        /*
        **	Method Name:	ValidateSideLengthString()
        **	Parameters:		string UserResponse: This string is the user's input string, which should be check to ensure its valid.
        **	Return Values:	bool: This method returns a boolean value to indicate whether the string passed validation. It returns True when validation passes, and False when it fails.
        **	Description:	This method is used to validate a user's input for side length. It uses a regex pattern that allows numbers between 0.00001 and 1,000,000 inclusive.
        */
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
