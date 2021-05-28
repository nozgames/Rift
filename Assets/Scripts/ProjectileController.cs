using UnityEngine;

namespace Rift
{
    class ProjectileController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10.0f;

        private Projectile _projectile = null;
        
        private void Awake()
        {
            _projectile = GetComponent<Projectile>();
        }

        private void FixedUpdate()
        {
            _projectile.MoveTo(_projectile.transform.position + _projectile.transform.forward * _speed * Time.deltaTime);
        }
    }
}
