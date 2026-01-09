namespace ConsoleApp3;

public class Student : Human
{
    public int Year { get; private set; }
    public string Department { get; private set; }
    public string Group { get; private set; }

    public Student(string surname, string name, string secondName, int age, int year, string department, string group) : base(surname, name, secondName, age)
    {
        Year = year;
        Department = department;
        Group = group;
    }
}