using UnityEngine;
using NoZ;

namespace Rift
{
    class AIController : ActorComponent
    {
        [SerializeField] private float _speed = 10.0f;
        [SerializeField] private float _deathExplosionMultiplier = 10.0f;
        [SerializeField] private GameObject _deathPrefab = null;
        [SerializeField] private GameObject _visuals = null;

        private Health _health;

        public bool isDead => _health.value <= 0;

        private void Awake()
        {
            _health = GetComponentInParent<Health>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            GameManager.enemyCount++;
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            GameManager.enemyCount--;
        }

        private void FixedUpdate()
        {
            var player = GameManager.player;
            if (null == player)
                return;

            var delta = player.transform.position - transform.position;
            var distance = delta.magnitude;
            var direction = delta.normalized;

            transform.position += direction * _speed * Time.deltaTime;
            transform.LookAt(player.transform, Vector3.up);
        }

        [ActorEventHandler]
        private void OnHealthChangeEvent (HealthChangedEvent evt)
        {
            // Did we die?
            if(evt.health.value <= 0)
            {
                
            }
        }

        [ActorEventHandler]
        private void OnImpactEvent (ImpactEvent evt)
        {
            if(isDead && _visuals.activeSelf)
            {
                var death = Instantiate(_deathPrefab, transform.position, transform.rotation);
                foreach (var rigidBody in death.GetComponentsInChildren<Rigidbody>())
                {
                    rigidBody.AddExplosionForce(evt.speed * _deathExplosionMultiplier, evt.position, 2.0f);
                }

                Destroy(actor.gameObject);
            }
        }
    }
}
