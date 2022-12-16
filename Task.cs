using System;

namespace Tskes;

public class Person
{
    public String Name;
    public int Age;

    public Person(String name, int age)
    {
        if (name == null || name == "" || name.Length >= 32)
        {
            throw new Exception();
        }

        if (age < 0 || age > 128)
        {
            throw new Exception();
        }

        Name = name;
        Age = age;

    }

    public virtual void Print()
    {

    }

}

public class Student : Person
{
    private int _Year;
    public int Year
    {
        get => _Year;

        set
        {
            if (value < 1 || value > 5)
            {
                throw new Exception();
            }

            _Year = value;
        }

    }

    private float _Gpa;

    public float Gpa
    {
        get => _Gpa;

        set
        {
            if (value < 0 || value > 5)
            {
                throw new Exception();
            }

            _Gpa = value;
        }

    }

    public Student(String name, int age, int year, float gpa) : base(name, age)
    {
        if (year < 1 || year > 5)
        {
            throw new Exception();
        }

        if (gpa < 0 || gpa > 4)
        {
            throw new Exception();
        }
        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        Console.Write($"My name is : {Name}   , my age is : {Age}  , and my gpa is : {Gpa}");
    }

}

public class Staff : Person
{
    public double Salary;
    public int JoineYear;

    public Staff(String name, int age, double salary, int joineyear) : base(name, age)
    {
        if (salary < 0 || salary > 120000)
        {
            throw new Exception();
        }

        if (joineyear < 21)
        {
            throw new Exception();
        }
        Salary = salary;
        JoineYear = joineyear;
    }

    public override void Print()
    {
        Console.Write($"My name is :{Name}  , my age is : {Age}  , and my salary is : {Salary}");
    }

}

public class Database
{

    private int _CurrentIndex = 0;
    Person[] people = new Person[50];

    public void AddStudent(Student student)
    {
        people[_CurrentIndex] = student;
        _CurrentIndex++;
    }

    public void AddStaff(Staff staff)
    {
        people[_CurrentIndex] = staff;
        _CurrentIndex++;
    }

    public void AddPerson(Person person)
    {
        people[_CurrentIndex] = person;
        _CurrentIndex++;
    }

    public void PrintAll()
    {
        for (int i = 0; i < _CurrentIndex; i++)
        {
            people[i].Print();
        }
    }


}



public class programe
{
    public static void Main()
    {
        var database = new Database();

        while (true)
        {

            Console.WriteLine("1 : for adding a student , 2 : for adding a staff , 3 : for adding a person , 4 : for printing out all people in People array");
            Console.Write("Enter the number of operation : ");
            int operation = Convert.ToInt32(Console.ReadLine());



            switch (operation)
            {
                case 1:
                    Console.Write("Name :");
                    var name = Console.ReadLine();

                    Console.Write("Age :");
                    var age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Year : ");
                    var year = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gpa : ");
                    var gpa = Convert.ToSingle(Console.ReadLine());

                    try
                    {
                        var student = new Student(name, age, year, gpa);

                        database.AddStudent(student);
                    }
                    catch (Exception M)
                    {
                        Console.WriteLine(M.Message);
                    }


                    break;

                case 2:
                    Console.Write("Name :");
                    var name2 = Console.ReadLine();

                    Console.Write("Age :");
                    var age2 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Year : ");
                    var salary = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gpa : ");
                    var joineyear = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        var staff = new Staff(name2, age2, salary, joineyear);

                        database.AddStaff(staff);
                    }
                    catch (Exception r)
                    {
                        Console.WriteLine(r.Message);
                    }

                    break;

                case 3:
                    Console.Write("Name :");
                    var name3 = Console.ReadLine();

                    Console.Write("Age :");
                    var age3 = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        var person = new Person(name3, age3);

                        database.AddPerson(person);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case 4:
                    database.PrintAll();

                    break;

                default:
                    Console.WriteLine("Enter Number between 1 and 4");

                    break;


            }


        }
    }
}