using lab_4.Strategy;

namespace lab_5.LightHTML;

class LightImageNode : LightNode
{
    private string src;
    private string alt;
    private ImageLoader imageLoader;

    public LightImageNode(string src,string alt, ImageLoader imageLoader)
    {
        OnCreated();
        this.src = src;
        this.alt = alt;
        this.imageLoader = imageLoader;
    }

    public override string OuterHTML
    {
        get
        {
            string loadedImage = imageLoader.LoadImage(src);
            return $"<img src=\"{loadedImage}\" alt=\"{alt}\" />";
        }
    }

    public override string InnerHTML
    {
        get { return ""; }
    }
    protected override void OnCreated()
    {
        Console.WriteLine("LightImageNode created.");
    }
    
}