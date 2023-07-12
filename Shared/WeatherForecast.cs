namespace BlazorApp.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public object hash { get; set; }

        public string? Summary { get; set; }

        //public int TemperatureF => 32 + (int)(hash / 0.5556);
    }
}