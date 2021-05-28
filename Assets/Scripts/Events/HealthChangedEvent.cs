using NoZ;

namespace Rift
{
    class HealthChangedEvent : ActorEvent
    {
        public Health health { get; private set; }
        public float amount { get; private set; }

        public HealthChangedEvent(Health health, float amount) => Set(health, amount);

        public void Set (Health health, float amount)
        {
            this.health = health;
            this.amount = amount;
        }
    }
}
