// See https://aka.ms/new-console-template for more information

using RTOW.Image;
using RTOW.Math;

Console.WriteLine("Hello, World!");
PPMImage image = new PPMImage(10, 10);

for (int j = 10 - 1; j >= 0; j--)
{
    for (int i = 0; i < 10; i++)
    {
        var color = new Vec3<double>((double)i / 10, (double)j / 10, 0.2);
        // TODO
    }
}