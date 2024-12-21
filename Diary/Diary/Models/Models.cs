using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisterViewModel
{
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string SelectedClassKey { get; set; }
}

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }
    
    [Column("username")]
    public string Username { get; set; }
    
    [Column("password")]
    public string Password { get; set; } 
    
    [Column("role")]
    public string Role { get; set; } 
    
    [Column("first_name")]
    public string FirstName { get; set; } 
    
    [Column("last_name")]
    public string LastName { get; set; } 
    
    [Column("patronymic")]
    public string Patronymic { get; set; } 
    
    [Column("phone_number")]
    public string PhoneNumber { get; set; } 
    
    [Column("subject")]
    public string Subject { get; set; } = "";
}

[Table("students")]
public class Student
{
    [Key]
    [Column("student_id")]
    public long StudentId { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("patronymic")]
    public string Patronymic { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("class_id")]
    public long ClassId { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
}

[Table("teachers")]
public class Teacher
{
    [Key]
    [Column("teacher_id")]
    public long TeacherId { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("first_name")]  
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("patronymic")]
    public string Patronymic { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("subject")]
    public string Subject { get; set; }
    [Column("user_id")]
    public long UserId { get; set;}
    [Column("password")]
    public string Password { get; set; } 

}

[Table("administrators")]
public class Administrator
{
    [Key]
    [Column("admin_id")]
    public long AdminId { get; set; }
    [Column("username")]
    public string Username { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("patronymic")]
    public string Patronymic { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("password")]
    public string Password { get; set; }
}

[Table("classes")]
public class Class
{
    [Key]
    [Column("class_id")]
    public long ClassId { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("class_name")]
    public string ClassName { get; set; } // Название класса
    [Column("GPA")]
    public double Gpa { get; set; } // Средний балл
    [Column("teacher_id")]
    public long TeacherId { get; set; } // Идентификатор учителя
    [Column("admin_id")]
    public long AdminId { get; set; } // Идентификатор администратора
}

public class Subjects{
    [Key]
    [Column("subject_id")]
    public long SubjectId { get; set; }
    [Column("subject_name")]
    public string SubjectName { get; set; }
    [Column("teacher_id")]
    public long TeacherId { get; set; }
    [Column("admin_id")]
    public long AdminId { get; set; }
}
public class Grades{
    [Key]
    [Column("grade_id")]
    public long GradeId { get; set; }
    [Column("student_id")]
    public long StudentId { get; set; }
    [Column("subject_id")]
    public long SubjectId { get; set; }
    [Column("grade")]
    public int Grade { get; set; }
    [Column("teacher_id")]
    public long TeacherId { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
}

[Table("gpa")]
public class GPA{
    [Key]
    [Column("average_id")]
    public long AverageId { get; set; }
    [Column("student_id")]
    public long StudentId { get; set; }
    [Column("average_grade")]
    public double Average { get; set; }
    [Column("term")]
    public int Term { get; set; }
}
