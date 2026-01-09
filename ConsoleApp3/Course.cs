namespace ConsoleApp3;

public abstract class Course
{
    public string Title { get; }
    public string Description { get; }
    public int DurationInHours { get; }
    public string TypeOfEducation { get; }

    private List<Student> _students;
    private List<Teacher> _teachers;
    
    public Course(string title, string description, int durationInHours, string typeOfEducation)
    {
        Title = title;
        Description = description;
        DurationInHours = durationInHours;
        TypeOfEducation = typeOfEducation;
        _students = new List<Student>();
        _teachers = new List<Teacher>();
    }
    
    public IReadOnlyList<Student> Students => _students;
    public IReadOnlyList<Teacher> Teachers => _teachers;

    
    public virtual void AddStudent(Student student)
    {
        if (_students.Contains(student))
        {
            throw new InvalidOperationException("Этот студент уже записан на курс.");  
        }
        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }

    public void AddTeacher(Teacher teacher)
    {
        if (_teachers.Contains(teacher))
        {
            throw new InvalidOperationException("Этот преподаватель уже назначен на курс.");   
        }
        _teachers.Add(teacher);   
    }

    public void RemoveTeacher(Teacher teacher)
    {
        _teachers.Remove(teacher);
    }
}
