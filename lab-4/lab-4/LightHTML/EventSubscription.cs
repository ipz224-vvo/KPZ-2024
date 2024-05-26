namespace lab_4.LightHTML;

class EventSubscription
{
    private Dictionary<string, List<string>> eventHandlers;

    public EventSubscription()
    {
        eventHandlers = new Dictionary<string, List<string>>();
    }

    public void Subscribe(string eventName, string handler)
    {
        if (!eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName] = new List<string>();
        }
        eventHandlers[eventName].Add(handler);
    }

    public void Unsubscribe(string eventName, string handler)
    {
        if (eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName].Remove(handler);
        }
    }

    public Dictionary<string, List<string>> GetEventHandlers()
    {
        return eventHandlers.Count == 0 ? null : eventHandlers;
    }
}