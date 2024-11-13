using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // Загружаем сборку
            Assembly asml = Assembly.LoadFrom("./SampleLibrary.dll");
            // Выводим список типов данных, объявленный в текущем модуле
            Console.WriteLine("Объявленные типы данных:");
            foreach (Type t in asml.GetTypes())
            {
                Console.WriteLine(t.FullName);
            }

            // Получаем тип данных из сборки
            Type type = asml.GetType("SampleLibrary.Employee");

            // Позднее связывание позволяет создавать экземпляры некоторого типа, 
            // а также использовать его во время выполнения приложения.

            // Использование позднего связывания менее безопасно, т.к. при жестком кодировании 
            // всех типов (ранее связывание) на этапе компиляции можно отследить многие ошибки. 
            // В то же время позднее связывание позволяет создавать расширяемые приложения, 
            // когда дополнительная функциональность программы неизвестна, и может быть разработана
            // и подключена сторонними разработчиками.

            // Ключевую роль в позднем связывании играет класс System.Activator. 
            // С помощью его статического метода Activator.CreateInstance() 
            // можно создавать экземпляры заданного типа

            //SampleLibrary.Employee emp = new("Иван", "Иванов", 30, "Директор", 50000M);
            //emp.Print();
            // Создадим объект класса Employee
            object person = Activator.CreateInstance(type,
                ["Иван", "Иванов", 30, "Директор", 50000M]);
            Console.WriteLine();
            // Вызываем метод Print от созданного объекта
            type.GetMethod("Print").Invoke(person, null); // person.Print();

            string[] files = Directory.GetFiles(".", "DLL/*.dll");
            Assembly[] asm = new Assembly[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                asm[i] = Assembly.LoadFrom(files[i]);
            }
            List<Type> types = new List<Type>();
            for (int i = 0; i < asm.Length; i++)
            {
                types.AddRange(asm[i].GetTypes());
            }
            List<MethodInfo> methodinfo = new List<MethodInfo>();
            foreach (Type t in types)
                methodinfo.AddRange(t.GetMethods());
            Console.WriteLine("Methods:\n\n");
            foreach (MethodInfo info in methodinfo)
                    Console.WriteLine(info.Name);

            int[] A = new int[10];
            methodinfo[0].Invoke(null, [A]); // public static void Init(int[] A)
            Console.WriteLine("\nИсходный массив:\n");
            methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
            methodinfo[6].Invoke(null, [A]); //  public static void Reverse(int[] A)
            Console.WriteLine("Массив после реверсирования:\n");
            methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
            methodinfo[7].Invoke(null, [A]); // public static void Neighbor(int[] A)
            Console.WriteLine("Массив после преобразования:\n");
            methodinfo[1].Invoke(null, [A]); // public static void Print(int[] A)
            Console.WriteLine("Сумма элементов массива: {0,4}",
                (int)methodinfo[12].Invoke(null, [A])); // public static int SumOfElements(int[] A)
            Console.WriteLine("Среднее арифметическое элементов массива: {0,4}",
                (double)methodinfo[13].Invoke(null, [A])); // public static double Average(int[] A)
        }

    }
}
