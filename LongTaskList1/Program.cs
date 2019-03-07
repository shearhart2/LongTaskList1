using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Just successfully saved, and opened file with completed tasks grayed out. Need to verify that the
/// re-enter and the save methods work, make lists 25 items each, complete options menu and make it present after each action taken by user.
/// 
/// </summary>

namespace LongTaskList1
{

    class Program
    {
        static void Main(string[] args)
        {

            ShowTaskList();
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> Page1 = new List<string>();
            //Add first task





            Save(Page1);
        }

        private static void Save(List<string> pageNumber)
        {
            File.WriteAllLines("LongTaskList1.txt", pageNumber);
            Console.WriteLine("Your list has been saved");
        }

        private static void AddTask(string userInput, List<string> pageNumber)
        {
            pageNumber.Add(userInput);
            Console.Clear();
            Console.WriteLine($"{userInput} has been added to your Task List");

        }

        private static void ShowTaskList()
        {
            Console.Clear();
            string[] currentTaskList = File.ReadAllLines("LongTaskList1.txt");//opens saved file
            foreach (string item in currentTaskList)
            {
                if (item.Contains($"-*-"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{Array.IndexOf(currentTaskList, item)}. {item}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{Array.IndexOf(currentTaskList, item)}. {item}");
                }

            }

        }

        

        private static void TaskAction(List<string> pageNumber)
        {
            


            while (true)
            {
                string choice = SelectTask(pageNumber);
                int selection = pageNumber.IndexOf(choice);
                Console.WriteLine($"What would you like to do with {choice}?" +
                              $"\n\t1. Mark as Complete" +
                              $"\n\t2. Re-Enter" +
                              $"\n\t3. Return to Task List");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    //Mark As Complete Method Here
                    GrayOut(pageNumber, selection);
                    break;
                    
                }
                else if (userInput == "2")
                {
                    //Re-Enter Method Here
                    ReEnter(pageNumber, selection);
                }
                else if (userInput == "3")
                {
                    ShowTaskList();
                }
                else
                {
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                    Console.ReadLine();
                }
            }
            //Console.WriteLine("It worked");// this is for testing and needs to be removed and fixed to where it either returns something or is void
        }



        private static string SelectTask(List<string> pageNumber)
        {
            while (true)
            {

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
        

        private static void GrayOut(List<string> pageNumber, int selection)
        {
            pageNumber.Insert(selection, ($"{pageNumber.ElementAt(selection)}-*-"));
            pageNumber.RemoveAt(selection + 1);

            foreach (string item in pageNumber)  
            {
                
                if (pageNumber.IndexOf(item) == selection)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{pageNumber.IndexOf(item)}. {item}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{pageNumber.IndexOf(item)}. {item}");
                }

            }
            File.WriteAllLines("LongTaskList1.txt", pageNumber);
        }


        private static void ReEnter(List<string> pageNumber, int selection)
        {
            //pageNumber.Insert(selection, ($"{pageNumber.ElementAt(selection)}-*-"));
            //pageNumber.RemoveAt(selection + 1);

            foreach (string item in pageNumber)
            {
                pageNumber.Insert(selection, ($"{pageNumber.ElementAt(selection)}-*-"));
                pageNumber.Add(pageNumber.ElementAt(selection+1));
                pageNumber.RemoveAt(selection + 1);
                if (pageNumber.IndexOf(item) == selection)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{pageNumber.IndexOf(item)}. {item}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{pageNumber.IndexOf(item)}. {item}");
                }

            }
            File.WriteAllLines("LongTaskList1.txt", pageNumber);
        }
        //private static string DeleteTask(string item)
        //{
        //    string deletedItem = $"-{item}-";
        //    return deletedItem;
        //}

    }
}

//int elementNumber = int.Parse(Console.ReadLine());
//return pageNumber.ElementAt(elementNumber);