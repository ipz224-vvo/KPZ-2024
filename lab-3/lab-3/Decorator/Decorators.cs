namespace lab_3.Decorator;


abstract class InventoryDecorator : Hero
{
    protected Hero hero;

    public InventoryDecorator(Hero hero)
    {
        this.hero = hero;
    }

    public override void Attack()
    {
        hero.Attack();
    }
}

class SwordDecorator : InventoryDecorator
{
    public SwordDecorator(Hero hero) : base(hero) { }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine(" with a sword");
    }
}

class ShieldDecorator : InventoryDecorator
{
    public ShieldDecorator(Hero hero) : base(hero) { }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine(" with shield");
    }
}

class AmuletDecorator : InventoryDecorator
{
    public AmuletDecorator(Hero hero) : base(hero) { }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine(" with an amulet");
    }
}
