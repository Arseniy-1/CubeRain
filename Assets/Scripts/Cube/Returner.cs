using UnityEngine;

public class Returner : MonoBehaviour, IReturnable
{
    private ObjectPool _objectPool;

    public void Initialize(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void Return(CollectableObject collectable)
    {
        _objectPool.Return(collectable);
    }
}
