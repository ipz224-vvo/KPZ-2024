namespace lab_2.FactoryMethod;

public abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription();
}

public class Website : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}

public class MobileApp : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}

public class ManagerCall : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}