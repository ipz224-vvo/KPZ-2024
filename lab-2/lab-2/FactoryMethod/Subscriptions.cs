namespace lab_2.FactoryMethod;

public abstract class Subscription
{
    public decimal MonthlyFee { get; set; }
    public int MinimumSubscriptionPeriod { get; set; }
    public List<string> ChannelsAndFeatures { get; set; }

    public Subscription()
    {
    }

    public Subscription(decimal monthlyFee, int minimumSubscriptionPeriod, List<string> channelsAndFeatures)
    {
        MonthlyFee = monthlyFee;
        MinimumSubscriptionPeriod = minimumSubscriptionPeriod;
        ChannelsAndFeatures = channelsAndFeatures;
    }
}

public class DomesticSubscription : Subscription
{
    public DomesticSubscription() : base(5.99m, 1,
        ["ChannelA", "ChannelB"])
    {
    }
}

public class EducationalSubscription : Subscription
{
    public EducationalSubscription() : base(9.99m, 3,
        ["EducationalChannelA", "EducationalChannelB"])
    {
    }
}

public class PremiumSubscription : Subscription
{
    public PremiumSubscription() : base(29.99m, 1,
        ["PremiumChannelA", "PremiumChannelB", "PremiumFeatureA", "PremiumFeatureB"])
    {
    }
}