using System;

enum Post
{
    Intern = 80,        // Стажёр - 80 часов
    Junior = 160,       // Джуниор - 160 часов
    Middle = 168,       // Мидл - 168 часов
    Senior = 176,       // Сеньор - 176 часов
    TeamLead = 180,     // Тимлид - 180 часов
    Manager = 160,      // Менеджер - 160 часов
    Director = 150      // Директор - 150 часов
}

class Accountant
{
    public bool AskForBonus(Post worker, int hoursWorked)
    {
        int requiredHours = (int)worker;
        return hoursWorked > requiredHours;
    }
}

class Program
{
    static void Main()
    {
        Accountant accountant = new Accountant();

        // Ввод данных
        Console.Write("Введите должность сотрудника (Intern, Junior, Middle, Senior, TeamLead, Manager, Director): ");
        if (!Enum.TryParse(Console.ReadLine(), out Post worker))
        {
            Console.WriteLine("Ошибка: введена некорректная должность.");
            return;
        }

        Console.Write("Введите количество отработанных часов: ");
        if (!int.TryParse(Console.ReadLine(), out int hoursWorked) || hoursWorked < 0)
        {
            Console.WriteLine("Ошибка: количество часов должно быть положительным числом.");
            return;
        }

        // Проверка на премию
        bool bonus = accountant.AskForBonus(worker, hoursWorked);

        Console.WriteLine(bonus ? "Сотруднику положена премия." : "Сотруднику не положена премия.");
    }
}
