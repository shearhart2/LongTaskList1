using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///  //Console.ForegroundColor = ConsoleColor.DarkGray;
//Console.WriteLine("this should be dark gray");
//Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine("this should be dark red");
/// </summary>
namespace LongTaskList1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Intro to task list
            Console.WriteLine("Long Task List");
            //Create List
            List<string> Page1 = new List<string>();
            //Add first task
            Console.WriteLine("Please enter a new task to begin your list.");
            AddTask(Console.ReadLine(), Page1);
            Console.WriteLine("Please enter a new task");
            AddTask(Console.ReadLine(), Page1);
            Console.WriteLine("Please enter a new task.");
            AddTask(Console.ReadLine(), Page1);
            Console.WriteLine("Please enter a new task.");
            AddTask(Console.ReadLine(), Page1);
            ShowTaskList(Page1);
            SelectTask(Page1);
            ShowTaskList(Page1);
            
            
            
        }

        private static void AddTask(string userInput, List<string> pageNumber)
        {
            pageNumber.Add(userInput);
            Console.Clear();
            Console.WriteLine($"{userInput} has been added to your Task List");
            
        }

        private static void ShowTaskList(List<string> pageNumber)
        {
            Console.Clear();
            foreach (string userInput in pageNumber)
            {
                Console.WriteLine($"{pageNumber.IndexOf(userInput)}. {userInput}");
            }
            
        }

        private static void DeleteTask(List<string> pageNumber)
        {
            ///Working on color change. This method will currently delete an item and then replace it in the same index.
            ///You were attempting to change the color between these two steps, but it doesn't quite work.
            ///Items with the comments are there for testing purposes only
            ///Try making color change in a method and calling it on a string
            ///***this deletion and replacement can be used for moving the re-entered tasks as well***
            ShowTaskList(pageNumber);
            Console.WriteLine("Please enter the number for the item you would like to delete. ");
            int elementNumber = int.Parse(Console.ReadLine());
            string placeHolder = pageNumber.ElementAt(elementNumber);
            pageNumber.RemoveAt(elementNumber);
            ShowTaskList(pageNumber);//
            Console.ReadLine();
            pageNumber.Insert(elementNumber, placeHolder);
            ShowTaskList(pageNumber);//


        }

        private static string TaskAction(List<string> pageNumber)
        {
            while (true)
            {
                Console.WriteLine($"What would you like to do with {SelectTask(pageNumber)}?" +
                              $"\n\t1. Mark as Complete" +
                              $"\n\t2. Re-Enter" +
                              $"\n\t3. Return to Task List");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    //Mark As Complete Method Here
                    return "Complete";
                }
                else if (userInput == "2")
                {
                    //Re-Enter Method Here
                    return "Re-enter";
                }
                else if (userInput == "3")
                {
                    ShowTaskList(pageNumber);
                }
                else
                {
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                    Console.ReadLine();
                }
            }
        }

        private static string SelectTask(List<string> pageNumber)
        {
            while (true)
            {
                ShowTaskList(pageNumber);//Make this entire method an option in the Show task method
                Console.WriteLine("Please enter the number for the item you would like to select. ");
                try
                {
                    int elementNumber = int.Parse(Console.ReadLine());
                    return pageNumber.ElementAt(elementNumber);

                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                }
                catch (ArgumentNullException)

                {
                    Console.Clear();
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                }
                catch (Exception)

                {
                    Console.Clear();
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                }
                Console.ReadLine();
            }
        }
        ///Items with the comments are there for testing purposes only
        private static void ReEnterTask(List<string> pageNumber)
        {
            
            ShowTaskList(pageNumber);
            Console.WriteLine("Please enter the number for the item you would like to delete. ");
            int elementNumber = int.Parse(Console.ReadLine());
            string placeHolder = pageNumber.ElementAt(elementNumber);
            pageNumber.RemoveAt(elementNumber);
            ShowTaskList(pageNumber);//
            Console.ReadLine();
            pageNumber.Insert(elementNumber, placeHolder);//this should replace the grayed out version back where it was **after we figure out the gray**
            pageNumber.Add(placeHolder);//this should re-enter the non-grayed out version to the end of the list **after we figure out the gray**
            ShowTaskList(pageNumber);//
        }

        /// <summary>
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// </summary>
        /// <param Page1="pageNumber"></param>
        private static void OptionsMenu(List<string> pageNumber)
        {
            Console.WriteLine("OPTIONS MENU:" +
                "\n\n\t1. Select Task" +
                  "\n\t2. Add Task" +
                  "\n\t3. Delete Task");
            //Not sure if Next Page belongs here of if it should be its own place on each list

            while (true)
            {
                
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    SelectTask(pageNumber);
                }
                else if (userInput == "2")
                { 
                    //AddTask 
                }
                else if (userInput == "3")
                {
                    //Delete Task
                }
                else
                {
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}

