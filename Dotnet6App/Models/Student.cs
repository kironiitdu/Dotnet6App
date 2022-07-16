using System.ComponentModel.DataAnnotations;

namespace Dotnet6App.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string DoB { get; set; }
        public string? Gender { get; set; }
        public bool Remember { get; set; }
        public string? Student_Name { get; set; }
        public string? Student_Middle_Name { get; set; }
        public string? Student_Lastname { get; set; }
        public long SID_Number { get; set; }
     
        public int ParentID { get; set; }
       
        public int StudentTypeID { get; set; }
       
        public int GradeID { get; set; } 
        public int YearID { get; set; }
       
        public int ClassTypeID { get; set; }
    }
}
