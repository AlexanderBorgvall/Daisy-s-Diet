using System;
using System.Text.Json.Serialization;

namespace APApiDbS2024InClass.Model
{
    public class TimeRegistration
    {
        [JsonPropertyName("Hours Registered")]
        public int HoursRegistered { get; set; }

        [JsonPropertyName("EmployeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("Date Worked")]
        public DateTime DateWorked { get; set; }

        [JsonPropertyName("Total Hours Registered")]
        public int TotalHoursRegistered { get; set; }

        [JsonPropertyName("Total Hours Approved")]
        public int TotalHoursApproved { get; set; }
    }
}
