namespace BadNews.Repositories.Weather
{
    public class OpenWeatherForecast
    {
        public WeatherInfo[] Weather { get; set; }
        public MainInfo Main { get; set; }

        public class WeatherInfo
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
            public string IconUrl => Icon != null
                ? $"http://openweathermap.org/img/wn/{Icon}@2x.png"
                : null;
        }

        public class MainInfo
        {
            public decimal Temp { get; set; }
            public decimal FeelsLike { get; set; }
            public decimal TempMin { get; set; }
            public decimal TempMax { get; set; }
            public decimal Pressure { get; set; }
            public decimal Humidity { get; set; }
        }
    }
}
