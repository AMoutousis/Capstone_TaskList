using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Capstone_TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new list of object Task
            List<Task> TaskList = new List<Task>();
            TaskList.Add(new Task("Andoni", "Write some code", DateTime.Parse("9/13/2020"), false));
            TaskList.Add(new Task("Ramez", "Plant a tree", DateTime.Parse("10/31/2020"), false));
            TaskList.Add(new Task("Emily", "Read a book", DateTime.Parse("09/29/2020"), false));
            TaskList.Add(new Task("Rose", "Plant flowers", DateTime.Parse("08/15/2020"), false));


            //declare variables
            #region declare variables
            bool runAgain = true;
            #endregion

            Console.WriteLine("Welcome to the Task Manager!");
            Console.WriteLine("Let us track your tasks so you can get to work on 'em!");

            while (runAgain == true) 
            {
                /*
                 * 1. list tasks
                 * 2. add task
                 * 3. delete task
                 * 4. mark task complete
                 * 5. quit
                 * 
                 */


                runAgain = PrintMenu(TaskList);


                if (runAgain == false)
                {
                    runAgain = false;
                }
                else
                {
                    runAgain = true;
                }
            }

        }

        public static bool PrintMenu(List<Task> TaskList)
        {

            int input;
            bool runAgain = true;
            Console.WriteLine("");
            Console.WriteLine("\t1. List Tasks");
            Console.WriteLine("\t2. Add Task");
            Console.WriteLine("\t3. Delete Task");
            Console.WriteLine("\t4. Mark task complete");
            Console.WriteLine("\t5. Quit");

            Console.WriteLine("What would you like to do?");
            try
            {
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine($"Please enter a number between 1 and 5");
                }
                if (input >= 1 && input <= 5)
                {
                    if (input == 1)
                    {
                        PrintTask(TaskList);
                    }
                    if (input == 2)
                    {
                        AddTask(TaskList);
                    }
                    if (input == 3)
                    {
                        RemoveTask(TaskList);
                    }
                    if (input == 4)
                    {
                        CompleteTask(TaskList);
                    }
                    if (input == 5)
                    {
                        runAgain = RunProgramAgain();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 5");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid selection");
            }

            return runAgain;
        }
        public static bool RunProgramAgain()
        {
            bool validateAgain = true;
            bool repeatProgram = true;

            while (validateAgain)
            {
                Console.WriteLine("\nPress y to confirm and return to the main menu or n to quit.");
                string playAgain = Console.ReadLine();

                if (playAgain.ToLower() == "y")
                {
                    validateAgain = false;
                    repeatProgram = true;
                    Console.Clear();

                }
                else if (playAgain.ToLower() == "n")
                {
                    validateAgain = false;
                    repeatProgram = false;
                }
                else
                {
                    validateAgain = true;
                }
            }

            return repeatProgram;

        }

        public static void PrintTask(List<Task> TaskList)
        {
            if (TaskList.Count == 0)
            {
                Console.WriteLine("You do not have any open tasks");
            }
            else
            {
                foreach (Task task in TaskList)
                {
                    task.FormatedPrintTask();
                }
            }
        
        }
        public static List<Task> AddTask(List<Task> TaskList)
        {
            Task NewTask = new Task();

            Console.WriteLine("Please enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter a description of the task");
            string desc = Console.ReadLine();
            Console.WriteLine("Please enter the due date");
            DateTime due = DateTime.Parse(Console.ReadLine());
            bool complete = false;

            TaskList.Add(new Task(name, desc, due, complete));

            return TaskList;
        }
        public static List<Task> RemoveTask(List<Task> TaskList)
        {
            Task RemoveTask = new Task();
            int count = 1;
            int taskCount = 1;
            int deleteSelection;

            Console.WriteLine("What task would you like to remove?");

            foreach (Task task in TaskList)
            {
                Console.Write($"{count}.");
                task.PrintTask();
                count++;
                taskCount = count;
            }

            try
            {
                while (!int.TryParse(Console.ReadLine(), out deleteSelection))
                {
                    Console.WriteLine($"Please enter a number between 1 and {taskCount}");
                }

                if (deleteSelection >= 1 && deleteSelection <= 5)
                {

                    Console.WriteLine($"Are you sure you would like to delete task number {deleteSelection}?");
                    string complete = ValidateDecision(Console.ReadLine().ToLower());

                    if (complete == "y")
                    {
                        TaskList.RemoveAt(deleteSelection - 1);
                        Console.Clear();
                        PrintMenu(TaskList);
                    }
                    else if (complete == "n")
                    {
                        Console.WriteLine("No changes have been made.");
                        Console.Clear();
                        PrintMenu(TaskList);
                    }
                }
                else
                {
                    Console.WriteLine($"Please enter a number between 1 and {taskCount}");
                    deleteSelection = int.Parse(Console.ReadLine());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Please enter a number within 1 and {taskCount}");
            }


            return TaskList;
        }

        public static void CompleteTask(List<Task> TaskList)
        {
            int count = 1;
            int taskCount = 1;
            int changeSelection;

            Console.WriteLine("What task would you like to mark as complete?");

            foreach (Task task in TaskList)
            {
                Console.Write($"{count}.");
                task.PrintTask();
                count++;
                taskCount = count;
            }

            try
            {
                while (!int.TryParse(Console.ReadLine(), out changeSelection))
                {
                    Console.WriteLine($"Please enter a number between 1 and {taskCount}");
                }

                Console.WriteLine($"Are you sure you would like to mark the task number {taskCount} as complete?");
                string complete = ValidateDecision(Console.ReadLine().ToLower());

                if (complete == "y")
                {
                    TaskList[changeSelection - 1].Complete = true;
                    Console.Clear();
                    PrintMenu(TaskList);
                }
                else if(complete == "n")
                {
                    Console.Clear();
                    PrintMenu(TaskList);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please enter a number within range");
            }

        }
        public static string ValidateDecision(string input)
        {
            bool invalidInput = true;

            while (invalidInput)
            {
                if (input.ToLower() == "y")
                {
                    input = "y";
                    invalidInput = false;
                }
                else if (input.ToLower() == "n")
                {
                    input = "n";
                    invalidInput = false;
                }
                else
                {
                    Console.WriteLine("Please enter y for yes or n for no");
                    input = Console.ReadLine();
                }
            }

            return input;

        }

    }
}
