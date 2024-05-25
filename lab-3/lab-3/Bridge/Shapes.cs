namespace lab_3.Bridge;

using System;

abstract class Shape
{
    protected Renderer renderer;

    public Shape(Renderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw();
    public abstract void Resize(float factor);
}

class Circle : Shape
{
    public Circle(Renderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.RenderCircle();
    }

    public override void Resize(float factor)
    {
        Console.WriteLine($"Resizing Circle by factor {factor}");
    }
}

class Square : Shape
{
    public Square(Renderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.RenderSquare();
    }

    public override void Resize(float factor)
    {
        Console.WriteLine($"Resizing Square by factor {factor}");
    }
}

class Triangle : Shape
{
    public Triangle(Renderer renderer) : base(renderer) { }

    public override void Draw()
    {
        renderer.RenderTriangle();
    }

    public override void Resize(float factor)
    {
        Console.WriteLine($"Resizing Triangle by factor {factor}");
    }
}

