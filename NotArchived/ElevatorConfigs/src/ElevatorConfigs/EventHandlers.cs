using Exiled.Events.EventArgs;

namespace ElevatorConfigs
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public static float ElevatorTimer = Plugin.Singleton.Config.WaitTimer;

        public void ElevatorButton(InteractingElevatorEventArgs ev)
        {
            ev.Lift.movingSpeed = ElevatorTimer;
        }

        public void RoundRestart(RoundEndedEventArgs ev)
        {
            ElevatorTimer = Plugin.Singleton.Config.WaitTimer;
        }
    }
}
