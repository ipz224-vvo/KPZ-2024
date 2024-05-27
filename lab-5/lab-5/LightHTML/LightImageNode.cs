using lab_4.Strategy;
using lab_5.Visitor;

namespace lab_5.LightHTML;

class LightImageNode : LightNode
{
    private string src;
    private string alt;
    private ImageLoader imageLoader;
    private string cssStyles; 

    public LightImageNode(string src, string alt, ImageLoader imageLoader, string cssStyles = null)
    {
        this.src = src;
        this.alt = alt;
        this.imageLoader = imageLoader;
        this.cssStyles = cssStyles;
    }

    public override string OuterHTML
    {
        get
        {
            string loadedImage = imageLoader.LoadImage(src);
            string cssStylesString = cssStyles != null ? $" style=\"{cssStyles}\"" : "";
            return $"<img src=\"{loadedImage}\" alt=\"{alt}\"{cssStylesString} />";
        }
    }

    public string GetSrc() => src;
    public string GetAlt() => alt;
    public ImageLoader GetLoader() => imageLoader;
    public string GetCssStyles() => cssStyles;
    
    public override string InnerHTML
    {
        get { return ""; }
    }

    public override LightNode Accept(ILightNodeVisitor visitor)
    {
        return visitor.Visit(this);
    }
}