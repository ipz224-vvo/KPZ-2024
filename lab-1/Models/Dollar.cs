namespace lab_1.Models;

public class Dollar : Money
{
    public override char CurrencySymbol => '$';
    public override string CurrencyTitle => "USD";
}