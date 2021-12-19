using System;

namespace Theatre
{
    class Performance
    {
        string title; // название спектакля
        int year; // год постановки
        double sum; // бюджет

        // св-во для поля title
        public string Title
        {
            get
            {
                return title;
            }
        }
        // св-во для поля year
        public int Year
        {
            get
            {
                return year;
            }
        }
        // св-во для поля sum
        public double Sum
        {
            get
            {
                return sum;
            }
        }
        // конструктор с 3-мя параметрами
        public Performance(string title, int year, double sum)
        {
            this.title = title;
            this.year = year;
            this.sum = sum;
        }
        // конструктор для чтения из файла
        public Performance(string[] arr)
        {
            this.title = arr[0];
            this.year = Convert.ToInt32(arr[1]);
            this.sum = Convert.ToDouble(arr[2]);
        }
        // конструктор без параметров
        public Performance()
        {
            Console.Write("Название спектакля: ");
            title = Console.ReadLine();

            Console.Write("Год постановки: ");
            year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Бюджет(в руб.): ");
            sum = Convert.ToDouble(Console.ReadLine());
        }
        // переопределение метода ToString() для записи в файл
        public override string ToString()
        {
            return $"{title}%{year}%{sum}";
        }
        // метод Print() для выведения на экран информации о спектакле
        public void Print()
        {
            Console.WriteLine($"Название спектакля: {title}\n" +
                $"Год постановки: {year}\n" +
                $"Бюджет(в руб.): {sum}\n");
        }

        public static bool operator ==(Performance p1, Performance p2)
        {
            return (p1.title == p2.title && p1.year == p2.year && p1.sum == p2.sum);
        }
        public static bool operator !=(Performance p1, Performance p2)
        {
            return !(p1 == p2);
        }
        public override int GetHashCode()
        {
            return title.GetHashCode() + year.GetHashCode() + sum.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Performance p1 = (Performance)obj;
                return this == p1;
            }
            else
                return false;
        }
        public static bool operator >(Performance p1, Performance p2)
        {
            return p1.year > p2.year;
        }
        public static bool operator <(Performance p1, Performance p2)
        {
            return !(p1 > p2);
        }
    }
}
