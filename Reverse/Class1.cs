using System;

using Init_Print;

using System.Collections;

namespace Reverse
{
    // Существует возможность «научить» класс сортироваться
    // Для этого необходимо отнаследовать класс от интерфейса IComparable
    // Существует возможность «научить» класс сортироваться по определённому критерию 
    // Для этого необходимо отнаследовать класс от интерфейса IComparer
     public class Student : Person, IComparable
     {
            //реализующий интерфейс IComparable
            public int CompareTo(object obj)
            {
                if (obj is Student)
                    return Average.CompareTo((obj as Student).Average);

                throw new NotImplementedException();
            }
            //вложенные классы, реализующие интерфейс IComparer (для сортировки по различным критериям). 
            public class SortByAverage : IComparer
            {
                int IComparer.Compare(object obj1, object obj2)
                {
                    if (obj1 is Student && obj2 is Student)
                        return (obj2 as Student).Average.CompareTo((obj1 as Student).Average);

                    throw new NotImplementedException();
                }
            }
            public class SortByNumber_of_group : IComparer
            {
                int IComparer.Compare(object obj1, object obj2)
                {
                    if (obj1 is Student && obj2 is Student)
                        return (obj1 as Student).Number_of_group.CompareTo((obj2 as Student).Number_of_group);

                    throw new NotImplementedException();
                }
            }


            //защищённые поля average (средний балл), number_of_group (номер группы);

            protected double average;
            protected string number_of_group;

            //свойства Average, Number_Of_Group;
            public double Average
            {
                get
                {
                    return average;
                }
                set
                {
                    average = value;
                }
            }

            public string Number_of_group
            {
                get
                {
                    return number_of_group;
                }
                set
                {
                    number_of_group = value;
                }
            }


            //конструктор по умолчанию 
            public Student()
            {
            }
            //конструктор с параметрами
            public Student(string n, string s, int a, string p, double average, string number_of_group)
                 : base(n, s, a, p)
            {
                Console.WriteLine("Конструктор класса Student");
                this.average = average;
                this.number_of_group = number_of_group;
            }

            //метод Print для вывода информации на экран;

            public void Print()
            {
                base.Print();
                Console.WriteLine("Average: {0}, Number of group: {1} ", average, number_of_group);
            }
     }
    
}
