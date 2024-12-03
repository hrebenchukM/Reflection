using System;

namespace Init_Print
{
public class Person
       {
        //защищённые поля name (имя), surname (фамилия), age (возраст),phone(телефон);
        protected string name;
        protected string surname;
        protected int age;
        protected string phone;


        //свойства Name, Surname, Age, Phone;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        //конструктор по умолчанию 
        public Person()
        {
        }
        //конструктор с параметрами
        public Person(string n, string s, int a, string p)
        {
            Console.WriteLine("Конструктор класса Person");
            name = n;
            surname = s;
            age = a;
            phone = p;

        }

        //метод Print для вывода информации на экран
        public void Print()
        {
            Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}, Phone: {3}", name, surname, age, phone);
        }
       }

}
