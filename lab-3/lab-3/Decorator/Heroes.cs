namespace lab_3.Decorator;

using System;

abstract class Hero
{
    public abstract void Attack();
}

class Warrior : Hero
{
    public override void Attack()
    {
        Console.WriteLine("A warrior attacks\n with a sword");
    }
}

class Mage : Hero
{
    public override void Attack()
    {
        Console.WriteLine("The magician attacks\n with a fireball");
    }
}

class Paladin : Hero
{
    public override void Attack()
    {
        Console.WriteLine("Paladin attacks with\n a holy sword");
    }
}
