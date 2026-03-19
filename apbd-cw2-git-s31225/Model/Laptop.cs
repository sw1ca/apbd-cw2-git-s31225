namespace apbd_cw2_git_s31225.Model;

public class Laptop : Device
{
    public int ram;
    public string procesor;

    public Laptop(string id, string name, int ram, string procesor) : base(id, name)
    {
        this.ram = ram;
        this.procesor = procesor;
    }
}