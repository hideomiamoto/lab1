namespace ConsoleApp3;

public abstract class Human
{
    public string Name { get; } //Неизменно после создания
    public string Surname { get; }
    public string SecondName { get; }
    public int Age { get; }
    
    public string FullName => $"{Surname} {Name} {SecondName}";
    
    protected Human(string surname, string name, string secondName, int age)
    {
        Surname = surname;
        Name = name;
        SecondName = secondName;
        Age = age;
    }
}
