using System;
using System.Text.Json.Serialization;

namespace APApiDbS2024InClass.Model
{
    public class Employee
    {
        public Employee(int id)
        {
            ID = id;
        }

        public Employee() { }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("Employee name")]
        public string EmployeeName { get; set; }

        [JsonPropertyName("Department")]
        public string Department { get; set; }
    }
}
