namespace lab_2.Builder;

public class EnemyBuilder : ICharacterBuilder
{
    private Character character = new();
    private List<string> goodDeeds = new();
    private List<string> evilDeeds = new();

    public ICharacterBuilder SetHeight(int height)
    {
        character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string hairColor)
    {
        character.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder SetEyes(string eyes)
    {
        character.Eyes = eyes;
        return this;
    }

    public ICharacterBuilder SetClothes(string clothes)
    {
        character.Clothes = clothes;
        return this;
    }

    public ICharacterBuilder SetEquipment(string equipment)
    {
        character.Equipment = equipment;
        return this;
    }

    public ICharacterBuilder AddDeed(string deed)
    {
        evilDeeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        character.EvilDeeds = evilDeeds;
        return character;
    }
}