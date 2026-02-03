namespace PortAdapterDemystified.Application;

public interface IEventBus
{
    void Publish<TEvent>(TEvent evt);
    void Subscribe<TEvent>(Action<TEvent> handler);
}
