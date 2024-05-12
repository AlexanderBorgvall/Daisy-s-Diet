using System;
using System.Text.Json.Serialization;

namespace APApiDbS2024InClass.Model
{
    public class TimeRegistration
    {
        [JsonPropertyName("hoursRegistered")]
        public int HoursRegistered { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("dateworked")]
        public DateTime DateWorked { get; set; }

    }
}
