namespace lab_4.Strategy;

public class FileSystemImageLoader : ImageLoader
{
    public override string LoadImage(string path)
    {
        Console.WriteLine("Image loaded from file system.");
        return path;
    }
}
