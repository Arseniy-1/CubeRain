using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Spawner _cubeSpawner;
    [SerializeField] private Spawner _bombSpawner;
    [SerializeField] private List<Vector3> _cubesSpawnPositions;
    [SerializeField] private float _cubeSpawnDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    private void OnEnable()
    {
        Cube.OnDestroy += SpawnBomb;
    }

    private void OnDisable()
    {
        Cube.OnDestroy -= SpawnBomb;
    }

    private void SpawnBomb(Vector3 position)
    {
        _bombSpawner.Spawn(position);
    }

    private IEnumerator SpawningCubes()
    {
        WaitForSeconds delay = new WaitForSeconds(_cubeSpawnDelay);

        while (true)
        {
            yield return delay;
            _cubeSpawner.Spawn(GetRandomPostion());
        }
    }

    private Vector3 GetRandomPostion()
    {
        return _cubesSpawnPositions[Random.Range(0, _cubesSpawnPositions.Count)];
    }
}
