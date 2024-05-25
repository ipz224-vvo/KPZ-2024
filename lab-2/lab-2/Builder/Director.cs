namespace lab_2.Builder;

public class Director
{
    private ICharacterBuilder builder;

    public Director(ICharacterBuilder builder)
    {
        this.builder = builder;
    }

    public void CreateHero()
    {
        builder.SetHeight(180)
            .SetBuild("Muscular")
            .SetHairColor("Blond")
            .SetEyes("Blue")
            .SetClothes("Superhero costume")
            .SetEquipment("Superpowers")
            .AddDeed("Saved the world from aliens")
            .AddDeed("Stopped a bank robbery");
    }

    public void CreateEnemy()
    {
        builder.SetHeight(190)
            .SetBuild("Tall and skinny")
            .SetHairColor("Black")
            .SetEyes("Red")
            .SetClothes("Villain costume")
            .SetEquipment("Evil superpowers")
            .AddDeed("Stole the national treasure")
            .AddDeed("Attacked a small town");
    }

    public Character GetCharacter()
    {
        return builder.Build();
    }
}