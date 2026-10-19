using System;

class Person
{
    private string name;
    private string address;
    private double salary;

    public string Name { get => name; set => name = value; }
    public string Address { get => address; set => address = value; }
    public double Salary { get => salary; set => salary = value; }

    public Person() { }

    public Person(string name, string address, double salary)
    {
        this.name = name;
        this.address = address;
        this.salary = salary;
    }

    public static Person InputPersonInfo(string name, string address, string sSalary)
    {
        if (string.IsNullOrWhiteSpace(sSalary))
        {
            throw new Exception("You must input Salary.");
        }

        if (!double.TryParse(sSalary, out double salary))
        {
            throw new Exception("You must input digit.");
        }

        if (salary <= 0)
        {
            throw new Exception("Salary is greater than zero");
        }

        return new Person(name, address, salary);
    }

    public static void DisplayPersonInfo(Person person)
    {
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Address: {person.Address}");
        Console.WriteLine($"Salary: {person.Salary:F1}");
    }

    public static Person[] SortBySalary(Person[] person)
    {
        if (person == null || person.Length == 0)
        {
            throw new Exception("Can't Sort Person");
        }

        int n = person.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (person[j].Salary > person[j + 1].Salary)
                {
                    Person temp = person[j];
                    person[j] = person[j + 1];
                    person[j + 1] = temp;
                }
            }
        }
        return person;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====Management Person programer=====");
        Person[] persons = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Input Information of Person");
            Console.Write("Please input name: ");
            string name = Console.ReadLine();

            Console.Write("Please input address: ");
            string address = Console.ReadLine();

            Person p = null;
            while (p == null)
            {
                Console.Write("Please input salary: ");
                string sSalary = Console.ReadLine();
                try
                {
                    p = Person.InputPersonInfo(name, address, sSalary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            persons[i] = p;
        }

        // Sap xep va hien thi
        try
        {
            Person[] sortedPersons = Person.SortBySalary(persons);
            foreach (var person in sortedPersons)
            {
                Console.WriteLine("Information of Person you have entered:");
                Person.DisplayPersonInfo(person);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}