namespace apbd_cw2_git_s31225.Model;

public class Employee(string id, string name, string surname, string title, string subject)
    : User(id, name, surname)
{
    public string Title { get; set; } = title;
    public string Subject { get; set; } = subject;
}