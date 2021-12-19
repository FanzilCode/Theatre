using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Theatre
{
    class Program
    {
        static List<Actor> actors = new List<Actor>();
        static List<Performance> performances = new List<Performance>();
        static List<Title> titles = new List<Title>();
        static List<Employment> employments = new List<Employment>();

        // метод PrintActors() - печать на экран списка актёров
        static void PrintActors()
        {
            foreach (var actor in actors)
            {
                Console.WriteLine("Индекс: " + actors.IndexOf(actor));
                actor.Print();
            }
        }
        // метод PrintActors(Performance performance) - печать на экран всех актёров в спектакле
        static void PrintActors(Performance performance)
        {
            foreach (var emp in employments)
            {
                if (emp.IsAvailable(performance))
                {
                    emp.actor.Print();
                }
            }
        }
        // метод PrintPerformances() - печать на экран списка спектаклей
        static void PrintPerformances()
        {
            foreach (var performance in performances)
            {
                Console.WriteLine("Индекс: " + performances.IndexOf(performance));
                performance.Print();
            }
        }
        // метод PrintTitles() - печать на экран списка званий
        static void PrintTitles()
        {
            foreach (var title in titles)
            {
                Console.WriteLine("Индекс: " + titles.IndexOf(title) + $"\nЗвание: {title.name}\n");
            }
        }
        // метод PrintEmployments() - печать на экран списка отчётов о занятостях
        static void PrintEmployments()
        {
            foreach (var emp in employments)
            {
                emp.Print();
            }
        }
        // метод PrintEmployments(Actor actor) - печать на экран всех контрактов актёра
        static void PrintEmployments(Actor actor)
        {
            foreach (var emp in employments)
            {
                if (emp.IsAvailable(actor))
                {
                    emp.Print();
                }
            }
        }
        // метод AddEmployment() - добавление отчёта о занятости актёра
        static void AddEmployment()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tДобавить новый отчёт о занятости актёра\n");
            Console.WriteLine("Хотите выбрать актёра из списка или добавить нового?\n" +
                "Выберите:\n" +
                "1) Выбрать из списка\t2) Добавить нового");
            int choise = Convert.ToInt32(Console.ReadLine());
            Actor actor;

            if (choise == 1)
            {
                PrintActors();
                Console.Write("Введите индекс актёра: ");
                actor = actors[Convert.ToInt32(Console.ReadLine())];
            }
            else
            {
                actor = new Actor();
                if (!actors.Contains(actor))
                    actors.Add(actor);
            }

            Console.WriteLine("Хотите выбрать спектакль из списка или добавить новый?\n" +
                "Выберите:\n" +
                "1) Выбрать из списка\t2) Добавить новый");
            choise = Convert.ToInt32(Console.ReadLine());
            Performance performance;

            if (choise == 1)
            {
                PrintActors();
                Console.Write("Введите индекс спектакля: ");
                performance = performances[Convert.ToInt32(Console.ReadLine())];
            }
            else
            {
                performance = new Performance();
                if (!performances.Contains(performance))
                    performances.Add(performance);
            }

            Console.Write("Роль: ");
            string role = Console.ReadLine();

            Console.Write("Стоимость годового контракта(в руб.): ");
            double pay = Convert.ToDouble(Console.ReadLine());

            Console.Write("Премия(в руб.): ");
            double reward = Convert.ToDouble(Console.ReadLine());

            Employment emp = new Employment(actor, performance, role, pay, reward);

            if (!employments.Contains(emp))
                employments.Add(emp);
            else
                Console.WriteLine("Данный отчёт уже в списке.");
        }
        // метод SaveToFile(string path) - сохранение в файл
        static void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string strings = "";
                foreach (var emp in employments)
                {
                    strings += emp + "\n";
                }
                strings.Trim();
                sw.Write(strings);
            }
        }
        // метод ReadOnFile(string path) - чтение из файла
        static void ReadOnFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Actor actor = new Actor(line.Trim().Split("%"));
                    if (!actors.Contains(actor))
                        actors.Add(actor);

                    Performance performance = new Performance(sr.ReadLine().Trim().Split("%"));
                    if (!performances.Contains(performance))
                        performances.Add(performance);

                    string[] arr = sr.ReadLine().Split("%");
                    string role = arr[0];
                    double pay = Convert.ToDouble(arr[1]);
                    double reward = Convert.ToDouble(arr[2]);

                    employments.Add(new Employment(actor, performance, role, pay, reward));
                }
            }
        }

        static void Main(string[] args)
        {
            string path = @"Employments.txt";
            ReadOnFile(path);
            int choise = 1;
            while (choise >= 1 && choise <= 4)
            {
                Console.WriteLine("\t\t\tГлавная\nВыберите:");
                Console.WriteLine("1) Актёры\n" +
                    "2) Спектакли\n" +
                    "3) Звания\n" +
                    "4) Занятости актёров\n" +
                    "5) Выход");
                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine("\t\t\tАктёры\nВыберите:\n" +
                                "1) Получить список всех актёров\n2) Получить список всех актёров по выбранному спектаклю\n" +
                                "3) Добавить актёра\n4) На главную");
                            int choise2 = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            switch (choise2)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\t\t\tПолучить список всех актёров");
                                        PrintActors();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("\t\t\tПолучить список всех актёров по выбранному спектаклю");
                                        PrintPerformances();
                                        Console.Write("Выберите спектакль(введите индекс): ");
                                        PrintActors(performances[Convert.ToInt32(Console.ReadLine())]);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("\t\t\tДобавить актёра");
                                        Actor actor = new Actor();
                                        if (!actors.Contains(actor))
                                        {
                                            actors.Add(actor);
                                            Console.WriteLine("Актёр добавлен в список.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Актёр уже в списке.");
                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\t\t\tCпектакли\nВыберите:\n" +
                                "1) Получить список всех спектаклей\n" +
                                "2) Получить список спектаклей по выбранному актёру\n" +
                                "3) Добавить спектакль\n" +
                                "4) На главную");
                            int choise2 = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            switch(choise2)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\t\t\tПолучить список всех спектаклей");
                                        PrintPerformances();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("\t\t\tПолучить список всех спектаклей по выбранному актёру");
                                        PrintActors();
                                        Console.Write("Выберите актёра(введите индекс): ");
                                        PrintEmployments(actors[Convert.ToInt32(Console.ReadLine())]);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("\t\t\tДобавить спектакль");
                                        Performance performance = new Performance();
                                        if(!performances.Contains(performance))
                                        {
                                            performances.Add(performance);
                                            Console.WriteLine("Спектакль добавлен в список.");
                                        }
                                        else
                                            Console.WriteLine("Спектакль уже в списке.");
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\t\t\tЗвания\n");
                            PrintTitles();
                            Console.WriteLine("Вы хотите добавить новое звание?\n" +
                                "Выберите:\n" +
                                "1) Да\t2) Нет");
                            int choise2 = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            if(choise2 == 1)
                            {
                                Title title = new Title();
                                if(!titles.Contains(title))
                                {
                                    titles.Add(title);
                                    Console.WriteLine("Звание добавлено в список.");
                                }
                                else
                                    Console.WriteLine("Звание уже в списке.");
                                PrintTitles();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\t\t\tЗанятости актёров\n");
                            PrintEmployments();
                            Console.WriteLine("Вы хотите добавить новый отчёт о занятости?\n" +
                                "Выберите:\n" +
                                "1) Да\t2) Нет");
                            int choise2 = Convert.ToInt32(Console.ReadLine());
                            if(choise2 == 1)
                            {
                                AddEmployment();
                                PrintEmployments();
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            SaveToFile(path);
        }
    }
}
