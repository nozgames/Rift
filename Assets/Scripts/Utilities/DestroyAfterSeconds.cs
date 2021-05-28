using UnityEngine;

namespace Rift
{
    class DestroyAfterSeconds : MonoBehaviour
    {
        [SerializeField] private float _seconds = 1.0f;

        private void FixedUpdate()
        {
            _seconds -= Time.deltaTime;
            if (_seconds <= 0.0f)
                Destroy(gameObject);
        }
    }
}
