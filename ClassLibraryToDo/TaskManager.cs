using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibraryToDo
{
    public class TaskManager
    {
        public void AddTask(List<Task> tasks, Guid userId)
        {
            while (true)
            {
                Console.Write("Enter the task title: ");
                string title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                {
                    MyMethod.DisplayInvalidInputMessage("Task title cannot be empty. Please enter a valid title.");
                    continue;
                }
                else if (!Regex.IsMatch(title, @"^[A-Za-z0-9\s]+$"))
                {
                    MyMethod.DisplayInvalidInputMessage("Invalid title format. Please enter a title containing only letters, numbers, and spaces.");
                    continue;
                }
                else if (tasks.Any(t => t.Title == title))
                {
                    MyMethod.DisplayInvalidInputMessage("A task with the same title already exists. Please enter a unique title.");
                    continue;
                }

                string description = string.Empty;
                while (true)
                {

                    Console.Write("Enter the task description: ");
                    description = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(description))
                    {
                        MyMethod.DisplayInvalidInputMessage("Task description cannot be empty. Please enter a valid description.");
                        continue;
                    }

                    if (description.Length > 20)
                    {
                        MyMethod.DisplayInvalidInputMessage("Task description cannot be longer than 20 characters. Please enter a valid description.");
                        continue;
                    }

                    if (!Regex.IsMatch(description, @"^[a-zA-Z0-9.,!? ]+$"))
                    {
                        MyMethod.DisplayInvalidInputMessage("Task description contains invalid characters. Please enter a valid description.");
                        continue;
                    }
                    break;
                }

                DateTime dueDate;
                while (true)
                {
                    Console.Write("Enter the task due date (YYYY-MM-DD): ");
                    string dueDateString = Console.ReadLine();

                    if (!Regex.IsMatch(dueDateString, @"^\d{4}-\d{2}-\d{2}$"))
                    {
                        MyMethod.DisplayInvalidInputMessage("Invalid due date format. Please enter a date in the format YYYY-MM-DD.");
                        continue;
                    }

                    if (!DateTime.TryParse(dueDateString, out dueDate))
                    {
                        MyMethod.DisplayInvalidInputMessage("Invalid due date. Please enter a valid date.");
                        continue;
                    }

                    if (dueDate < DateTime.Today)
                    {
                        MyMethod.DisplayInvalidInputMessage("Due date cannot be in the past. Please enter a valid date.");
                        continue;
                    }

                    break;
                }

                Priority priority;
                while (true)
                {
                    Console.Write("Enter the task priority (low, medium, high): ");
                    string priorityString = Console.ReadLine();

                    if (!Regex.IsMatch(priorityString, @"^(low|medium|high)$", RegexOptions.IgnoreCase))
                    {
                        MyMethod.DisplayInvalidInputMessage("Invalid priority. Please enter 'low', 'medium', or 'high'.");
                        continue;
                    }

                    if (!Enum.TryParse(priorityString, true, out priority))
                    {
                        MyMethod.DisplayInvalidInputMessage("Invalid priority. Please enter 'low', 'medium', or 'high'.");
                        continue;
                    }
                    break;
                }
                //Task newTask = new Task(Guid.NewGuid(), title, description, dueDate, priority, false);
                //tasks.Add(newTask);
                Task newTask = new Task
                {
                    UserId = userId,
                    Title = title,
                    Description = description,
                    DueDate = dueDate,
                    Priority = priority
                };
                tasks.Add(newTask);
                MyMethod.PrintTable(tasks);
                MyMethod.DisplaySuccessInputMessage("Task added successfully.");
                break;
            }
            while (true)
            {
                Console.Write("Do you want to add another task? (Y/N)");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    AddTask(tasks, userId);
                    break;
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
        public void EditTask(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("You have no tasks to edit.");
                return;
            }
            Console.WriteLine("Please enter the title of the task you want to edit:");
            string title = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(title) || !tasks.Any(task => task.Title == title))
            {
                Console.WriteLine("Invalid task title. Please enter a valid task title:");
                title = Console.ReadLine();
            }

            Task taskToEdit = tasks.Find(task => task.Title == title);

            if (taskToEdit == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Please select the field you want to edit:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Due Date");
            Console.WriteLine("4. Priority");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the new title:");
                    string newTitle = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(newTitle))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid title:");
                        newTitle = Console.ReadLine();
                    }
                    MyMethod.PrintTable(tasks);
                    taskToEdit.Title = newTitle;
                    ViewAllTasks(tasks);
                    MyMethod.DisplaySuccessInputMessage("Task title updated successfully.");
                    break;

                case "2":
                    Console.WriteLine("Enter the new description:");
                    string newDescription = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(newDescription))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid description:");
                        newDescription = Console.ReadLine();
                    }
                    MyMethod.PrintTable(tasks);
                    taskToEdit.Description = newDescription;
                    ViewAllTasks(tasks);
                    MyMethod.DisplaySuccessInputMessage("Task description updated successfully.");
                    break;

                case "3":
                    while (true)
                    {
                        Console.Write("Enter the task due date (YYYY-MM-DD): ");
                        string dueDateString = Console.ReadLine();

                        if (!Regex.IsMatch(dueDateString, @"^\d{4}-\d{2}-\d{2}$"))
                        {
                            MyMethod.DisplayInvalidInputMessage("Invalid due date format. Please enter a date in the format YYYY-MM-DD.");
                            continue;
                        }

                        DateTime dueDate;
                        if (!DateTime.TryParse(dueDateString, out dueDate))
                        {
                            MyMethod.DisplayInvalidInputMessage("Invalid due date. Please enter a valid date.");
                            continue;
                        }

                        if (dueDate < DateTime.Today)
                        {
                            MyMethod.DisplayInvalidInputMessage("Due date cannot be in the past. Please enter a valid date.");
                            continue;
                        }
                        taskToEdit.DueDate = dueDate;
                        ViewAllTasks(tasks);
                        MyMethod.DisplaySuccessInputMessage("Task due date updated successfully.");
                        break;
                    }
                    break;

                case "4":
                    while (true)
                    {
                        Console.Write("Enter the task priority (low, medium, high): ");
                        string priorityString = Console.ReadLine();
                        Priority priority;

                        if (!Regex.IsMatch(priorityString, @"^(low|medium|high)$", RegexOptions.IgnoreCase))
                        {
                            MyMethod.DisplayInvalidInputMessage("Invalid priority. Please enter 'low', 'medium', or 'high'.");
                            continue;
                        }

                        if (!Enum.TryParse(priorityString, true, out priority))
                        {
                            MyMethod.DisplayInvalidInputMessage("Invalid priority. Please enter 'low', 'medium', or 'high'.");
                            continue;
                        }
                        taskToEdit.Priority = priority;
                        ViewAllTasks(tasks);
                        Console.WriteLine("Task priority updated successfully.");
                        break;
                    }
                    break;

                default:
                    MyMethod.DisplayInvalidInputMessage("Invalid option. Please try again.");
                    break;
            }
            while (true)
            {
                Console.Write("Do you want to edit another task? (Y/N): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {
                    EditTask(tasks);
                    break;
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                    Console.ResetColor();
                }
            }
        }

        public void ViewAllTasks(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            Console.WriteLine("All Tasks:");

            MyMethod.PrintTable(tasks);
        }
        public void DeleteTask(List<Task> tasks, User currentUser)
        {
            if (tasks.Count == 0)
            {
                MyMethod.DisplayInvalidInputMessage("You have no tasks to delete.");
                Console.WriteLine("Please add a task before attempting to delete.");
                AddTask(tasks, currentUser.Id);
                return;
            }

            while (true)
            {
                Console.WriteLine("Please enter the title of the task you want to delete:");
                string title = Console.ReadLine();
                bool taskFound = false;

                while (!taskFound)
                {
                    Task taskToDelete = tasks.Find(task => task.Title == title);

                    if (taskToDelete == null)
                    {
                        Console.Write("Task not found. Would you like to try again? (Y/N)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() != "y")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Returning to delete task menu...");
                            break;
                        }
                    }
                    else
                    {
                        tasks.Remove(taskToDelete);
                        ViewAllTasks(tasks);
                        MyMethod.DisplaySuccessInputMessage("Task deleted successfully.");

                        Console.Write("Do you want to delete another task? (Y/N)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() != "y")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Returning to delete task menu...");
                            break;
                        }
                    }
                }
            }
        }
        public void CompleteTask(List<Task> tasks)
        {
            while (true)
            {
                Console.Write("Enter the ID of the task you want to mark as complete: ");
                if (!int.TryParse(Console.ReadLine(), out int taskId) || taskId < 1 || taskId > tasks.Count)
                {
                    MyMethod.DisplayInvalidInputMessage("Invalid task ID. Please enter a valid task ID.");
                    continue;
                }
                Task task = tasks[taskId - 1];
                task.IsCompleted = true;
                ViewAllTasks(tasks);
                MyMethod.DisplaySuccessInputMessage("Task marked as complete successfully!");

                Console.Write("Do you want to mark another task as complete? (Y/N): ");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    break;
                }
            }
        }
        public void ViewAllReport(List<Task> tasks)
        {
            MyMethod.PrintTable(tasks);
            foreach (Task task in tasks)
            {
                Console.WriteLine($"Task ID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Due Date: {task.DueDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Status: {(task.IsCompleted ? "Completed" : "Not Completed")}");
                Console.WriteLine();
            }

        }
        //public void AddTask(List<Task> tasks, Guid userId)
        //{
        //    Console.WriteLine("Enter the details of the new task:");

        //    Console.Write("Title: ");
        //    string title = Console.ReadLine();

        //    Console.Write("Description: ");
        //    string description = Console.ReadLine();

        //    Console.Write("Enter the task due date (YYYY-MM-DD): ");
        //    string dueDateString = Console.ReadLine();
        //    DateTime dueDate;
        //    while (!DateTime.TryParse(dueDateString, out dueDate))
        //    {
        //        Console.WriteLine("Invalid date format. Please enter a valid due date (yyyy-MM-dd): ");
        //    }

        //    Console.Write("Priority (Low/Medium/High): ");
        //    string priorityInput = Console.ReadLine();
        //    Priority priority;
        //    while (!Enum.TryParse(priorityInput, out priority))
        //    {
        //        Console.WriteLine("Invalid priority. Please enter a valid priority (Low/Medium/High): ");
        //        priorityInput = Console.ReadLine();
        //    }

        //    Task newTask = new Task
        //    {
        //        UserId = userId,
        //        Title = title,
        //        Description = description,
        //        DueDate = dueDate,
        //        Priority = priority
        //    };

        //    tasks.Add(newTask);

        //    Console.WriteLine("Task added successfully.");
        //}

        //public void EditTask(List<Task> tasks)
        //{
        //    Console.WriteLine("Enter the ID of the task you want to edit:");
        //    string taskIdInput = Console.ReadLine();
        //    if (!Guid.TryParse(taskIdInput, out Guid taskId))
        //    {
        //        Console.WriteLine("Invalid task ID.");
        //        return;
        //    }

        //    Task taskToEdit = tasks.FirstOrDefault(t => t.Id == taskId);
        //    if (taskToEdit == null)
        //    {
        //        Console.WriteLine("Task not found.");
        //        return;
        //    }

        //    Console.WriteLine("Enter the new details for the task:");

        //    Console.Write("Title: ");
        //    string newTitle = Console.ReadLine();
        //    if (!string.IsNullOrEmpty(newTitle))
        //    {
        //        taskToEdit.Title = newTitle;
        //    }

        //    Console.Write("Description: ");
        //    string newDescription = Console.ReadLine();
        //    if (!string.IsNullOrEmpty(newDescription))
        //    {
        //        taskToEdit.Description = newDescription;
        //    }

        //    Console.Write("Due Date (yyyy-MM-dd): ");
        //    string newDueDateInput = Console.ReadLine();
        //    DateTime newDueDate;
        //    if (DateTime.TryParse(newDueDateInput, out newDueDate))
        //    {
        //        taskToEdit.DueDate = newDueDate;
        //    }

        //    Console.Write("Priority (Low/Medium/High): ");
        //    string newPriorityInput = Console.ReadLine();
        //    Priority newPriority;
        //    if (Enum.TryParse(newPriorityInput, out newPriority))
        //    {
        //        taskToEdit.Priority = newPriority;
        //    }

        //    Console.WriteLine("Task updated successfully.");
        //}

        //public void ViewAllTasks(List<Task> tasks)
        //{
        //    Console.WriteLine("All Tasks:");

        //    foreach (var task in tasks)
        //    {
        //        Console.WriteLine($"ID: {task.Id}");
        //        Console.WriteLine($"Title: {task.Title}");
        //        Console.WriteLine($"Description: {task.Description}");
        //        Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
        //        Console.WriteLine($"Priority: {task.Priority}");
        //        Console.WriteLine($"Is Completed: {task.IsCompleted}");
        //        Console.WriteLine();
        //    }
        //}

        //public void DeleteTask(List<Task> tasks, User currentUser)
        //{
        //    Console.WriteLine("Enter the ID of the task you want to delete:");
        //    string taskIdInput = Console.ReadLine();
        //    if (!Guid.TryParse(taskIdInput, out Guid taskId))
        //    {
        //        Console.WriteLine("Invalid task ID.");
        //        return;
        //    }

        //    Task taskToDelete = tasks.FirstOrDefault(t => t.Id == taskId);
        //    if (taskToDelete == null)
        //    {
        //        Console.WriteLine("Task not found.");
        //        return;
        //    }

        //    tasks.Remove(taskToDelete);

        //    Console.WriteLine("Task deleted successfully.");
        //}

        //public void CompleteTask(List<Task> tasks)
        //{
        //    Console.WriteLine("Enter the ID of the task you want to mark as complete:");
        //    string taskIdInput = Console.ReadLine();
        //    if (!Guid.TryParse(taskIdInput, out Guid taskId))
        //    {
        //        Console.WriteLine("Invalid task ID.");
        //        return;
        //    }

        //    Task taskToComplete = tasks.FirstOrDefault(t => t.Id == taskId);
        //    if (taskToComplete == null)
        //    {
        //        Console.WriteLine("Task not found.");
        //        return;
        //    }

        //    taskToComplete.IsCompleted = true;

        //    Console.WriteLine("Task marked as complete.");
        //}
    }
}
