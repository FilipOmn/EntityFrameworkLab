using EntityFrameworkLabb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkLabb
{
    class Program
    {
        static void Main(string[] args)
        {
            using ApplicationContext context = new ApplicationContext();
            
            List<Employe> employeeLoggedIn = new List<Employe>();
            string reason = "";
            DateTime startTime;
            DateTime endTime;
            double daysOffWork = 0;
            DateTime applicationTime;

            DateTime adminDate;

            //Employe Filip = new Employe()
            //{
            //    Name = "Filip"
            //};
            //context.Add(Filip);

            //Employe Linus = new Employe()
            //{
            //    Name = "Linus"
            //};
            //context.Add(Linus);
            //Employe Amanda = new Employe()
            //{
            //    Name = "Amanda"
            //};
            //context.Add(Amanda);

            //context.SaveChanges();

            Main();

            void Main()
            {
                Console.Clear();
                Console.WriteLine("Log in as \n------------- \n1: Employe \n2: Administrator \n");
                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    if(UserInput == 1)
                    {
                        ChooseEmploye();
                    }
                    if(UserInput == 2)
                    {
                        AdministratorMenu();
                    }
                    if(UserInput < 1 || UserInput > 2)
                    {
                        Console.WriteLine("Invalid option, press any key to return to main");
                        Console.ReadKey();
                        Main();
                    }
                }
                catch
                {
                    Console.WriteLine("Input must be a number of the choices above, press any key to return to main");
                    Console.ReadKey();
                    Main();
                }
            }

            void ChooseEmploye()
            {
                Console.Clear();
                employeeLoggedIn.Clear();

                var i = 0;
                var employees = context.Employees;

                Console.WriteLine("Choose Employee \n----------------------------------");

                Console.WriteLine("Loading employees, please wait..");
                Console.SetCursorPosition(0, 2);

                if (employees.Any())
                {
                    ClearCurrentConsoleLine();
                    foreach (var item in employees)
                    {
                        i++;
                        Console.WriteLine($"{i}: {item.Name}");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("No employees found, press any key to return to main menu");
                    Console.ReadKey();
                    Main();
                }

                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    var employeQuery = from e 
                                       in context.Employees 
                                       where e.EmployeId == UserInput 
                                       select e;

                    if (employeQuery.Any())
                    {
                        foreach (Employe item in employeQuery)
                        {
                            employeeLoggedIn.Add(item);
                            Console.WriteLine($"you will be logging in as employe: {item.Name}, press 1 to continue and press 0 to return to main");
                        }
                        int UserInput_2 = Convert.ToInt32(Console.ReadLine());
                        if (UserInput_2 == 0)
                        {
                            Main();
                        }
                        if (UserInput_2 == 1)
                        {
                            EmployeMenu();
                        }
                        if (UserInput_2 != 0 && UserInput_2 != 1)
                        {
                            Console.WriteLine("invalid option, press any key to return to previous menu");
                            Console.ReadKey();
                            ChooseEmploye();
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid option, press any key to return to previous menu");
                        Console.ReadKey();
                        ChooseEmploye();
                    }
                }
                catch
                {
                    Console.WriteLine("Input must be a number of the choices above, press any key to return to previous menu");
                    Console.ReadKey();
                    ChooseEmploye();
                }
            }

            void EmployeMenu()
            {
                Console.Clear();

                Console.Write("Choose action \n------------ \n1: Fill leave application \n2: View leave history \n3: Return to main menu \n\n");
                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    if(UserInput == 1)
                    {
                        LeaveApplication();
                    }
                    if(UserInput == 2)
                    {
                        ViewLeaveHistory();
                    }
                    if(UserInput == 3)
                    {
                        Main();
                    }
                    if(UserInput != 1 && UserInput != 2 && UserInput != 3)
                    {
                        Console.WriteLine("invalid option, press any key to return to previous menu");
                        Console.ReadKey();
                        EmployeMenu();
                    }
                }
                catch
                {
                    Console.WriteLine("Input must be a number of the choices above, press any key to return to previous menu");
                    Console.ReadKey();
                    EmployeMenu();
                }
            }

            void LeaveApplication()
            {
                Console.Clear();

                Console.WriteLine("Reason for leave \n----------------- \n1: Holiday \n2: Child leave \n3: Sick \n4. Other \n");
                try
                {
                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\n");
                    if (UserInput == 1)
                    {
                        reason = "Holiday";
                    }
                    if (UserInput == 2)
                    {
                        reason = "Child leave";
                    }
                    if (UserInput == 3)
                    {
                        reason = "Sick";
                    }
                    if (UserInput == 4)
                    {
                        reason = "Other";
                    }
                    if (UserInput != 1 && UserInput != 2 && UserInput != 3 && UserInput != 4)
                    {
                        Console.WriteLine("invalid option, press any key to return to previous menu");
                        Console.ReadKey();
                        LeaveApplication();
                    }

                    Console.WriteLine("From Date: in format(year month day)\n------------------------------------ \n");
                    string UserInput_2 = Console.ReadLine();
                    string[] FromDate = UserInput_2.Split(' ');
                    startTime = new DateTime(Convert.ToInt32(FromDate[0]), Convert.ToInt32(FromDate[1]), Convert.ToInt32(FromDate[2]));
                    Console.WriteLine("\n");

                    Console.WriteLine("To Date: in format(year month day)\n------------------------------------ \n");
                    string UserInput_3 = Console.ReadLine();
                    string[] EndDate = UserInput_3.Split(' ');
                    endTime = new DateTime(Convert.ToInt32(EndDate[0]), Convert.ToInt32(EndDate[1]), Convert.ToInt32(EndDate[2]));

                    applicationTime = DateTime.Now;
                    daysOffWork = GetWorkDays(startTime, endTime);
                    Console.WriteLine("\n");
                }
                catch
                {
                    Console.WriteLine("Incorrect format, press any button to return to previous menu");
                    Console.ReadKey();
                    LeaveApplication();
                }

                try
                {
                    Console.WriteLine($"Application overview \n------------------- \nEmploye: {employeeLoggedIn[0].Name} \nReason for leave: {reason} \nStart date: {startTime.ToString("yyyy/MM/dd")} \nEnd date: {endTime.ToString("yyyy/MM/dd")} \nDays away: {daysOffWork} \n");
                    Console.WriteLine("if you want to submit this application press 1, if you want to abondon this application and return to main menu press 0");

                    int UserInput = Convert.ToInt32(Console.ReadLine());
                    if(UserInput == 1)
                    {
                        SubmitApplication();
                        Console.WriteLine("Application sumbitted!");
                        Console.WriteLine("\nPress any key to return to main menu");
                        Console.ReadKey();
                        Main();
                    }
                    if (UserInput == 0)
                    {
                        Main();
                    }
                    if (UserInput != 1 && UserInput != 0)
                    {
                        Console.WriteLine("invalid option, press any key to return to previous menu");
                        Console.ReadKey();
                        LeaveApplication();
                    }
                }
                catch
                {
                    Console.WriteLine("Input must be a number of the choices above, press any key to return to previous menu");
                    Console.ReadKey();
                    LeaveApplication();
                }
            }

            void ViewLeaveHistory()
            {
                Console.Clear();

                var employeViewHistory = from e
                                         in context.Applications
                                         where e.Employe == employeeLoggedIn[0]
                                         select e;

                Console.WriteLine("Your leave history \n-------------------- \n");

                var i = 0;
                foreach (var item in employeViewHistory)
                {
                    i++;
                    Console.WriteLine($"{i}: \nReason: {item.Reason} \nStartDate: {item.StartDate.ToString("yyyy/MM/dd")} \nEndDate: {item.EndDate.ToString("yyyy/MM/dd")} \nDays off work: {GetWorkDays(item.StartDate, item.EndDate)} \n");
                }
                Console.WriteLine("Press any key to return to previous menu");
                Console.ReadKey();
                EmployeMenu();
            }

            void SubmitApplication()
            {
                LeaveApplication leaveApplication = new LeaveApplication()
                {
                    Reason = reason,
                    StartDate = startTime,
                    EndDate = endTime,
                    ApplicationDate = applicationTime,
                    Employe = employeeLoggedIn[0]
                };
                context.Add(leaveApplication);
                context.SaveChanges();
            }

            void AdministratorMenu()
            {
                Console.Clear();

                Console.WriteLine("Enter year and month to view leave applications from in format(year month) \n----------------------------------------------------------------------------- \n");
                try
                {
                    string UserInput = Console.ReadLine();
                    string[] Date = UserInput.Split(' ');
                    adminDate = new DateTime(Convert.ToInt32(Date[0]), Convert.ToInt32(Date[1]), 1);

                    Console.WriteLine("Loading applications, please wait.. ");
                    Console.SetCursorPosition(0, 4);

                    var employes = context.Employees;
                    foreach(var item in employes)
                    {
                        
                    }

                    var employeLeaveApplications = from e
                                                   in context.Applications
                                                   where e.StartDate.Year == adminDate.Year && e.StartDate.Month == adminDate.Month
                                                   select e;

                    var i = 0;

                    if (employeLeaveApplications.Any())
                    {
                        ClearCurrentConsoleLine();
                        Console.WriteLine("\n");
                        foreach (var item in employeLeaveApplications)
                        {
                            i++;
                            Console.WriteLine($"{i}: \nEmploye: {item.Employe.Name} \nReason for leave: {item.Reason} \nDate: {item.StartDate.ToString("yyyy/MM/dd")} - {item.EndDate.ToString("yyyy/MM/dd")} \nDays off work: {GetWorkDays(item.StartDate, item.EndDate)} \nApplication submitted: {item.ApplicationDate} \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No applications found \n");
                    }

                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    Main();
                }
                catch
                {
                    Console.WriteLine("Incorrect format, press any key to return to previous menu");
                    Console.ReadKey();
                    AdministratorMenu();
                }
            }

            void ClearCurrentConsoleLine()
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }

            double GetWorkDays(DateTime startDate, DateTime endDate)
            {
                double workDays = 1 + ((endDate - startDate).TotalDays * 5 - (startDate.DayOfWeek - endDate.DayOfWeek) * 2) / 7;

                if (endDate.DayOfWeek == DayOfWeek.Saturday) workDays--;
                if (startDate.DayOfWeek == DayOfWeek.Sunday) workDays--;

                return workDays;
            }

            Console.ReadKey();
        }
    }
}
