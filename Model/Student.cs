namespace apbd_cw2_git_s31225.Model;

public class Student(string id, string name, string surname, string indexNumber, string faculty)
    : User(id, name, surname)
{
    public string IndexNumber { get; set; } = indexNumber;
    public string Faculty { get; set; } = faculty;
}