namespace apbd_cw2_git_s31225.Model;

public class User(string id, string name, string surname)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
}