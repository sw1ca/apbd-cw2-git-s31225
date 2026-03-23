namespace apbd_cw2_git_s31225.Model;

public class Device(string id, string name, bool isAvailable)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public bool IsAvailable { get; set; } = isAvailable;
}