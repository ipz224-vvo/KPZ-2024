namespace lab_4.Mediator;

class Aircraft
{
    public string Name;
    public bool IsTakingOff { get; set; }
    private CommandCenter commandCenter;

    public Aircraft(string name, CommandCenter commandCenter)
    {
        this.Name = name;
        this.commandCenter = commandCenter;
    }

    public void Land(Guid runwayId)
    {
        Console.WriteLine($"Aircraft {this.Name} is landing.");
        if (commandCenter.CanLand(runwayId))
        {
            Console.WriteLine($"Aircraft {this.Name} has landed.");
            commandCenter.NotifyLanding(runwayId, this);
        }
        else
        {
            Console.WriteLine($"Could not land, the runway is busy.");
        }
    }

    public void TakeOff(Guid runwayId)
    {
        Console.WriteLine($"Aircraft {this.Name} is taking off.");
        commandCenter.NotifyTakeOff(runwayId);
        Console.WriteLine($"Aircraft {this.Name} has took off.");
    }
}