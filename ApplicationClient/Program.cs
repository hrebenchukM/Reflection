using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace Array
{
    class Program
    {
        static Assembly studentAsml;// Сборка с типами студентов
        static Assembly groupAsml;// Сборка group
        static Type studentType;// Тип студента
        static Type groupType;// Тип группы
        static object groupInstance; // Экземпляр группы

        static void Main(string[] args)
        {
            try
            {
                // Загрузка сборок
                groupAsml = Assembly.LoadFrom("./Academy_Group.dll");
                studentAsml = Assembly.LoadFrom("DLL/Student.dll");


                if (!File.Exists("./Academy_Group.dll"))
                {
                    Console.WriteLine("Сборка Academy_Group.dll не найдена.");
                }
                else
                {
                    Console.WriteLine("Сборка Academy_Group.dll  EST.");
                }



                if (!File.Exists("DLL/Student.dll"))
                {
                    Console.WriteLine("Сборка Student.dll не найдена.");
                }
                else
                {
                    Console.WriteLine("Сборка Student.dll  EST.");
                }



                // Выводим типы из сборки группы
                Console.WriteLine("Объявленные типы данных:");
                foreach (Type t in groupAsml.GetTypes())
                {
                    Console.WriteLine(t.FullName);
                }

                // Получаем типы группы и студента
                groupType = groupAsml.GetType("SampleLibrary.Academy_Group");
                studentType = studentAsml.GetType("Reverse.Student");


                if (groupType == null)
                {
                    Console.WriteLine("Класс Academy_Group не найден.");
                }
                else
                {
                    Console.WriteLine("Класс Academy_Group  EST!!!.");

                }

                if (studentType == null)
                {
                    Console.WriteLine("Класс Student нe найден в сборке Student.dll.");
                }
                else
                {
                    Console.WriteLine("Класс Student  EST!!!.");

                }

            

                foreach (Type t in studentAsml.GetTypes())
                {
                    Console.WriteLine(t.FullName);  // Выводим полное имя типа
                }



                // Создаем экземпляр группы
                groupInstance = Activator.CreateInstance(groupType);
               
              


                while (true)
                {
                    Console.WriteLine("1.Добавить студента");
                    Console.WriteLine("2.Удалить студента");
                    Console.WriteLine("3.Редактировать студента");
                    Console.WriteLine("4. Поиск студента");
                    Console.WriteLine("5.Распечатать группу");
                    Console.WriteLine("6.Записать в файл");
                    Console.WriteLine("7. Прочитать из файла");
                    Console.WriteLine("8. Отсортировать студентов по среднему балу/номеру группы");
                    Console.WriteLine("9. Перебор коллекции студентов с помощью foreach");
                    Console.WriteLine("0.Выход");
                    Console.Write("Выберите пунктик: ");

                    string words = Console.ReadLine();

                    switch (words)
                    {
                        case "1"://1.Добавить студента
                            Console.Write("Введите имя: ");
                            string nameA = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            string surnameA = Console.ReadLine();
                            Console.Write("Введите возраст: ");
                            int ageA = int.Parse(Console.ReadLine());
                            Console.Write("Введите телефон: ");
                            string phoneA = Console.ReadLine();
                            Console.Write("Введите средний бал: ");
                            double averageA = double.Parse(Console.ReadLine());
                            Console.Write("введите номер группы: ");
                            string number_of_groupA = Console.ReadLine();
                            try
                            {

                                var studentInstance = Activator.CreateInstance(studentType, nameA, surnameA, ageA, phoneA, averageA, number_of_groupA);
                                groupType.GetMethod("Add").Invoke(groupInstance, new object[] { studentInstance });
                               
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при добавлении студента: {ex.Message}");
                            }
                            break;

                        case "2"://Удалить студента
                            Console.Write("Введите фамилию: ");
                            string surnameR = Console.ReadLine();
                            groupType.GetMethod("Remove").Invoke(groupInstance, new object[] { surnameR });
                            break;

                        case "3"://Редактировать студента

                            Console.Write("Введите фамилию студента которого будем редактировать: ");
                            string surnameE = Console.ReadLine();

                            Console.Write("Введите новое имя: ");
                            string nameE = Console.ReadLine();
                            Console.Write("Введите новую фамилию: ");
                            string surnameE2 = Console.ReadLine();
                            Console.Write("Введите новый возраст: ");
                            int ageE = int.Parse(Console.ReadLine());
                            Console.Write("Введите новый телефон: ");
                            string phoneE = Console.ReadLine();
                            Console.Write("Введите новый средний бал: ");
                            double averageE = double.Parse(Console.ReadLine());
                            Console.Write("введите новый номер группы: ");
                            string number_of_groupE = Console.ReadLine();


                            var newStudent = Activator.CreateInstance(studentType, nameE, surnameE, ageE, phoneE, averageE, number_of_groupE);
                            groupType.GetMethod("Edit").Invoke(groupInstance, new object[] { surnameE, newStudent });
                            break;

                        case "4"://Поиск студента
                            Console.Write("Введите фамилию: ");
                            string surnameS = Console.ReadLine();
                            groupType.GetMethod("Search").Invoke(groupInstance, new object[] { surnameS });
                            break;

                        case "5"://Распечатать группу
                            groupType.GetMethod("Print").Invoke(groupInstance, null);
                            break;


                        case "6"://Записать в файл
                            string solutionDir1 = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../.."));
                            string savePath = Path.Combine(solutionDir1, "SampleLibrary", "Data", "group.txt");

                            Console.WriteLine("Путь к файлу: " + savePath);



                            groupType.GetMethod("Save").Invoke(groupInstance, new object[] { savePath });
                            Console.WriteLine("сохранено.");

                            break;

                        case "7"://Прочитать из файла
                            string solutionDir2 = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../.."));
                            string loadPath = Path.Combine(solutionDir2, "SampleLibrary", "Data", "group.txt");

                            Console.WriteLine("Путь к файлу: " + loadPath);




                            groupType.GetMethod("Load").Invoke(groupInstance, new object[] { loadPath });
                            Console.WriteLine("Загружено:");
                            break;


                        case "8"://Отсортировать студентов по среднему балу/номеру группы
                            Console.Write("Выберите пунктик критерия: ");
                            Console.Write("\n1.Отсортировать студентов по среднему балу:");
                            Console.Write("\n2.Отсортировать студентов по названию группы:\n");
                            string choice = Console.ReadLine();
                            object comparerInstance = null;
                            if (choice == "1")
                            {
                             
                                comparerInstance = Activator.CreateInstance(studentAsml.GetType("Reverse.Student+SortByAverage"));

                            }
                            if (choice == "2")
                            {
                                comparerInstance = Activator.CreateInstance(studentAsml.GetType("Reverse.Student+SortByNumber_of_group"));
                               
                            }
                            groupType.GetMethod("Sort").Invoke(groupInstance, new object[] { comparerInstance });
                            Console.WriteLine("Сортировка завершена.");
                            break;

                        case "9": // перебор коллекции (объекта класса Academy_Group) с помощью оператора цикла foreach.
                            Console.WriteLine("Список студентов:");
                            foreach (var temp in (IEnumerable)groupInstance)
                            {
                                studentType.GetMethod("Print").Invoke(temp, null);
                            }
                            break;



                        case "0"://Выход
                            return;

                        default:
                            Console.WriteLine("Ошибочка");
                            break;
                    }


                 

                    //    // Загружаем сборку
                    //    Assembly asml = Assembly.LoadFrom("./SampleLibrary.dll");

                    //// Выводим список типов данных, объявленный в текущем модуле
                    //Console.WriteLine("Объявленные типы данных:");
                    //foreach (Type t in asml.GetTypes())
                    //{
                    //    Console.WriteLine(t.FullName);
                    //}

                    //// Получаем тип данных из сборки
                    //Type type = asml.GetType("SampleLibrary.Academy_Group");

                    //// Позднее связывание позволяет создавать экземпляры некоторого типа, 
                    //// а также использовать его во время выполнения приложения.

                    //// Использование позднего связывания менее безопасно, т.к. при жестком кодировании 
                    //// всех типов (ранее связывание) на этапе компиляции можно отследить многие ошибки. 
                    //// В то же время позднее связывание позволяет создавать расширяемые приложения, 
                    //// когда дополнительная функциональность программы неизвестна, и может быть разработана
                    //// и подключена сторонними разработчиками.

                    //// Ключевую роль в позднем связывании играет класс System.Activator. 
                    //// С помощью его статического метода Activator.CreateInstance() 
                    //// можно создавать экземпляры заданного типа

                    ////SampleLibrary.Employee emp = new("Иван", "Иванов", 30, "Директор", 50000M);
                    ////emp.Print();
                    //// Создадим объект класса Employee
                    //object group = Activator.CreateInstance(type, ["Иван", "Иванов", 30, "+380972860462", 9, "222"]);
                    //Console.WriteLine();
                    //// Вызываем метод Print от созданного объекта
                    //type.GetMethod("Print").Invoke(group, null); // person.Print();

                    //string[] files = Directory.GetFiles(".", "DLL/*.dll");
                    //Assembly[] asm = new Assembly[files.Length];
                    //for (int i = 0; i < files.Length; i++)
                    //{
                    //    asm[i] = Assembly.LoadFrom(files[i]);
                    //}
                    //List<Type> types = new List<Type>();
                    //for (int i = 0; i < asm.Length; i++)
                    //{
                    //    types.AddRange(asm[i].GetTypes());
                    //}
                    //List<MethodInfo> methodinfo = new List<MethodInfo>();
                    //foreach (Type t in types)
                    //    methodinfo.AddRange(t.GetMethods());
                    //Console.WriteLine("Methods:\n\n");
                    //foreach (MethodInfo info in methodinfo)
                    //    Console.WriteLine(info.Name);

                    //int[] A = new int[10];
                    //methodinfo[0].Invoke(null, [A]); // public static void Init(int[] A)
                    //Console.WriteLine("\nИсходный массив:\n");
                    //methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
                    //methodinfo[6].Invoke(null, [A]); //  public static void Reverse(int[] A)
                    //Console.WriteLine("Массив после реверсирования:\n");
                    //methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
                    //methodinfo[7].Invoke(null, [A]); // public static void Neighbor(int[] A)
                    //Console.WriteLine("Массив после преобразования:\n");
                    //methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("По окончании try-блока.");
            }

        }

    }
}
