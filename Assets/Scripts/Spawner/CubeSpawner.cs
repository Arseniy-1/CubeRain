using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private List<Vector3> _spawnPositions;
    [SerializeField] private float _spawnDelay = 1.0f;

    private bool _isEnable = true;

    public event Action<Cube> OnSpawned;

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    private IEnumerator SpawningCubes()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (_isEnable)
        {
            yield return delay;
            Cube obj = Spawn(GetRandomPostion());

            OnSpawned?.Invoke(obj);
        }
    }

    public Cube Spawn(Vector3 position)
    {
        Cube obj = Pool.Get();
        obj.OnDestroyed += PlaceInPool;
        obj.transform.position = position;
        obj.Activate();

        return obj;
    }

    private Vector3 GetRandomPostion()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)];
    }
}
