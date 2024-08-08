using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : CollectableObject
{
    [SerializeField] protected ObjectPool<T> Pool;

    public int ObjectCount { get; private set; }
    public int ActiveObjectCount { get; private set; }

    public event Action AmountChanged;

    private void OnEnable()
    {
        Pool.ObjectCountChanged += ChangeAmount;
    }

    private void OnDisable()
    {
        Pool.ObjectCountChanged -= ChangeAmount;
    }

    public void Spawn(Vector3 position)
    {
        CollectableObject obj = Pool.Get();
        obj.OnDestroyed += PlaceInPool;
        obj.transform.position = position;
        obj.Activate();
    }

    public virtual void PlaceInPool(CollectableObject collectableObject)
    {
        collectableObject.OnDestroyed -= PlaceInPool;
        Pool.Release((T)collectableObject);
    }

    private void ChangeAmount()
    {
        ObjectCount = Pool.ObjectCount;
        ActiveObjectCount = Pool.ActiveObjectCount;
        AmountChanged?.Invoke();
    }
}
