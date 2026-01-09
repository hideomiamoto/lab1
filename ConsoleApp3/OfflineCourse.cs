namespace ConsoleApp3;

public class OfflineCourse : Course
{
    public string Location { get; }
    public int MaxCapacity { get; }
    public OfflineCourse(string title, string description, int durationInHours, string location, int maxCapacity) : base(title, description, durationInHours, "offline")
    {
        Location = location;
        MaxCapacity = maxCapacity;
    }

    public override void AddStudent(Student student)
    {
        if (Students.Count >= MaxCapacity)
        {
            throw new InvalidOperationException("Курс переполнен.");
        }
        base.AddStudent(student);
    }
}