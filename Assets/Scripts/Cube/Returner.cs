using UnityEngine;

public class Returner : MonoBehaviour
{
    private IPool _objectPool;

    public void Initialize(IPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void Return(CollectableObject collectable)
    {
        _objectPool.Release(collectable);
    }
}
