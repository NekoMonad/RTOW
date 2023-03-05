using System.Text;

namespace RTOW.Image;

public class PPMImage: Image
{
    private const int Channel = 3;
    public int Width { get; }
    public int Height { get; }
    private readonly byte[] _imageData;

    public PPMImage(int width, int height)
    {
        Height = height;
        Width = width;
        _imageData = new byte[Height * Width * Channel];
        Clear();
    }

    public (byte, byte, byte) this[int width, int height]
    {
        get
        {
            int fstPos = WhPos2Idx(width, height);
            return (_imageData[fstPos + 0], _imageData[fstPos + 1], _imageData[fstPos + 2]);
        }
        set
        {
            int fstPos = WhPos2Idx(width, height);
            _imageData[fstPos + 0] = value.Item1;
            _imageData[fstPos + 1] = value.Item2;
            _imageData[fstPos + 2] = value.Item3;
        }
    }

    public int WhPos2Idx(int width, int height)
    {
        if (width < 0 || width >= Width)
        {
            throw new IndexOutOfRangeException("PPMImage: width not in range");
        }

        if (height < 0 || height >= Height)
        {
            throw new IndexOutOfRangeException("PPMImage: height not in range");
        }

        return (height * Height + width) * Channel;
    }

    public void Clear()
    {
        for (int i = 0; i < Height * Width * Channel; i++)
        {
            _imageData[i] = default;
        }
    }

    public string DumpToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append($"P3\n{Width} {Height}\n255\n");
        for (int j = Height - 1; j >= 0; j--)
        {
            for (int i = 0; i < Width; i++)
            {
                var pix = this[i, j];
                result.Append($"{pix.Item1} {pix.Item2} {pix.Item3}\n");
            }
        }
        return result.ToString();
    }
}