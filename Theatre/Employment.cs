using System;

namespace Theatre
{
    class Employment
    {
        public Actor actor { get; private set; }
        public Performance performance { get; private set; }
        string role; // роль
        double pay; // стоимость годового контракта
        double reward; // премия

        // конструктор с 5-. параметрами
        public Employment(Actor actor, Performance performance, string role, double pay, double reward)
        {
            this.actor = actor;
            this.performance = performance;
            this.role = role;
            this.pay = pay;
            this.reward = reward;
        }
        // переопределение метода ToString() для записи в файл
        public override string ToString()
        {
            return $"{actor}\n" +
                $"{performance}\n" +
                $"{role}%{pay}%{reward}";
        }
        // метод Print() для выведения информации о занятости на экран
        public void Print()
        {
            Console.WriteLine($"Полное имя: {actor.fullname}\n" +
                $"Название спектакля: {performance.Title}\n" +
                $"Роль: {role}\n" +
                $"Стоимость годового контракта: {pay} руб." +
                $"Премия: {reward}" +
                $"Итого: {pay + reward} руб.");
        }
        public static bool operator == (Employment e1, Employment e2)
        {
            return (e1.actor == e2.actor && e1.performance == e2.performance && e1.role == e2.role);
        }
        public static bool operator !=(Employment e1, Employment e2)
        {
            return (e1 == e2);
        }
        public override int GetHashCode()
        {
            return (actor.GetHashCode() + performance.GetHashCode() + role.GetHashCode());
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                Employment p1 = (Employment)obj;
                return this == p1;
            }
            else
                return false;
        }
        public bool IsAvailable(Actor actor)
        {
            return this.actor == actor;
        }
        public bool IsAvailable(Performance performance)
        {
            return this.performance == performance;
        }
        public bool IsAvailable(int year)
        {
            return performance.Year == year;
        }
        public static bool operator >(Employment e1, Employment e2)
        {
            return e1.performance > e2.performance;
        }
        public static bool operator <(Employment e1, Employment e2)
        {
            return !(e1 > e2);
        }
    }
}
