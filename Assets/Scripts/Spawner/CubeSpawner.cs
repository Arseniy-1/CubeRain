using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private List<Vector3> _spawnPositions;
    [SerializeField] private float _spawnDelay = 1.0f;
    [SerializeField] private BombSpawner _bombSpawner;

    private bool _isEnable = true;

    private void Start()
    {
        StartCoroutine(SpawningCubes());
    }

    public override void PlaceInPool(CollectableObject collectableObject)
    {
        base.PlaceInPool(collectableObject);
        _bombSpawner.Spawn(collectableObject.transform.position);
    }

    private IEnumerator SpawningCubes()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (_isEnable)
        {
            yield return delay;

            Spawn(GetRandomPostion());
        }
    }

    private Vector3 GetRandomPostion()
    {
        return _spawnPositions[Random.Range(0, _spawnPositions.Count)];
    }
}
