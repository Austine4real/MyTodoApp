using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryToDo
{
    public class AppEntry
    {
        static UserManager userManager = new UserManager();
        static TaskManager taskManager = new TaskManager();
        string json = JsonConvert.SerializeObject(taskManager, Formatting.Indented);
        
        public static void MyAppEntry()
        {
            bool exit = false;

            while (!exit)
            {
                Animation.DisplayWelcome();
                MyMethod.DisplayMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        User registeredUser = userManager.Register();
                        if (registeredUser != null)
                        {
                            //Console.WriteLine("Registration successful. You are now automatically logged in.");
                            Animation.DisplayRegistrationSuccess();
                            TaskMenu(registeredUser);
                        }
                        break;

                    case "2":
                        User loggedInUser = userManager.Login();

                        if (loggedInUser != null)
                        {
                            Animation.DisplayLoginSuccess();
                            TaskMenu(loggedInUser);
                        }
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine(json);

                //Console.WriteLine();
            }
        }
        static void TaskMenu(User currentUser)
        {
            bool logout = false;

            while (!logout)
            {
                MyMethod.DisplayTaskMenu(currentUser.Name);

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        taskManager.AddTask(currentUser.Tasks, currentUser.Id);
                        break;

                    case "2":
                        taskManager.ViewAllTasks(currentUser.Tasks);
                        break;

                    case "3":
                        taskManager.ViewAllTasks(currentUser.Tasks);
                        taskManager.EditTask(currentUser.Tasks);
                        break;

                    case "4":
                        taskManager.ViewAllTasks(currentUser.Tasks);
                        taskManager.DeleteTask(currentUser.Tasks, currentUser);
                        break;

                    case "5":
                        taskManager.ViewAllTasks(currentUser.Tasks);
                        taskManager.CompleteTask(currentUser.Tasks);
                        break;
                    case "6":
                        taskManager.ViewAllReport(currentUser.Tasks);
                        break;

                    case "7":
                        currentUser.IsLoggedIn = false;
                        Animation.DisplayLogoutSuccess();
                        logout = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Animation.PressAnyKeyToContinue();
            }
        }
    }
}
