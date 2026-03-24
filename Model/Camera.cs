namespace apbd_cw2_git_s31225.Model;

public class Camera(string id, string name, bool isAvailable, string matrixType, string imageProcessor)
    : Device(id, name, isAvailable)
{
    public string MatrixType { get; set; } = matrixType;
    public string ImageProcessor { get; set; } = imageProcessor;
}