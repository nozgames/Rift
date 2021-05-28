
using UnityEngine;

namespace Rift
{
    class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _intensity = 1.0f;
        [SerializeField] private float _duration = 0.2f;

        private void Awake()
        {
            GameManager.ShakeCamera(_intensity, _duration);
        }
    }
}
