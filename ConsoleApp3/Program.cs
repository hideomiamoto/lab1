using ConsoleApp3;

class Program
{
    public static void Main(string[] args)
    {
        // Курсы
        var mgmt = new CourseManagement();

        var online = new OnlineCourse(
            title: "C# Base",
            description: "Основы C# и ООП",
            durationInHours: 12,
            platformOrLink: "https://example.com/meet"
        );

        var offline = new OfflineCourse(
            title: "OOP Practice",
            description: "Практика ООП на примерах",
            durationInHours: 8,
            location: "Ауд. 101",
            maxCapacity: 1
        );

        mgmt.AddCourse(online);
        mgmt.AddCourse(offline);

        // Преподаватели
        var teacher1 = new Teacher("Иванова", "Мария", "Егоровна", 40, 10);
        var teacher2 = new Teacher("Петров", "Иван", "Сергеевич", 35, 7);

        mgmt.AssignTeacher(online, teacher1);
        mgmt.AssignTeacher(offline, teacher2);

        // Студенты
        var s1 = new Student("Иванов", "Егор", "Егорович", 18, 1, "ИТ", "M3140");
        var s2 = new Student("Сидоров", "Данил", "Андреевич", 19, 1, "ИТ", "M3140");

        mgmt.AssignStudent(online, s1);
        mgmt.AssignStudent(online, s2);
    }
}