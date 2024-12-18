public class Class
{
    public long ClassId { get; set; }
    public string ClassName { get; set; }
    public double GPA { get; set; }
    public long TeacherId { get; set; }
    public long AdminId { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Student
{
    public long StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public long ClassId { get; set; }
    public string Patronymic { get; set; }
}
