public class ScheduleAcces : JsonFileAccess<Schedule>
{
    public ScheduleAcces(int Auditorium) : base($"ScheduleAuditorium{Auditorium}.json"){}
}