using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using APApiDbS2024InClass.Model;
using Npgsql;
using NpgsqlTypes;

namespace APApiDbS2024InClass.DataRepository
{
    public class Repository : BaseRepository
    {
        //Get a list of employees
        public List<Employee> GetEmployees()
        {
            //creating empty list to fill it from database
            var employees = new List<Employee>();
            //create a new connection for database
            var dbConn = new NpgsqlConnection(ConnectionString);
            //creating an SQL command
            var cmd = dbConn.CreateCommand();

            cmd.CommandText = "select * from employee";
            //call the base method to get data
            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read()) 
                {
                    Employee s = new Employee(Convert.ToInt32(data["id"]))
                    {
                        EmployeeName = data["EmployeeName"].ToString(),
                        Department = data["Department"].ToString(),
                    };

                    employees.Add(s);
                }

                return employees;
            }

            return null;
        }

        //Get a single employee using Id
        public Employee GetEmployeeById(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * from employee where id = {id}";

            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                if (data.Read())
                {
                    Employee s = new Employee(Convert.ToInt32(data["id"]))
                    {
                        EmployeeName = data["EmployeeName"].ToString(),
                        Department = data["Department"].ToString(),
                    };

                    return s;
                }

                return null;
            }

            return null;
        }

        //add a new employee
        public bool InsertEmployee(Employee s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
insert into employee 
(EmployeeName, Department)
values
(@EmployeeName, @Department)
";

            cmd.Parameters.AddWithValue("@EmployeeName", NpgsqlDbType.Text, s.EmployeeName);
            cmd.Parameters.AddWithValue("@Department", NpgsqlDbType.Text, s.Department);

            bool result = InsertData(dbConn, cmd);

            return result;
        }

        public bool UpdateEmployee(Employee s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
update employee set
    EmployeeName = @EmployeeName,
    Department = @Department
where
    id = @id
";

            cmd.Parameters.AddWithValue("@EmployeeName", NpgsqlDbType.Text, s.EmployeeName);
            cmd.Parameters.AddWithValue("@Department", NpgsqlDbType.Text, s.Department);
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, s.ID);

            bool result = UpdateData(dbConn, cmd);
            return result;
        }

        public bool DeleteEmployee(int id)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"
delete from Employee
where id = @id
";

            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, id);

            bool result = DeleteData(dbConn, cmd);

            return result;

        }

        public List<TimeRegistration> GetTimeregistrationsById (int id)
        {
            var Registrations = new List<TimeRegistration>();
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = $"select * FROM public.\"time registration\" where employee_id = {id}";

            var data = GetData(dbConn, cmd);

            if (data != null)
            {
                while (data.Read())
                {
                    TimeRegistration s = new TimeRegistration()
                    {
                        HoursRegistered = (int) data["hours_registered"],
                        DateWorked = (DateTime) data["date_worked"],
                        EmployeeId = (int) data["employee_id"]
                    };

                    Registrations.Add(s);
                }

                return Registrations;
            }

            return null;
        }
        public bool InsertTimeRegistration(TimeRegistration s)
        {
            var dbConn = new NpgsqlConnection(ConnectionString);
            var cmd = dbConn.CreateCommand();
            cmd.CommandText = @"

INSERT INTO ""time registration""
(hours_registered, employee_id, date_worked)
	VALUES(@HoursRegistered, @EmployeeId, @DateWorked)";

            cmd.Parameters.AddWithValue("@HoursRegistered", NpgsqlDbType.Integer, s.HoursRegistered);
            cmd.Parameters.AddWithValue("@EmployeeId", NpgsqlDbType.Integer, s.EmployeeId);
            cmd.Parameters.AddWithValue("@DateWorked", NpgsqlDbType.Date, s.DateWorked);

            bool result = InsertData(dbConn, cmd);

            return result;
        }
    }
 }
