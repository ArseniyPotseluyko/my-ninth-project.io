using System;

enum EmployeePosition
{
    Intern = 80,        // Стажёр - 80 часов
    Junior = 160,       // Джуниор - 160 часов
    Middle = 168,       // Мидл - 168 часов
    Senior = 176,       // Сеньор - 176 часов
    TeamLead = 180,     // Тимлид - 180 часов
    Manager = 160,      // Менеджер - 160 часов
    Director = 150      // Директор - 150 часов
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Должности и рабочие часы в месяц:");

        // Вывод всех значений перечисления
        foreach (EmployeePosition position in Enum.GetValues(typeof(EmployeePosition)))
        {
            Console.WriteLine($"{position}: {Convert.ToInt32(position)} часов");
        }
    }
}
