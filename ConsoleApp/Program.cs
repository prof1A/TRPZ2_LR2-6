using System;
using System.Linq;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using BLL.Util;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            var scope = _serviceProvider.CreateScope();

            int selectedCommand = 1;
            while (true)
            {
                if (selectedCommand == 1)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("All employees hierarchy");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("All employees hierarchy");
                }

                if (selectedCommand == 2)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Search employee");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Search employee");
                }

                if (selectedCommand == 3)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Create employee");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Create employee");
                }




                var key = Console.ReadKey();
                Console.Clear();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selectedCommand < 3)
                    {
                        selectedCommand++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selectedCommand > 1)
                    {
                        selectedCommand--;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (selectedCommand == 1)
                    {
                        while (true)
                        {
                            if (selectedCommand == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Tree view");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Tree view");
                            }

                            if (selectedCommand == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Position view");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Position view");
                            }
                            var k = Console.ReadKey();
                            if (k.Key == ConsoleKey.DownArrow)
                            {
                                if (selectedCommand < 2)
                                {
                                    selectedCommand++;
                                }
                            }
                            if (k.Key == ConsoleKey.UpArrow)
                            {
                                if (selectedCommand > 1)
                                {
                                    selectedCommand--;
                                }
                            }
                            if (k.Key == ConsoleKey.Enter)
                            {
                                if (selectedCommand == 1)
                                {
                                    Console.Clear();
                                    var empString = _serviceProvider.GetService<IComposite>().GetAllInTreeView();
                                    Console.WriteLine(empString);
                                    //var employees = _serviceProvider.GetService<IEmployeeService>().GetAll().ToList().OrderBy(x => x.PositionWeight);
                                    //Console.WriteLine("CEO: " + employees.First().LastName + " " + employees.First().FirstName);
                                    //foreach (var manager in employees.Where(x => x.PositionWeight == 2))
                                    //{
                                    //    Console.WriteLine($"---{manager.PositionName}: {manager.LastName} {manager.FirstName}");
                                    //    foreach (var slave in manager.Subjects)
                                    //    {
                                    //        Console.WriteLine($"---------{slave.PositionName}: {slave.LastName} {slave.FirstName}");
                                    //    }

                                    //}
                                    Console.ReadKey();
                                }

                                if (selectedCommand == 2)
                                {
                                    Console.Clear();
                                    var employees = _serviceProvider.GetService<IEmployeeService>().GetAll().ToList().OrderBy(x => x.PositionWeight);
                                    foreach (var emp in employees)
                                    {
                                        if (emp.PositionWeight == 1)
                                        {
                                            Console.WriteLine($"{emp.PositionName}: {emp.LastName} {emp.FirstName}");
                                        }

                                        if (emp.PositionWeight == 2)
                                        {
                                            Console.WriteLine($"---{emp.PositionName}: {emp.LastName} {emp.FirstName}");
                                        }

                                        if (emp.PositionWeight == 3)
                                        {
                                            Console.WriteLine($"---------{emp.PositionName}: {emp.LastName} {emp.FirstName}");
                                        }
                                    }

                                    Console.ReadKey();
                                }

                                break;
                            }
                            Console.Clear();
                        }
                    }
                    else if (selectedCommand == 2)
                    {
                        selectedCommand = 1;
                        while (true)
                        {
                            Console.Clear();
                            if (selectedCommand == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("By name");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("By name");
                            }

                            if (selectedCommand == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("By salary");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("By salary");
                            }

                            if (selectedCommand == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("By position");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("By position");
                            }

                            var k = Console.ReadKey();
                            if (k.Key == ConsoleKey.DownArrow)
                            {
                                if (selectedCommand < 3)
                                {
                                    selectedCommand++;
                                }
                            }
                            if (k.Key == ConsoleKey.UpArrow)
                            {
                                if (selectedCommand > 1)
                                {
                                    selectedCommand--;
                                }
                            }

                            if (k.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                if (selectedCommand == 1)
                                {
                                    Console.WriteLine("Enter employee's surname: ");
                                    var sname = Console.ReadLine();
                                    var employees = _serviceProvider.GetService<IEmployeeService>().GetAll().ToList()
                                        .Where(x => x.LastName.Contains(sname));

                                    foreach (var emp in employees)
                                    {
                                        Console.WriteLine($"{emp.PositionName}: {emp.LastName} {emp.FirstName}");
                                    }


                                }
                                if (selectedCommand == 2)
                                {
                                    Console.WriteLine("Enter employee's minimal salary: ");
                                    var sname = Convert.ToInt32(Console.ReadLine());
                                    var employees = _serviceProvider.GetService<IEmployeeService>().GetAll().ToList()
                                        .Where(x => x.Salary > sname);

                                    foreach (var emp in employees)
                                    {
                                        Console.WriteLine($"{emp.PositionName}: {emp.LastName} {emp.FirstName} {emp.Salary}");
                                    }
                                }
                                if (selectedCommand == 3)
                                {
                                    Console.WriteLine("Enter employee's position: ");
                                    var sname = Console.ReadLine();
                                    var employees = _serviceProvider.GetService<IEmployeeService>().GetAll().ToList()
                                        .Where(x => x.PositionName == sname);

                                    foreach (var emp in employees)
                                    {
                                        Console.WriteLine($"{emp.PositionName}: {emp.LastName} {emp.FirstName} {emp.Salary}");
                                    }
                                }

                                Console.ReadKey();
                                break;
                            }
                        }

                    }
                    else if (selectedCommand == 3)
                    {
                        var empTypeSelect = 1;
                        while (true)
                        {
                            Console.Clear();
                            if (empTypeSelect == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Delivery Manager");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Delivery Manager");
                            }
                            if (empTypeSelect == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Sales Manager");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Sales Manager");
                            }
                            if (empTypeSelect == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Developer");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Developer");
                            }
                            if (empTypeSelect == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                //Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("Marketer");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Marketer");
                            }

                            

                            var k = Console.ReadKey();
                            if (k.Key == ConsoleKey.DownArrow)
                            {
                                if (empTypeSelect < 4)
                                {
                                    empTypeSelect++;
                                }
                            }
                            if (k.Key == ConsoleKey.UpArrow)
                            {
                                if (empTypeSelect > 1)
                                {
                                    empTypeSelect--;
                                }
                            }

                            if (k.Key == ConsoleKey.Enter)
                            {
                                Console.WriteLine("Enter employee's firstname");
                                var fname = Console.ReadLine();
                                Console.WriteLine("Enter employee's lastname");
                                var lname = Console.ReadLine();
                                EmployeeDTO emp = new EmployeeDTO();
                                if (empTypeSelect == 1)
                                {
                                    emp = new DeliveryManager();
                                    emp.LastName = lname;
                                    emp.FirstName = fname;
                                    emp.Master = _serviceProvider.GetService<IEmployeeService>().GetAll()
                                        .First(x => x.PositionName == "CEO");
                                    Random rnd = new Random();
                                    emp.Salary = rnd.Next(1000, 3000);
                                    _serviceProvider.GetService<IEmployeeService>().Create(emp);
                                    break;
                                }

                                if (empTypeSelect == 2)
                                {
                                    emp = new SalesManager();
                                    emp.LastName = lname;
                                    emp.FirstName = fname;
                                    emp.Master = _serviceProvider.GetService<IEmployeeService>().GetAll()
                                        .First(x => x.PositionName == "CEO");
                                    Random rnd = new Random();
                                    emp.Salary = rnd.Next(1000, 3000);
                                    _serviceProvider.GetService<IEmployeeService>().Create(emp);
                                    break;
                                }
                                if (empTypeSelect == 3)
                                {
                                    emp = new Developer();
                                    emp.LastName = lname;
                                    emp.FirstName = fname;
                                    var managerSelect = 1;
                                    while (true)
                                    {
                                        Console.Clear();
                                        var dels = _serviceProvider.GetService<IEmployeeService>().GetAll()
                                            .Where(x => x.PositionName == "Delivery Manager");
                                        for (int i = 0; i < dels.Count(); i++)
                                        {
                                            if (managerSelect == i + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                //Console.BackgroundColor = ConsoleColor.White;
                                                var a = dels.ToList()[i];
                                                Console.WriteLine($"{a.PositionName} {a.LastName} {a.FirstName}");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                var a = dels.ToList()[i];
                                                Console.WriteLine($"{a.PositionName} {a.LastName} {a.FirstName}");
                                            }
                                        }

                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.DownArrow)
                                        {
                                            if (managerSelect < dels.Count())
                                            {
                                                managerSelect++;
                                            }
                                        }
                                        if (kk.Key == ConsoleKey.UpArrow)
                                        {
                                            if (managerSelect > 1)
                                            {
                                                managerSelect--;
                                            }
                                        }

                                        if (kk.Key == ConsoleKey.Enter)
                                        {
                                            emp.Master = dels.ToList()[managerSelect - 1];
                                            Random rnd = new Random();
                                            emp.Salary = rnd.Next(1000, 3000);
                                            _serviceProvider.GetService<IEmployeeService>().Create(emp);
                                            break;
                                        }
                                    }
                                    break;
                                }
                                if (empTypeSelect == 4)
                                {
                                    emp = new Marketer();
                                    emp.LastName = lname;
                                    emp.FirstName = fname;
                                    var managerSelect = 1;
                                    while (true)
                                    {
                                        Console.Clear();
                                        var dels = _serviceProvider.GetService<IEmployeeService>().GetAll()
                                            .Where(x => x.PositionName == "Sales Manager");
                                        for (int i = 0; i < dels.Count(); i++)
                                        {
                                            if (managerSelect == i + 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                //Console.BackgroundColor = ConsoleColor.White;
                                                var a = dels.ToList()[i];
                                                Console.WriteLine($"{a.PositionName} {a.LastName} {a.FirstName}");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                var a = dels.ToList()[i];
                                                Console.WriteLine($"{a.PositionName} {a.LastName} {a.FirstName}");
                                            }
                                        }

                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.DownArrow)
                                        {
                                            if (managerSelect < dels.Count())
                                            {
                                                managerSelect++;
                                            }
                                        }
                                        if (kk.Key == ConsoleKey.UpArrow)
                                        {
                                            if (managerSelect > 1)
                                            {
                                                managerSelect--;
                                            }
                                        }

                                        if (kk.Key == ConsoleKey.Enter)
                                        {
                                            emp.Master = dels.ToList()[managerSelect - 1];
                                            Random rnd = new Random();
                                            emp.Salary = rnd.Next(1000, 3000);
                                            _serviceProvider.GetService<IEmployeeService>().Create(emp);
                                            break;
                                        }

                                    }
  
                                    break;
                                }
                            }
                        }
                    }
                }

            }
        }

        static void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationContext>();
            services.AddTransient<IGenericRepository<Employee>, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IVisitor, Visitor>();
            services.AddTransient<IComposite, Composite>();
            services.AddTransient<DbInitializer>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}

    
