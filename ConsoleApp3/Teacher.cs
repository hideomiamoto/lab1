namespace ConsoleApp3;

public class Teacher : Human
{
    public int YearsOfPractice { get; private set; }
    
    public Teacher(string surname, string name, string secondName, int age, int yearsOfPractice) : base(surname, name, secondName, age)
    {
        YearsOfPractice = yearsOfPractice;
    }
}