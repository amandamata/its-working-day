using Newtonsoft.Json;

public class ItsWorkingDay
{
    public bool IsWeekend(DateTime day)
    {
        return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
    }

    public bool IsHoliday(DateTime day)
    {
        var holidays = GetHolidays();
        return holidays.Any(x => x.Date == day);
    }

    public List<Holiday> GetHolidays()
    {
        var filePath = Environment.CurrentDirectory + "/Holidays.json";
        return JsonConvert.DeserializeObject<List<Holiday>>(new StreamReader(filePath).ReadToEnd());
    }

    public record Holiday
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
