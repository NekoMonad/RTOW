namespace RTOW.Image;

public interface Image
{
    public int Height { get; }
    public int Width { get; }
    public (byte, byte, byte) this[int width, int height] { get; set; }
}
