using MVCArchitecture.Web.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(30), Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ImagePath { get; set; }

        [CustomDateRange, Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    /// <summary>
    /// Wrong - Display Logic should be handled by view
    /// </summary>
    //public class StudentDisplayViewModel
    //{
    //    public int StudentId { get; set; }
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //    public string ImagePath { get; set; }
    //    public DateTime AddmissionDate { get; set; }

    //    public StudentDisplayViewModel(Student student)
    //    {
    //        StudentId = student.Id;
    //        Name = $"{student.FirstName} {student.MiddleName} {student.LastName}";
    //        Address = $"{student.Address}, {student.City}, {student.State}, {student.Country}";
    //        ImagePath = student.ImagePath;
    //        AddmissionDate = student.AddmissionDate;
    //    }
    //}
}
