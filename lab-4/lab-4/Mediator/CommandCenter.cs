namespace lab_4.Mediator;


class CommandCenter
{
    
    private Dictionary<Runway, Aircraft> _runways;

    public CommandCenter(Dictionary<Runway, Aircraft> runways)
    {
        _runways = runways;
    }

    public bool CanLand(Guid runwayId)
    {
        var runway = _runways.Keys.FirstOrDefault(runway => runway.Id == runwayId);
        if (runway == null)
        {
            Console.WriteLine("Runway not found.");
            return false;
        }
        var aircraft = _runways[runway];
        if (aircraft == null)
        {
            Console.WriteLine("Runway is clear");
            return true;
        }
        if (runway.IsBusy)
        {
            string byAircraft = aircraft != null ? $" by {aircraft.Name}":"";
            Console.WriteLine($"Runway is occupied{byAircraft}");
            return false;
        }
        return true;
    }

    public void NotifyLanding(Guid runwayId, Aircraft aircraft)
    {
        var runway = _runways.Keys.FirstOrDefault(runway => runway.Id == runwayId);
        if (runway != null)
        {
            _runways[runway] = aircraft;
            runway.IsBusy = true;
            runway.HighLightRed();
        }
    }

    public void NotifyTakeOff(Guid runwayId)
    {
        var runway = _runways.Keys.FirstOrDefault(runway => runway.Id == runwayId);
        if (runway != null)
        {
            _runways[runway] = null;
            runway.IsBusy = false;
            runway.HighLightGreen();
        }
    }
}