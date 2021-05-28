using UnityEngine;

namespace Rift
{
    class PlaySound : MonoBehaviour
    {
        [SerializeField] private AudioSource _source = null;
        [SerializeField] private float _minPitch = 1.0f;
        [SerializeField] private float _maxPitch = 1.0f;

        private void Awake()
        {
            _source.pitch = Random.Range(_minPitch, _maxPitch);
            _source.Play();
        }
    }
}
