using UnityEngine;
using UnityEngine.VFX;

namespace Rift
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _size = 0.0f;
        [SerializeField] private GameObject[] _objects = null;
        [SerializeField] private bool _spawnOnAwake = true;
        [SerializeField] private VisualEffect _spawnFX = null;
        [SerializeField] private AudioSource _spawnSound = null;
        [SerializeField] private int _maxEnemies = 0;
        [SerializeField] private bool _centerOnPlayer = true;

        [Header("Timing")]
        [SerializeField] private float _initialDelayMin = 0.0f;
        [SerializeField] private float _initialDelayMax = 0.0f;
        [SerializeField] private float _rateMin = 5.0f;
        [SerializeField] private float _rateMax = 5.0f;

        private float _next = 0.0f;

        private void Awake()
        {
            if (_spawnOnAwake)
            {
                var delay = Random.Range(_initialDelayMin, _initialDelayMax);
                if (delay == 0)
                    Spawn();
                else
                    _next = delay;
            } else
                _next = Random.Range(_rateMin, _rateMax);
        }

        private void Update()
        {
            _next -= Time.deltaTime;
            if (_next <= 0.0f)
            {
                Spawn();
                _next = Random.Range(_rateMin, _rateMax);
            }
        }

        public void Spawn()
        {
            if (_maxEnemies > 0 && GameManager.enemyCount >= _maxEnemies)
                return;

            var position = Vector3.zero;
            do
            {
                position = (_centerOnPlayer ? GameManager.player.transform.position : transform.position)
                    + new Vector3(
                        Random.Range(-_size, _size),
                        0,
                        Random.Range(-_size, _size));

            } while ((position - GameManager.player.transform.position).magnitude < 2.0f);

            if (_spawnFX != null)
            {
                _spawnFX.transform.position = position;
                _spawnFX.enabled = true;
                _spawnFX.Play();
            }

            if (null != _spawnSound)
                _spawnSound.Play();

            Instantiate(_objects[Random.Range(0, _objects.Length)],
                position,
                Quaternion.identity);
        }
    }
}
