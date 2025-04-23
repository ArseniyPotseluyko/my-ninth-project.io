using System;
using System.Linq;

struct STUDENT
{
    public string FullName; // Фамилия и инициалы
    public int GroupNumber; // Номер группы
    public int[] Grades; // Успеваемость (массив из пяти элементов)

    // Метод для вычисления среднего балла
    public double GetAverageGrade()
    {
        return Grades.Average();
    }

    // Проверка, есть ли только 4 и 5 в успеваемости
    public bool HasOnlyHighGrades()
    {
        return Grades.All(grade => grade == 4 || grade == 5);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            const int studentCount = 10;
            STUDENT[] students = new STUDENT[studentCount];

            // Ввод данных с клавиатуры
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"\nВведите данные для студента {i + 1}:");

                Console.Write("Фамилия и инициалы: ");
                students[i].FullName = Console.ReadLine();

                Console.Write("Номер группы: ");
                students[i].GroupNumber = Convert.ToInt32(Console.ReadLine());

                students[i].Grades = new int[5];
                Console.WriteLine("Введите 5 оценок студента:");
                for (int j = 0; j < 5; j++)
                {
                    students[i].Grades[j] = Convert.ToInt32(Console.ReadLine());

                    if (students[i].Grades[j] < 2 || students[i].Grades[j] > 5)
                    {
                        throw new ArgumentOutOfRangeException("Оценки должны быть от 2 до 5.");
                    }
                }
            }

            // Сортировка студентов по среднему баллу
            students = students.OrderBy(student => student.GetAverageGrade()).ToArray();

            Console.WriteLine("\nСписок студентов, отсортированный по среднему баллу:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FullName} (группа {student.GroupNumber}) - Средний балл: {student.GetAverageGrade():F2}");
            }

            // Поиск студентов с оценками только 4 и 5
            var filteredStudents = students.Where(student => student.HasOnlyHighGrades()).ToList();

            Console.WriteLine("\nСтуденты, имеющие только оценки 4 и 5:");
            if (filteredStudents.Count > 0)
            {
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"{student.FullName} (группа {student.GroupNumber})");
                }
            }
            else
            {
                Console.WriteLine("Нет студентов, имеющих только оценки 4 и 5.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода! Убедитесь, что вводите корректные данные.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
        }
    }
}
