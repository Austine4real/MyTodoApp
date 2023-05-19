using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassLibraryToDo
{
    public class Animation
    {
        public static void Animate(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
        }
        public static void DisplayWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Animate("Welcome to Todo Console App!\n");
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void DisplayInvalidChoice()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Animate("Invalid choice.\n\n");
            Console.ResetColor();
        }

        public static void DisplayRegistrationSuccess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Animate("Registration successful!\n\n");
            Console.ResetColor();
        }

        public static void DisplayLoginSuccess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Animate("Login successful!\n\n");
            Console.ResetColor();
        }

        public static void DisplayLogoutSuccess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Animate("Logged out successful!\n\n");
            Console.ResetColor();
        }
        public static void PressAnyKeyToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Animate("Press any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
