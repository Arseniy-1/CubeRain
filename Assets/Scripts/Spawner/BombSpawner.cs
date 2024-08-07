using UnityEngine;

public class BombSpawner : Spawner<Bomb>
{
    [SerializeField] CubeSpawner _cubeSpawner;

    protected override void OnEnable()
    {
        base.OnEnable();
        _cubeSpawner.OnSpawned += TrackCube;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _cubeSpawner.OnSpawned -= TrackCube;
    }

    public void Spawn(Cube cube)
    {
        cube.OnDisabled -= Spawn;

        Bomb obj = Pool.Get();
        obj.OnDestroyed += PlaceInPool;
        obj.transform.position = cube.transform.position;
        obj.Activate();
    }

    private void TrackCube(Cube cube)
    {
        cube.OnDisabled += Spawn;
    }
}
