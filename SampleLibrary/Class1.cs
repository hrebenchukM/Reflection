using System;

namespace SampleLibrary
{
    public class Person(string Name, string LastName, int Age)
    {
        public virtual void Print()
        {
            Console.WriteLine("Person:\nName: " + Name + "\nLastname: " + LastName + "\nAge: " + Age);
        }
    }

    public class Employee(string Name, string LastName, int Age, string Position, decimal Salary) : Person(Name, LastName, Age)
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Position: " + Position + "\nSalary: " + Salary);
        }
    }
}
