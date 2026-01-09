namespace ConsoleApp3;

public class OnlineCourse : Course
{
    public string PlatformOrLink { get; }
    public OnlineCourse(string title, string description, int durationInHours, string platformOrLink) : base(title, description, durationInHours, "online")
    {
        PlatformOrLink = platformOrLink;
    }
}