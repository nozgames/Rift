using UnityEngine;
using NoZ;

namespace Rift
{
    class ImpactEvent : ActorEvent
    {
        public Actor source { get; private set; }
        public Vector3 position { get; private set; }
        public Vector3 normal { get; private set; }
        public float speed { get; private set; }

        public ImpactEvent (Actor source, Vector3 position, Vector3 normal, float speed)
        {
            this.source = source;
            this.position = position;
            this.normal = normal;
            this.speed = speed;
        }
    }
}
