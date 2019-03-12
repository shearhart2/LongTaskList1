using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
///
/// </summary>

namespace LongTaskList1
{

    class Program
    {
        static void Main(string[] args)
        {

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> Page1 = new List<string>();
            Console.WriteLine("Task List");
            ShowTaskList(Page1);
            OptionsMenu(Page1);
            

        }

        private static void Save(List<string> pageNumber)
        {
            File.WriteAllLines("LongTaskList1.txt", pageNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your list has been saved");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static void AddTask(List<string> pageNumber)
        {
            Console.WriteLine("Enter a task");
            string userInput = Console.ReadLine();
            pageNumber.Add(userInput);
            Console.Clear();
            Console.WriteLine($"{userInput} has been added to your Task List");
            Save(pageNumber);
        }

        private static void ShowTaskList(List<string> pageNumber)
        {
            Console.Clear();
            string[] currentTaskList = File.ReadAllLines("LongTaskList1.txt");
            foreach (string item in currentTaskList)
            {
                if(!pageNumber.Contains(item))
                {
                    pageNumber.Add(item);
                }
                
                if(pageNumber.IndexOf(item)<25)
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
            Save(pageNumber);
            PageSelect(pageNumber);
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
                              $"\n\t3. Return to Options Menu");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    GrayOut(pageNumber, selection);
                    break;
                    
                }
                else if (userInput == "2")
                {
                    ReEnter(pageNumber, selection);
                    break;
                }
                else if (userInput == "3")
                {
                    OptionsMenu(pageNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Your entry was not valid. Please press enter and try again.");
                    Console.ReadLine();
                }
            }
            Save(pageNumber);
        }



        private static string SelectTask(List<string> pageNumber)
        {
            while (true)
            {

                Console.WriteLine("Please enter the number for the item you would like to select, or press enter to return to the options menu. ");
                try
                {
                    int elementNumber = int.Parse(Console.ReadLine());
                    return pageNumber.ElementAt(elementNumber);

                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    OptionsMenu(pageNumber);
                }
                catch (OverflowException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    OptionsMenu(pageNumber);
                }
                catch (ArgumentNullException)

                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    OptionsMenu(pageNumber);
                }
                catch (Exception)

                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    OptionsMenu(pageNumber);
                }
                Console.ReadLine();
            }
        }

        
        
        
        private static void OptionsMenu(List<string> pageNumber)
        {

            while (true)
            {
                
                Console.WriteLine("\nOPTIONS MENU:" +
                "\n\n\t1. Select Task" +
                  "\n\t2. Add Task" +
                  "\n\t3. Delete Task" +
                  "\n\t4. Go to Task List" +
                  "\n\t5. Exit Program");
                string userInput = Console.ReadLine();
                try
                {
                    if (userInput == "1")
                    {
                        TaskAction(pageNumber);
                    }
                    else if (userInput == "2")
                    {
                        AddTask(pageNumber);
                    }
                    else if (userInput == "3")
                    {
                        Console.WriteLine("Please enter the number for the item you would like to delete, or press enter to reurn to the options menu.");
                        int selection = int.Parse(Console.ReadLine());
                        GrayOut(pageNumber, selection);
                    }



                    else if (userInput == "4")
                    {
                        ShowTaskList(pageNumber);
                    }
                    else if (userInput == "5")
                    {
                        break;
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour entry was not valid, please try again");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                }
            }
            
        }

        private static void PageSelect(List<string> pageNumber)
        {

            while (true)
            {

                Console.WriteLine("\nTASK LIST MENU:" +
                
                  "\n\t1. Go to Page 2 of Task List" +
                  "\n\t2. Go to Page 3 of Task List" +
                  "\n\t3. Go to Page 4 of Task List" +
                  "\n\t4. Go to Page 1 of Task List" +
                  "\n\t5. Go to Options Menu");
                string userInput = Console.ReadLine();
                try
                {
                    
                    if (userInput == "1")
                    {
                        Console.Clear();
                        foreach (string item in pageNumber)
                        {

                            if (pageNumber.IndexOf(item) >= 25 && pageNumber.IndexOf(item) < 50)
                            {
                                if (item.Contains("-*-"))
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

                        }
                    }
                    else if (userInput == "2")
                    {
                        Console.Clear();
                        foreach (string item in pageNumber)
                        {

                            if (pageNumber.IndexOf(item) >= 50 && pageNumber.IndexOf(item) < 75)
                            {
                                if (item.Contains("-*-"))
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

                        }
                    }
                    else if (userInput == "3")
                    {
                        Console.Clear();
                        foreach (string item in pageNumber)
                        {

                            if (pageNumber.IndexOf(item) >= 75)
                            {
                                if (item.Contains("-*-"))
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

                        }
                    }
                    else if(userInput == "4")
                    {
                        ShowTaskList(pageNumber);
                        break;
                    }
                    else if (userInput == "5")
                    {
                        break;
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour entry was not valid, please try again");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are being re-routed to the options menu.");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
            }

        }

        private static void GrayOut(List<string> pageNumber, int selection)
        {
            pageNumber.Insert(selection, ($"{pageNumber.ElementAt(selection)}-*-"));
            pageNumber.RemoveAt(selection + 1);

            foreach (string item in pageNumber)  
            {

                if (pageNumber.IndexOf(item) < 25)
                {
                    if (item.Contains("-*-"))
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

            }
        }


        private static void ReEnter(List<string> pageNumber, int selection)
        {

            pageNumber.Insert(selection, ($"{pageNumber.ElementAt(selection)}-*-"));
            pageNumber.Add(pageNumber.ElementAt(selection + 1));
            pageNumber.RemoveAt(selection + 1);
            foreach (string item in pageNumber)
            {
                if(pageNumber.IndexOf(item)<25)
                {
                    if (item.Contains("-*-"))
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
               
            }
        }
        

    }
}

