namespace lab_2.Builder;

public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyes(string eyes);
    ICharacterBuilder SetClothes(string clothes);
    ICharacterBuilder SetEquipment(string equipment);
    ICharacterBuilder AddDeed(string deed);
    Character Build();
}