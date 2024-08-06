public class BombSpawner : Spawner<Bomb>
{
    protected override void OnEnable()
    {
        base.OnEnable();
        Cube.OnDisabled += Spawn;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Cube.OnDisabled -= Spawn;
    }
}
