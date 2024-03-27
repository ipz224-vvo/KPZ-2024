namespace lab_1.Models;

public abstract class Money
{
    public abstract string CurrencyTitle { get; }
    public abstract char CurrencySymbol { get; }
    protected int RoundAmount { get; set; }
    protected int Pennies { get; set; }

    public void SetMoney(int roundAmount, int pennies)
    {
        if (roundAmount < 0)
            throw new ArgumentOutOfRangeException(nameof(roundAmount), "Round amount cannot be negative");
        if (pennies < 0 || pennies > 99)
            throw new ArgumentOutOfRangeException(nameof(pennies), "Coins must be in range from 0 to 99");

        RoundAmount = roundAmount;
        Pennies = pennies;
    }

    public string GetShortMoneyInfo()
    {
        return $"{RoundAmount}.{Pennies} {CurrencySymbol}";
    }

    public string GetFullMoneyInfo()
    {
        return $"{RoundAmount}.{Pennies} {CurrencyTitle}";
    }
    public override string ToString()
    {
        return GetShortMoneyInfo();
    }
}