namespace apbd_cw2_git_s31225.Model;

public class Laptop : Device
{
    public int Ram;
    public string Procesor;

    public Laptop(string id, string name, int ram, string procesor) : base(id, name)
    {
        Ram = ram;
        Procesor = procesor;
    }
}