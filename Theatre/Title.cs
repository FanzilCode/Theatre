using System;

namespace Theatre
{
    class Title
    {
        public string name { get; private set; } // название

        // конструктор с одним параметром
        public Title(string name)
        {
            this.name = name;
        }
        // конструктор без параметров
        public Title()
        {
            Console.Write("Звание: ");
            name = Console.ReadLine();
        }
        // переопределение метода ToString()
        public override string ToString()
        {
            return name;
        }
    }
}
