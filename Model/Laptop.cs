namespace apbd_cw2_git_s31225.Model;

public class Laptop(string id, string name, bool isAvailable, int ram, string procesor)
    : Device(id, name, isAvailable)
{
    public int Ram { get; set; } = ram;
    public string Procesor { get; set; } = procesor;
}