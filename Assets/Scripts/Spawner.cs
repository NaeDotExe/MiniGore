using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _minDelay = 0.5f;
    [SerializeField] private float _maxDelay = 3.0f;

    [SerializeField] private int _minCount = 1;
    [SerializeField] private int _maxCount = 5;

    [SerializeField] private List<Enemy> _prefabs = null;

    private bool _isSpawning = false;
    private bool _canSpawn = true;

    private List<Enemy> _spawnedEntities = new List<Enemy>();

    private void Update()
    {
        if (!_canSpawn)
        {
            return;
        }

        if (!_isSpawning)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        _isSpawning = true;

        // select random nb of enemies
        int count = Random.Range(_minCount, _maxCount + 1);

        // select random delay
        float delay = Random.Range(_minDelay, _maxDelay);

        StartCoroutine(SpawnCoroutine(count, delay));
    }
    private IEnumerator SpawnCoroutine(int count, float delay)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < count; ++i)
        {
            // select random enemy
            int id = Random.Range(0, _prefabs.Count);

            var entity = Instantiate(_prefabs[id], transform.position, Quaternion.identity);
            _spawnedEntities.Add(entity);
        }

        _isSpawning = false;
    }

    public void Stop()
    {
        _canSpawn = false;
        foreach (Enemy enemy in _spawnedEntities)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }
}
