namespace lab_4.Strategy;

public class NetworkImageLoader : ImageLoader
{
    public override string LoadImage(string path)
    {
        Console.WriteLine("Image loaded from network");
        return path;
    }
}