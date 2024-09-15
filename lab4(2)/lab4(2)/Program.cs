using System.Text;
using Microsoft.VisualBasic;
namespace Lab4
{
    class Program
    {
        //Вивести прізвища, імена, по батькові і оцінки з фізики студентів, що мають середній бал, більший ніж 4,5 (чотири з половиною).
        static List<Student> ReadData(string fileName)
        {
            List<Student> students = [];
            try
            {
                StreamReader reader = new(fileName);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    students.Add(new(line));
                }
            }
            catch (IOException e) { Console.WriteLine($"Error: {e.Message}"); }
            return students;
        }

        public static double Average(Student student)
        {
            double sum = 0;
            foreach (var c in student.Marks)
            {
                sum += (c == '-') ? 2 : double.Parse(c.ToString());
            }
            return Math.Round(sum / 3, 1);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            List<Student> students = ReadData("./input.txt");
            foreach (var student in students)
            {
                double avg = Average(student);
                if (avg > 4.5)
                {
                    Console.WriteLine($"Студент: {student.surName} {student.firstName} {student.patronymic}, Оцінка з фізики: {student.Marks[1]}");
                }
            }
        }
    }
}

