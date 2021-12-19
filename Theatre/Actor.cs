using System;

namespace Theatre
{
    class Actor
    {
        // поля
        string lastName; // фамилия
        string firstName; // имя
        string midName; // отчество
        Title title; // звание
        int exp; // стаж

        // св-во для полного имени
        public string fullname
        {
            get
            {
                return lastName + " " + firstName + " " + midName;
            }
        }
        // св-во для поля exp
        public int Exp
        {
            get
            {
                return exp;
            }
        }

        // конструктор с 5-ю параметрами
        public Actor(string lastName, string firstName, string midName, Title title, int exp)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.midName = midName;
            this.title = title;
            this.exp = exp;
        }
        // конструктор для чтения из файла
        public Actor(string[] arr)
        {
            lastName = arr[0];
            firstName = arr[1];
            midName = arr[2];
            title = new Title(arr[3]);
            exp = Convert.ToInt32(arr[4]);
        }
        // конструктор без параметров
        public Actor()
        {
            Console.Write("Фамилия: ");
            lastName = Console.ReadLine();

            Console.Write("Имя: ");
            firstName = Console.ReadLine();

            Console.Write("Отчество: ");
            midName = Console.ReadLine();

            Console.Write("Звание: ");
            title = new Title(Console.ReadLine());

            Console.Write("Стаж(в годах): ");
            exp = Convert.ToInt32(Console.ReadLine());
        }
        // переопределение метода ToString() для записи в файл
        public override string ToString()
        {
            return $"{lastName}%{firstName}%{midName}%{title}%{exp}";
        }
        // метод Print() для печати на экран информации об актёре
        public void Print()
        {
            Console.WriteLine($"{lastName} {firstName} {midName}\n" +
                $"{title}\nСтаж(в годах): {exp}\n");
        }
        public static bool operator == (Actor a1, Actor a2)
        {
            return (a1.lastName == a2.lastName && a1.firstName == a2.firstName && a1.midName == a2.midName && a1.title.name == a2.title.name && a1.exp == a2.exp);
        }
        public static bool operator != (Actor a1, Actor a2)
        {
            return !(a1 == a2);
        }
        public override int GetHashCode()
        {
            return lastName.GetHashCode() + firstName.GetHashCode() + midName.GetHashCode() + title.name.GetHashCode() + exp.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Actor p1 = (Actor)obj;
                return this == p1;
            }
            else
                return false;
        }
    }
}
