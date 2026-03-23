namespace apbd_cw2_git_s31225.Model;

public class Device
{
    public string Id;
    public string Name;
    public bool isAvailable;

    public Device(string id, string name)
    {
        Id = id;
        Name = name;
        isAvailable = true;
    }
}