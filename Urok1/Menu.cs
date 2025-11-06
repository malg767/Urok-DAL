using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urok1.DAL;
using Urok1;

namespace Urok1_menu
{
    internal class Menu
    {
        public Menu() { }

        public void Menu_Add(StRepository rep)
        {
            Console.Clear();
            string name = EnterName();
            int age = EnterAge();
            string adres = EnterAdres();
            string gmail = EnterGmail();
            int year = EnterYear();

            Student newStudent = new Student
            {
                Name = name,
                Age = age,
                Adres = adres,
                Gmail = gmail,
                Year = year
            };

            rep.Add(newStudent);
            Console.WriteLine("Студент успешно добавлен!");
            Readk();
        }


        public void Menu_Remove(StRepository rep)
        {
            Console.Clear();
            int choice = EnterParameterChoice();
            if (choice == 0)
                return;

            List<Student> std = DeleteStudent_swich(choice, rep);

            if (std.Count == 0)
            {
                Console.WriteLine("Студенты с таким параметром не найдены.");
                Readk();
            }
            else
            {
                rep.RemoveRange(std);
                Console.WriteLine("Студенты успешно удалены!");
                Readk();
            }            
        }
        public List<Student> DeleteStudent_swich(int choice, StRepository rep)
        {
            List<Student> studentsToDelete = new List<Student>();

            switch (choice)
            {
                case 1:
                    string name = EnterName();
                    studentsToDelete = rep.GetAll().Where(s => s.Name == name).ToList();
                    return studentsToDelete;

                case 2:
                    int age = EnterAge();
                    studentsToDelete = rep.GetAll().Where(s => s.Age == age).ToList();
                    return studentsToDelete;

                case 3:
                    string adres = EnterAdres();
                    studentsToDelete = rep.GetAll().Where(s => s.Adres == adres).ToList();
                    return studentsToDelete;

                case 4:
                    string gmail = EnterGmail();
                    studentsToDelete = rep.GetAll().Where(s => s.Gmail == gmail).ToList();
                    return studentsToDelete;

                case 5:
                    int year = EnterYear();
                    studentsToDelete = rep.GetAll().Where(s => s.Year == year).ToList();
                    return studentsToDelete;

                default:
                    Console.WriteLine("Ошибка! Введите 0 - 5.");
                    return studentsToDelete;
            }
        }


        public void Menu_ShowAllStudents(StRepository rep)
        {
            Console.Clear();
            Console.WriteLine("Список студентов:");
            foreach (var s in rep.GetAll())
            {
                PrintStudent(s);
            }
            Readk();
        }

       
        public void Menu_UpdateStudent(StRepository rep)
        {
            Console.Clear();
            var std = rep.GetById(EnterId());

            if (std == null)
            {
                Console.WriteLine("Студента с таким id нету");
                Readk();
            }
            else
            {
                int choice = EnterParameterChoice();
                UpdateStudent_swich(std, choice, rep);
                Readk();
            }            
        }
        public void UpdateStudent_swich(Student std, int choice, StRepository rep)
        {
            Console.Clear();
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    std.Name = EnterName();
                    rep.Update(std);
                    Console.WriteLine("Имя студента обновлено");
                    break;
                case 2:
                    std.Age = EnterAge();
                    rep.Update(std);
                    Console.WriteLine("Возраст студента обновлен");
                    break;
                case 3:
                    std.Adres = EnterAdres();
                    rep.Update(std);
                    Console.WriteLine("Страна проживания студента обновлена");
                    break;
                case 4:
                    std.Gmail = EnterGmail();
                    rep.Update(std);
                    Console.WriteLine("Gmail студента обновлен");
                    break;
                case 5:
                    std.Year = EnterYear();
                    rep.Update(std);
                    Console.WriteLine("Год обучения студента обновлен");
                    break;
                default:
                    Console.WriteLine("Ошибка! Введите 0 - 5!!!");
                    break;
            }
        }



        public int EnterId()
        {
            while (true)
            {
                Console.Write("Введите Id: ");
                string inp = Console.ReadLine();

                if (int.TryParse(inp, out int res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите число.");
                }
            }
        }

        public string EnterName()
        {
            while (true)
            {
                Console.Write("Введите имя: ");
                string inp = Console.ReadLine()?.Trim(); 

                if (!string.IsNullOrEmpty(inp))
                    return inp;

                Console.WriteLine("Ошибка! Имя не может быть пустым.");
            }
        }

        public int EnterAge()
        {
            while (true)
            {
                Console.Write("Введите возраст: ");
                string inp = Console.ReadLine();

                if (int.TryParse(inp, out int res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректный возраст (число).");
                }
            }
        }

        public string EnterAdres()
        {
            while (true)
            {
                Console.Write("Введите страну проживания: ");
                string inp = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(inp))
                    return inp;

                Console.WriteLine("Ошибка! Страна проживания не может быть пустой.");
            }
        }

        public string EnterGmail()
        {
            while (true)
            {
                Console.Write("Введите Gmail: ");
                string inp = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(inp))
                    return inp;

                Console.WriteLine("Ошибка! Gmail не может быть пустым.");
            }
        }

        public int EnterYear()
        {
            while (true)
            {
                Console.Write("Введите год обучения: ");
                string inp = Console.ReadLine();

                if (int.TryParse(inp, out int res))
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }
        }

        public int EnterParameterChoice()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите параметр:");
                Console.WriteLine("1 - имя");
                Console.WriteLine("2 - возраст");
                Console.WriteLine("3 - страна проживания");
                Console.WriteLine("4 - Gmail");
                Console.WriteLine("5 - год обучения");
                Console.WriteLine("0 - ничего не делать");
                Console.Write("Введите: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 5)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число от 0 до 5.\n");
                }
            }
        }

        public void PrintStudent(Student s)
        {
            Console.Write($"Id: {s.Id}, ");
            Console.Write($"Имя: {s.Name}, ");
            Console.Write($"Возраст: {s.Age}, ");
            Console.Write($"Адрес: {s.Adres}, ");
            Console.Write($"Gmail: {s.Gmail}, ");
            Console.WriteLine($"Год обучения: {s.Year};");
        }

        public void Readk()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

    }
}
