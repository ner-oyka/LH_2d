using EventBusSystem;

namespace Game.Events
{
    public interface IPlayerRunning : IGlobalSubscriber
    {
        void OnStartRunning();
        void OnStopRunning();
    }
}
