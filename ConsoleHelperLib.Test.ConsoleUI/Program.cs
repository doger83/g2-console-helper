using System;

namespace ConsoleHelperLib.Test.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.CenterConsole();
            Console.WriteLine("Hello World!");

            ConsoleUtils.PositionConsole(150, 151);


            Console.WriteLine("Hit ENTER to close the Application..");
            Console.ReadLine();
        }


    }
}
