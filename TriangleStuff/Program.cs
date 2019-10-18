/*
**  File Name:      Program.cs
**	Project Name:	TriangleStuff
**	Author:         Matthew G. Schatz
**  Date:           October 18, 2019
**	Description:	This file holds the source code for the Program class. This class is used as the main entry point of the application and only has two statements.
**                  It just instantiates a TriangleStuffUI object and then calls the DrawMainMenu method to hand off operation to the UI class.
*/

namespace TriangleStuff
{
    class Program
    {
        static void Main()
        {
            TriangleStuffUI myTriangleStuffUI = new TriangleStuffUI();

            myTriangleStuffUI.DrawMainMenu();
                                  
        }
    }
}
