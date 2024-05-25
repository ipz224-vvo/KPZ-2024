namespace lab_3.Bridge;
abstract class Renderer
{
    public abstract void RenderCircle();
    public abstract void RenderSquare();
    public abstract void RenderTriangle();
}
class VectorRenderer : Renderer
{
    public override void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as vectors");
    }

    public override void RenderSquare()
    {
        Console.WriteLine("Drawing Square as vectors");
    }

    public override void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as vectors");
    }
}

class RasterRenderer : Renderer
{
    public override void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as pixels");
    }

    public override void RenderSquare()
    {
        Console.WriteLine("Drawing Square as pixels");
    }

    public override void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as pixels");
    }
}