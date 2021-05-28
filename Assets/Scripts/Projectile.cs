using NoZ;
using UnityEngine;

namespace Rift
{
    class Projectile : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _lifetime = 0;
        [SerializeField] private float _damage = 0;
        [SerializeField] GameObject _impactFX = null;

        [Header("Physics")]
        [SerializeField] private LayerMask _collisionMask = 0;
        [SerializeField] private float _radius = 0.1f;

        public Actor source { get; set; }

        private void FixedUpdate()
        {
            _lifetime -= Time.deltaTime;
            if (_lifetime <= 0.0f)
                Destroy(gameObject);
        }

        /// <summary>
        /// Move the projectile to the given position
        /// </summary>
        public void MoveTo (Vector3 position)
        {
            var delta = position - transform.position;
            var distance = delta.magnitude;
            if (distance <= 0.0f)
                return;

            var direction = delta.normalized;
            if (Physics.SphereCast(transform.position, _radius, direction, out var hit, distance, _collisionMask))
            {
                var health = hit.collider.GetComponentInParent<Health>();
                if (health != null)
                    health.Adjust(-_damage);

                var actor = hit.collider.GetComponentInParent<Actor>();
                if (actor != null)
                    actor.Send(new ImpactEvent(source, hit.point, hit.normal.ToXZ(), distance / Time.deltaTime));

                if(_impactFX != null)
                {
                    var impactFX = Instantiate(_impactFX, null);
                    impactFX.transform.position = hit.point;
                    impactFX.transform.rotation = Quaternion.LookRotation(hit.normal.ToXZ(), Vector3.up);
                }                

                Destroy(gameObject);
                return;
            }

            transform.position = position;
        }
    }
}
