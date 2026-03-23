namespace apbd_cw2_git_s31225.Model;

public class Projector(string id, string name, bool isAvailable, string resolution, int brightness) : Device(id, name, isAvailable)
{
    public string Resolution { get; set; } = resolution;
    public int Brightness { get; set; } = brightness;
}