// See https://aka.ms/new-console-template for more information

using RTOW.Image;

Console.WriteLine("Hello, World!");
PPMImage image = new PPMImage(10, 10);


image[1, 1] = (0, 0, 1);
Console.WriteLine(image.DumpToString());