using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _size = 0.0f;
    [SerializeField] private GameObject[] _objects = null;
    [SerializeField] private float _rate = 5.0f;
    [SerializeField] private bool _spawnOnAwake = true;

    private float _next = 0.0f;

    private void Awake()
    {
        if (_spawnOnAwake)
            Spawn();

        _next = _rate;
    }

    private void Update()
    {
        _next -= Time.deltaTime;
        if(_next <= 0.0f)
        {
            Spawn();
            _next = _rate;
        }
    }

    public void Spawn()
    {
        Instantiate(_objects[Random.Range(0, _objects.Length)],
            transform.position + new Vector3(Random.Range(-_size, _size), 0, Random.Range(-_size, _size)),
            Quaternion.identity);
    }
}
