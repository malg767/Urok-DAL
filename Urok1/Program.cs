using Urok1.DAL;
using Urok1_menu;

namespace Urok1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            //var student = new Student
            //{
            //    Name = "Maks",
            //    Age = 18,
            //    Adres = "Test 123",
            //    Gmail = "Test@gmail.com",
            //    Year = 3
            //};

            var rep = new StRepository();
            
            // rep.Add(student);


            //foreach (var s in rep.GetAll())
            //{
            //    Console.WriteLine($"Id: {s.Id}, Имя: {s.Name}, Возраст: {s.Age}, Адрес: {s.Adres}, Gmail: {s.Gmail}, Год обучения: {s.Year}");
            //};

            //var st = rep.GetById(2);
            //Console.WriteLine($"Id: {st.Id}, Имя: {st.Name}, Возраст: {st.Age}, Адрес: {st.Adres}, Gmail: {st.Gmail}, Год обучения: {st.Year}");

            //st.Name = "Alex";
            //Console.WriteLine($"Id: {st.Id}, Имя: {st.Name}, Возраст: {st.Age}, Адрес: {st.Adres}, Gmail: {st.Gmail}, Год обучения: {st.Year}");
            //rep.Update(student);

            //var st3 = rep.GetById(3);
            //rep.Remove(st3);




            Menu menu = new Menu();

            while (true)
            {
                int choice;
                while (true)
                {
                    Console.WriteLine("1 - добавить студента.\n2 - вывести всех студентов.\n3 - удалить студента.\n4 - изменить данные студента.\n0 - выход.");
                    Console.Write("Введите: ");
                    string inp = Console.ReadLine();

                    if (int.TryParse(inp, out choice))
                    {
                        if (choice >= 0 && choice <= 4)
                            break;
                        else
                            Console.WriteLine("Ошибка! Введите число от 0 до 4.");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода! Введите число.");
                    }
                }

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                            AddStudent(rep, menu);
                            
                        break;
                    case 2:

                            ShowAllStudents(rep, menu);

                        break;
                    case 3:

                            DeleteStudent(rep, menu);

                        break;
                    case 4:

                            UpdateStudent(rep, menu);

                        break;
                    default:
                        Console.WriteLine("Ошибка! Введите 0, 1, 2, 3 или 4.");
                        break;
                }
            }

        }

        static void AddStudent(StRepository rep, Menu menu)
        {
            Console.Clear();
            menu.Menu_Add(rep);
        }
        static void ShowAllStudents(StRepository rep, Menu menu)
        {
            Console.Clear();
            menu.Menu_ShowAllStudents(rep);
        } 

        static void DeleteStudent(StRepository rep, Menu menu)
        {
            Console.Clear();
            menu.Menu_Remove(rep);
        }
        

        static void UpdateStudent(StRepository rep, Menu menu)
        {
            Console.Clear();
            menu.Menu_UpdateStudent(rep);
        }
        static void grsgfs(StRepository rep, Menu menu)
        {
            Console.Clear();
            menu.Menu_UpdateStudent(rep);
        }

    }
}







//Student student = new Student
//{
//    Name = "Oleg",
//    Age = 18,
//    Adres = "Ukraine",
//    Gmail = "oleg@gmail.com",
//    Year = 2
//};

//using (var db = new AppDbContext())
//{
//    db.Students.Add(student);
//    db.SaveChanges();

//    var students = db.Students.ToList();
//    foreach (var s in students)
//    {
//        Console.WriteLine($"Id: {s.Id}, Имя: {s.Name}, Возраст: {s.Age}, Адрес: {s.Adres}, Gmail: {s.Gmail}, Год обучения: {s.Year}");
//        Console.WriteLine("-------------------------");
//    }

//    //delete

//    var std = db.Students.FirstOrDefault(s => s.Id == 3011);
//    if (std != null)
//    {
//        db.Students.Remove(std);
//        db.SaveChanges();
//    }

//    Console.WriteLine("-----------------------------------------");
//    var students_2 = db.Students.ToList();
//    foreach (var s in students_2)
//    {
//        Console.WriteLine($"Id: {s.Id}, Имя: {s.Name}, Возраст: {s.Age}, Адрес: {s.Adres}, Gmail: {s.Gmail}, Год обучения: {s.Year}");
//        Console.WriteLine("-------------------------");
//    }

//    //update

//    var std_1 = db.Students.FirstOrDefault(s => s.Id == 3012);
//    if (std_1 != null)
//    {
//        std_1.Name = std_1.Name + "1";
//        db.Students.Update(std_1);
//        db.SaveChanges();
//    }

//    var students_3 = db.Students.ToList();
//    foreach (var s in students_3)
//    {
//        Console.WriteLine($"Id: {s.Id}, Имя: {s.Name}, Возраст: {s.Age}, Адрес: {s.Adres}, Gmail: {s.Gmail}, Год обучения: {s.Year}");
//        Console.WriteLine("-------------------------");
//    }
//}