using System;
using System.Linq;
using Xunit;
using ConsoleApp3;

namespace ConsoleApp3.Tests;

public class CourseManagementTests
{
    [Fact]
    public void AddCourse_AddsCourseToCoursesList()
    {
        var mgmt = new CourseManagement();
        var course = new OnlineCourse("C# Base", "Intro", 10, "https://example.com");

        mgmt.AddCourse(course);

        Assert.Contains(course, mgmt.Courses);
    }

    [Fact]
    public void AddCourse_DuplicateCourse_ThrowsInvalidOperationException()
    {
        var mgmt = new CourseManagement();
        var course = new OnlineCourse("C# Base", "Intro", 10, "https://example.com");

        mgmt.AddCourse(course);

        Assert.Throws<InvalidOperationException>(() => mgmt.AddCourse(course));
    }

    [Fact]
    public void RemoveCourse_RemovesCourseFromCoursesList()
    {
        var mgmt = new CourseManagement();
        var course = new OnlineCourse("C# Base", "Intro", 10, "https://example.com");

        mgmt.AddCourse(course);
        mgmt.RemoveCourse(course);

        Assert.DoesNotContain(course, mgmt.Courses);
    }

    [Fact]
    public void AssignTeacher_AddsTeacherToCourse()
    {
        var mgmt = new CourseManagement();
        var course = new OfflineCourse("OOP", "Basics", 12, "Aud 101", 30);
        var teacher = new Teacher("Ivanova", "Maria", "Egorovna", 40, 10);

        mgmt.AddCourse(course);
        mgmt.AssignTeacher(course, teacher);

        Assert.Contains(teacher, course.Teachers);
        Assert.Contains(teacher, mgmt.GetTeachers(course));
    }

    [Fact]
    public void UnassignTeacher_RemovesTeacherFromCourse()
    {
        var mgmt = new CourseManagement();
        var course = new OfflineCourse("OOP", "Basics", 12, "Aud 101", 30);
        var teacher = new Teacher("Ivanova", "Maria", "Egorovna", 40, 10);

        mgmt.AddCourse(course);
        mgmt.AssignTeacher(course, teacher);

        mgmt.UnassignTeacher(course, teacher);

        Assert.DoesNotContain(teacher, course.Teachers);
        Assert.DoesNotContain(teacher, mgmt.GetTeachers(course));
    }

    [Fact]
    public void GetCoursesByTeacher_ReturnsOnlyCoursesWhereTeacherAssigned()
    {
        var mgmt = new CourseManagement();
        var teacher = new Teacher("Ivanova", "Maria", "Egorovna", 40, 10);

        var course1 = new OnlineCourse("C#", "Intro", 10, "https://example.com");
        var course2 = new OfflineCourse("OOP", "Basics", 12, "Aud 101", 30);

        mgmt.AddCourse(course1);
        mgmt.AddCourse(course2);

        mgmt.AssignTeacher(course1, teacher);

        var courses = mgmt.GetCoursesByTeacher(teacher);

        Assert.Contains(course1, courses);
        Assert.DoesNotContain(course2, courses);
    }

    [Fact]
    public void AssignStudent_AddsStudentToCourse()
    {
        var mgmt = new CourseManagement();
        var course = new OnlineCourse("C# Base", "Intro", 10, "https://example.com");
        var student = new Student("Ivanov", "Egor", "Egorovich", 18, 1, "IT", "M3140");

        mgmt.AddCourse(course);
        mgmt.AssignStudent(course, student);

        Assert.Contains(student, course.Students);
        Assert.Contains(student, mgmt.GetStudents(course));
    }

    [Fact]
    public void AssignStudent_DuplicateStudent_ThrowsInvalidOperationException()
    {
        var mgmt = new CourseManagement();
        var course = new OnlineCourse("C# Base", "Intro", 10, "https://example.com");
        var student = new Student("Ivanov", "Egor", "Egorovich", 18, 1, "IT", "M3140");

        mgmt.AddCourse(course);
        mgmt.AssignStudent(course, student);

        Assert.Throws<InvalidOperationException>(() => mgmt.AssignStudent(course, student));
    }

    [Fact]
    public void OfflineCourse_WhenCapacityExceeded_ThrowsInvalidOperationException()
    {
        var mgmt = new CourseManagement();
        var course = new OfflineCourse("OOP", "Basics", 12, "Aud 101", 1);

        var s1 = new Student("Ivanov", "Egor", "Egorovich", 18, 1, "IT", "M3140");
        var s2 = new Student("Petrov", "Ivan", "Ivanovich", 19, 1, "IT", "M3140");

        mgmt.AddCourse(course);

        mgmt.AssignStudent(course, s1);
        Assert.Throws<InvalidOperationException>(() => mgmt.AssignStudent(course, s2));
    }
}
