using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EmployeeManagement.Model.Model;
using WPF.EmployeeManagement.UI.Model;

namespace WPF.EmployeeManagement.DataAccess
{
    public static class DataSeedClass
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Firstname = "Rafael", Lastname = "Milanes", Email = "johnny@gmail.com", Department = Department.IT, Phonenumber=112 },
            new Employee { Id = 2, Firstname = "Johnny", Lastname = "Cage", Email = "Juan@gmail.com", Department = Department.IT, Phonenumber = 112 },
            new Employee { Id = 3, Firstname = "Anna", Lastname = "Lindgren", Email = "Anna@gmail.com", Department = Department.Agriculture, Phonenumber = 112 },
            new Employee { Id = 4, Firstname = "Juanete", Lastname = "Pérez", Email = "John@gmail.com", Department = Department.Education, Phonenumber = 112 },
            new Employee { Id = 5, Firstname = "New", Lastname = "SuperNew", Email = "new@gmail.com", Department = Department.Education, Phonenumber = 112 }
            );

            modelBuilder.Entity<Meeting>().HasData(
            new Meeting { MeetingID = 1, Title = "Rum 1", StartDate = DateTime.Now, EndDate = DateTime.Now },
            new Meeting { MeetingID = 2, Title = "Rum 2", StartDate = DateTime.Now, EndDate = DateTime.Now }
            );

            //modelBuilder.Entity<Employee_Meeting>().HasData(
            //new Employee_Meeting { },
            //new Employee_Meeting { }
            //);
        }
    }
}
