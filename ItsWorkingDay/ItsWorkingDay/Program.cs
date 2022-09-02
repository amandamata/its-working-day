using Newtonsoft.Json;
using System.Globalization;

var day = Console.ReadLine();

var dayToConsult = DateTime.ParseExact(day, "dd/MM/yyyy", CultureInfo.InvariantCulture);

Console.WriteLine(IsWeekend(dayToConsult));
Console.WriteLine(IsHoliday(dayToConsult));

bool IsWeekend(DateTime day)
{
    return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
}

bool IsHoliday(DateTime day)
{
    var holidays = GetHolidays();
    return holidays.Any(x => x.Date == day);
}

static List<Holiday> GetHolidays()
{
    var filePath = Environment.CurrentDirectory + "/Holidays.json";
    return JsonConvert.DeserializeObject<List<Holiday>>(new StreamReader(filePath).ReadToEnd());
}

record Holiday
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
}