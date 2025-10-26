using System;
using System.Collections.Generic;

// CommunityFairEvent.cs
// Derived: Community Fairs (weather + booth setup)

using System;
using System.Collections.Generic;

namespace FamilyEvents
{
    public class CommunityFairEvent : FamilyEvent
    {
       public string WeatherForecast { get; private set; }
        private readonly List<string> _booths = new();

        public CommunityFairEvent(string title, string desc, DateTime start, string location, string weatherForecast)
            : base(title, desc, start, location)
        {
            WeatherForecast = string.IsNullOrWhiteSpace(weatherForecast) ? "TBD" : weatherForecast.Trim();
        }
        public void UpdateWeather(string forecast)
        {
            if (!string.IsNullOrWhiteSpace(forecast))
                WeatherForecast = forecast.Trim();
        }
        public void AddBooth(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                _booths.Add(name.Trim());
        }

        
    }
}

        