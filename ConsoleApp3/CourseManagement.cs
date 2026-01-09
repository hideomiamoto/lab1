namespace ConsoleApp3;

public class CourseManagement
{
    private List<Course> _courses;
    public IReadOnlyList<Course> Courses => _courses;

    public CourseManagement()
    {
        _courses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        if (_courses.Contains(course))
        {
            throw new InvalidOperationException("Такой курс уже есть.");
        }
        _courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        _courses.Remove(course);
    }

    public void AssignTeacher(Course course, Teacher teacher)
    {
        course.AddTeacher(teacher);
    }

    public void UnassignTeacher(Course course, Teacher teacher)
    {
        course.RemoveTeacher(teacher);
    }

    public void AssignStudent(Course course, Student student)
    {
        course.AddStudent(student);
    }

    public void UnassignStudent(Course course, Student student)
    {
        course.RemoveStudent(student);
    }
    
    public IReadOnlyList<Student> GetStudents(Course course) => course.Students;
    public IReadOnlyList<Teacher> GetTeachers(Course course) => course.Teachers;

    public List<Course> GetCoursesByTeacher(Teacher teacher)
    {
        var result = new List<Course>();

        foreach (var course in _courses)
        {
            if (course.Teachers.Contains(teacher))
                result.Add(course);
        }

        return result;
    }
}